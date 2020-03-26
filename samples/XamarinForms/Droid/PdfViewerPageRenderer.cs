using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V4.Graphics.Drawable;
using AndroidX.AppCompat.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

using PSPDFKit.Annotations;
using PSPDFKit.Annotations.Actions;
using PSPDFKit.Configuration;
using PSPDFKit.Document;
using PSPDFKit.Listeners;
using PSPDFKit.UI;
using PSPDFKit.UI.Outline;
using PSPDFKit.UI.Search;
using PSPDFKit.Utils;
using SampleTools;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using XFSample;
using XFSample.Droid;

[assembly: ExportRenderer (typeof (PdfViewerPage), typeof (PdfViewerPageRenderer))]

namespace XFSample.Droid {
	public class PdfViewerPageRenderer : PageRenderer, IDocumentListener, IOnDocumentLongPressListener {

		public static string ExtraUri { get; } = "com.pspdfkit.pspdfcatalog.examples.activities.CustomFragmentActivity.EXTRA_URI";

		PdfFragment fragment;
		PdfThumbnailBar thumbnailBar;
		PdfConfiguration configuration;
		PdfSearchViewModular modularSearchView;
		PdfThumbnailGrid thumbnailGrid;
		SearchResultHighlighter highlighter;
		PdfOutlineView pdfOutlineView;

		MainActivity activity;
		Android.Views.View view;

		public PdfViewerPageRenderer (Context context) : base (context)
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null || Element == null)
				return;
			
			activity = Context as MainActivity;
			view = activity.LayoutInflater.Inflate (Resource.Layout.ActivityCustomFragment, this, false);

			// Get the Uri provided when launching the activity.
			var documentUri = Utils.ExtractAsset (Context, MainActivity.sampleDoc);

			// Create a new (plain) configuration.
			configuration = new PdfConfiguration.Builder ().Build ();

			fragment = PdfFragment.NewInstance (documentUri, configuration);
			activity.SupportFragmentManager
				.BeginTransaction ()
				// We use a small hack JavaCast<T> because at build time we expect a 'Android.Support.V4.App.Fragment'
				// but 'PdfFragment' extends 'AndroidX.Fragment.App.Fragment' but migration package should fix it for us at runtime.
				.Replace (Resource.Id.fragmentContainer, fragment.JavaCast<Android.Support.V4.App.Fragment> ())
				.Commit ();

			InitModularSearchViewAndButton ();
			InitOutlineViewAndButton ();
			InitThumbnailBar ();
			InitThumbnailGridAndButton ();

			// Register the activity to be notified when the document is loaded.
			fragment.AddDocumentListener (this);
			fragment.AddDocumentListener (modularSearchView?.JavaCast<IDocumentListener> ());
			fragment.AddDocumentListener (thumbnailBar.DocumentListener);
			fragment.AddDocumentListener (thumbnailGrid);
			fragment.SetOnDocumentLongPressListener (this);

			(this.Element as PdfViewerPage).OnBackPressed = OnBackPressed;

