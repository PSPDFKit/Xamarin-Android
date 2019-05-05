using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V4.Graphics.Drawable;
using Android.Views;
using Plugin.CurrentActivity;
using PSPDFKit.Document.Sharing;
using PSPDFKit.Instant;
using PSPDFKit.UI.ActionMenuSdk;

namespace PSPDFCatalog {
	// Extends 'InstantPdfActivity' with the ability to share the Instant document with other users.
	[Activity (Label = "InstantExampleActivity")]
	public class InstantExampleActivity : InstantPdfActivity, SharingMenu.ISharingMenuListener, IActionMenuListener {

		// Name of the extra holding 'InstantExampleDocumentDescriptor' of the displayed document.
		public static string DocumentDescriptor = "InstantExampleActivity.DocumentDescriptor";

		InstantDocumentInfo documentInfo;

		// Main toolbar icons color.
		private int mainToolbarIconsColor;

		// Menu with collaborate sharing actions.
		private SharingMenu collaborateMenu;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			documentInfo = InstantDocumentInfo.FromJson (Intent.GetStringExtra (DocumentDescriptor));
			if (documentInfo is null)
				throw new InvalidOperationException ("InstantExampleActivity was not initialized with proper arguments: Missing document descriptor extra!");
			var a = Theme.ObtainStyledAttributes (null, Resource.Styleable.pspdf__ActionBarIcons, Resource.Attribute.pspdf__actionBarIconsStyle, Resource.Style.PSPDFKit_ActionBarIcons);
			mainToolbarIconsColor = a.GetColor (Resource.Styleable.pspdf__ActionBarIcons_pspdf__iconsColor, ContextCompat.GetColor (this, Resource.Color.pspdf__color_white));
			a.Recycle ();

			InitCollaborateMenu ();
		}

		void InitCollaborateMenu ()
		{
			collaborateMenu = new SharingMenu (this, this);
			collaborateMenu.SetTitle ("Collaborate");

			collaborateMenu.AddMenuItem (new FixedActionMenuItem (this, Resource.Id.open_in_browser, Resource.Drawable.ic_open_in_browser, "Open in Browser"));
			collaborateMenu.AddMenuItem (new FixedActionMenuItem (this, Resource.Id.share_document_link, Resource.Drawable.pspdf__ic_open_in, "Share Document Link"));
			collaborateMenu.AddMenuItem (new FixedActionMenuItem (this, Resource.Id.share_document_code, Resource.Drawable.pspdf__ic_open_in, $"Share Document Code: {documentInfo.EncodedDocumentId}"));

			collaborateMenu.AddActionMenuListener (this);
		}

		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			base.OnPrepareOptionsMenu (menu);

			var collaborateMenuItem = menu.Add (0, Resource.Id.instant_collaborate, 0, "Collaborate");
			collaborateMenuItem.SetShowAsAction (ShowAsAction.Always);
			collaborateMenuItem.SetEnabled (Document != null);

			var drawable = ContextCompat.GetDrawable (this, Resource.Drawable.ic_collaborate);
			drawable.SetAlpha (Document is null ? 128 : 255);
			DrawableCompat.SetTint (drawable, mainToolbarIconsColor);
			collaborateMenuItem.SetIcon (drawable);

			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == Resource.Id.instant_collaborate) {
				collaborateMenu.Show ();
				return true;
			}
			return base.OnOptionsItemSelected (item);
		}

		public void PerformShare (ShareTarget shareTarget) { }
		public bool OnPrepareActionMenu (ActionMenu actionMenu) => true;
		public void OnDisplayActionMenu (ActionMenu actionMenu) { }
		public void OnRemoveActionMenu (ActionMenu actionMenu) { }
		public bool OnActionMenuItemLongClicked (ActionMenu actionMenu, ActionMenuItem menuItem) => false;

		public bool OnActionMenuItemClicked (ActionMenu actionMenu, ActionMenuItem menuItem)
		{
			switch (menuItem.ItemId) {
			case Resource.Id.share_document_link:
				// Sharing link to the Instant document.
				ShowShareTextMenu ("Share Document Link", documentInfo.Url);
				return true;
			case Resource.Id.share_document_code:
				// Sharing code of the Instant document, that can be used at pspdfkit.com/instant/try.
				ShowShareTextMenu ("Share Document Code", documentInfo.EncodedDocumentId);
				return true;
			case Resource.Id.open_in_browser:
				// Opens Instant document link in the web browser.
				ShowOpenInBrowserMenu ();
				return true;
			default:
				return false;
			}
		}

		void ShowOpenInBrowserMenu ()
		{
			var shareIntent = new Intent (Intent.ActionView, Android.Net.Uri.Parse (documentInfo.Url));
			var sharingMenu = new SharingMenu (this, new SharingMenuListener (shareIntent));
			sharingMenu.SetTitle ("Open in Browser");
			sharingMenu.SetShareIntents (new List<Intent> (1) { shareIntent });

			collaborateMenu.Dismiss ();
			sharingMenu.Show ();
		}

		void ShowShareTextMenu (string titleRes, String textToShare)
		{
			var shareIntent = DocumentSharingIntentHelper.GetShareTextIntent (textToShare);
			var sharingMenu = new SharingMenu (this, new SharingMenuListener (shareIntent));
			sharingMenu.SetTitle (titleRes);
			sharingMenu.SetShareIntents (new List<Intent> (1) { shareIntent });

			collaborateMenu.Dismiss ();
			sharingMenu.Show ();
		}

		class SharingMenuListener : Java.Lang.Object, SharingMenu.ISharingMenuListener {
			readonly Intent shareIntent;

			public SharingMenuListener (Intent intent)
			{
				shareIntent = intent;
			}

			public void PerformShare (ShareTarget shareTarget)
			{
				shareIntent.SetPackage (shareTarget.PackageName);
				CrossCurrentActivity.Current.Activity.StartActivity (shareIntent);
			}
		}
	}
}