			AddView (view);
		}

		public bool OnBackPressed ()
		{
			if (modularSearchView.IsDisplayed) {
				modularSearchView.HideView ();
				return true;
			}

			if (thumbnailGrid.IsDisplayed) {
				thumbnailGrid.HideView ();
				return true;
			}

			if (pdfOutlineView.IsDisplayed) {
				pdfOutlineView.HideView ();
				return true;
			}

			return false;
		}

		protected override void OnLayout (bool changed, int l, int t, int r, int b)
		{
			base.OnLayout (changed, l, t, r, b);

			var msw = MeasureSpec.MakeMeasureSpec (r - l, MeasureSpecMode.Exactly);
			var msh = MeasureSpec.MakeMeasureSpec (b - t, MeasureSpecMode.Exactly);

			view.Measure (msw, msh);
			view.Layout (0, 0, r - l, b - t);
		}

		void InitThumbnailGridAndButton ()
		{
			thumbnailGrid = view.FindViewById<PdfThumbnailGrid> (Resource.Id.thumbnailGrid);
			if (thumbnailGrid == null)
				throw new IllegalStateException ("Error while loading CustomFragmentActivity. The example layout was missing the thumbnail grid view.");

			thumbnailGrid.PageClick += (sender, e) => {
				fragment.PageIndex = e.P1;
				(sender as PdfThumbnailGrid)?.HideView ();
			};

			// The thumbnail grid is hidden by default. Set up a click listener to show it.
			var openTumbnailGridButton = view.FindViewById<ImageView> (Resource.Id.openThumbnailGridButton);
			openTumbnailGridButton.Click += (sender, e) => thumbnailGrid.ShowView ();
			openTumbnailGridButton.SetImageDrawable (TintDrawable (openTumbnailGridButton.Drawable, ContextCompat.GetColor (Context, Resource.Color.pspdf__color_white)));
		}

		void InitThumbnailBar ()
		{
			thumbnailBar = view.FindViewById<PdfThumbnailBar> (Resource.Id.thumbnailBar);
			if (thumbnailBar == null)
				throw new IllegalStateException ("Error while loading CustomFragmentActivity. The example layout was missing thumbnail bar view.");
			thumbnailBar.PageChanged += (sender, e) => fragment.PageIndex = e.P1;
		}

		void InitOutlineViewAndButton ()
		{
			// Extract the remaining views from our custom layout.
			pdfOutlineView = view.FindViewById<PdfOutlineView> (Resource.Id.outlineView);
			if (pdfOutlineView == null)
				throw new IllegalStateException ("Error while loading CustomFragmentActivity. The example layout was missing the outline view.");

			var outlineViewListener = new DefaultOutlineViewListener (fragment);
			pdfOutlineView.SetOnAnnotationTapListener (outlineViewListener);
			pdfOutlineView.SetOnOutlineElementTapListener (outlineViewListener);
			pdfOutlineView.SetBookmarkAdapter (new DefaultBookmarkAdapter (fragment));

			var openOutlineButton = view.FindViewById<ImageView> (Resource.Id.openOutlineButton);
			openOutlineButton.Click += (sender, e) => pdfOutlineView.ShowView ();
			openOutlineButton.SetImageDrawable (TintDrawable (openOutlineButton.Drawable, ContextCompat.GetColor (Context, Resource.Color.pspdf__color_white)));
		}

		void InitModularSearchViewAndButton ()
		{
			// The search result highlighter will highlight any selected result.
			highlighter = new SearchResultHighlighter (Context);
			fragment.AddDrawableProvider (highlighter);

			modularSearchView = view.FindViewById<PdfSearchViewModular> (Resource.Id.modularSearchView);
			if (modularSearchView == null)
				throw new IllegalStateException ("Error while loading CustomFragmentActivity. The example layout was missing the search view.");

			modularSearchView.MoreSearchResults += (sender, e) => highlighter.AddSearchResults (e.P0);
			modularSearchView.SearchCleared += (sender, e) => highlighter.ClearSearchResults ();
			modularSearchView.SearchResultSelected += (sender, e) => {
				// Pass on the search result to the highlighter. If 'null' the highlighter will clear any selection.
				highlighter.SetSelectedSearchResult (e.P0);
				if (e.P0 != null)
					fragment.ScrollTo (PdfUtils.CreatePdfRectUnion (e.P0.TextBlock.PageRects.Cast<RectF> ().ToList ()), e.P0.PageIndex, 250, false);
			};

			// The search view is hidden by default (see layout). Set up a click listener that will show the view once pressed.
			var openSearchButton = view.FindViewById<ImageView> (Resource.Id.openSearchButton);
			openSearchButton.SetImageDrawable (TintDrawable (openSearchButton.Drawable, ContextCompat.GetColor (Context, Resource.Color.pspdf__color_white)));
			openSearchButton.Click += (sender, e) => modularSearchView.ShowView ();
		}

		void CreateNoteAnnotation (int pageIndex)
		{
			var pageRect = new RectF (180, 692, 212, 660);
			var contents = "This is note annotation was created from code.";
			var icon = NoteAnnotation.Cross;
			int color = Android.Graphics.Color.Green;

			// Create the annotation, and set the color.
			var noteAnnotation = new NoteAnnotation (pageIndex, pageRect, contents, icon);
			noteAnnotation.Color = color;

			fragment.AddAnnotationToPage (noteAnnotation, false);
		}

		public void OnDocumentLoaded (IPdfDocument document)
		{
			fragment.AddDocumentListener (modularSearchView?.JavaCast<IDocumentListener> ());
			thumbnailBar.SetDocument (document, configuration);
			modularSearchView.SetDocument (document, configuration);
			pdfOutlineView.SetDocument (document, configuration);
			thumbnailGrid.SetDocument (document, configuration);

			// Adding note annotation to populate Annotation section in PdfOutlineView
			CreateNoteAnnotation (1);
		}

		public void OnDocumentLoadFailed (Throwable exception)
		{
		}

		public bool OnDocumentSave (IPdfDocument document, DocumentSaveOptions saveOptions)
		{
			return true;
		}

		public void OnDocumentSaved (IPdfDocument document)
		{
		}

		public void OnDocumentSaveFailed (IPdfDocument document, Throwable exception)
		{
		}

		public void OnDocumentSaveCancelled (IPdfDocument document)
		{
		}

		public bool OnPageClick (IPdfDocument document, int pageIndex, MotionEvent @event, PointF pagePosition, Annotation pclickedAnnotation4)
		{
			return false;
		}

		public bool OnDocumentClick ()
		{
			return false;
		}

		public void OnPageChanged (IPdfDocument document, int pageIndex)
		{
		}

		public void OnDocumentZoomed (IPdfDocument document, int pageIndex, float scaleFactor)
		{
		}

		public void OnPageUpdated (IPdfDocument document, int pageIndex)
		{
		}

		public bool OnDocumentLongPress (IPdfDocument document, int pageIndex, MotionEvent @event, PointF pagePosition, Annotation longPressedAnnotation)
		{
			if (fragment.View != null)
				fragment.View.PerformHapticFeedback (FeedbackConstants.LongPress);

			if (longPressedAnnotation is LinkAnnotation) {
				var action = ((LinkAnnotation) longPressedAnnotation)?.Action;
				if (action != null && action.Type == ActionType.Uri) {
					var uri = ((UriAction) action).Uri;
					Toast.MakeText (Context, uri, ToastLength.Long).Show ();
					return true;
				}
			}
			return false;
		}

		Drawable TintDrawable (Drawable drawable, int tint)
		{
			Drawable tintedDrawable = DrawableCompat.Wrap (drawable);
			DrawableCompat.SetTint (tintedDrawable, tint);
			return tintedDrawable;
		}
	}
}
