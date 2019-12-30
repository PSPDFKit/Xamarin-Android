using PSPDFKit.Configuration.Page;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PSPDFKit.Configuration.Activity;
using Android.Content;
using PSPDFKit.Configuration.Theming;

namespace PSPDFCatalog {
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage {

		public SettingsPage ()
		{
			InitializeComponent ();
			BindingContext = new SettingsViewModel ();
		}

		public static PdfActivityConfiguration.Builder GetConfiguration (Context ctx)
		{
			var conf = new PdfActivityConfiguration.Builder (ctx);
			conf.ScrollDirection (PageScrollDirection.ValueOf (Settings.Current.ScrollDirection))
				.LayoutMode (PageLayoutMode.ValueOf (Settings.Current.PageLayout))
				.ScrollMode (Settings.Current.ScrollMode ? PageScrollMode.Continuous : PageScrollMode.PerPage)
				.FitMode (Settings.Current.FitMode ? PageFitMode.FitToWidth : PageFitMode.FitToScreen)
				.RestoreLastViewedPage (Settings.Current.RestoreLastViewedPage)
				.SetUserInterfaceViewMode (UserInterfaceViewMode.ValueOf (Settings.Current.UIViewMode))
				.HideUserInterfaceWhenCreatingAnnotations (Settings.Current.HideUIWhenCreatingAnnotations)
			    .ThemeMode (ThemeMode.ValueOf (Settings.Current.ThemeModeSetting))
				.FirstPageAlwaysSingle (Settings.Current.FirstPageAlwaysSingle)
				.ShowGapBetweenPages (Settings.Current.ShowGapBetweenPages)
				.SetSearchType (Settings.Current.InlineSearch ? PdfActivityConfiguration.SearchInline : PdfActivityConfiguration.SearchModular)
				.SetThumbnailBarMode (ThumbnailBarMode.ValueOf (Settings.Current.ThumbnailsBarMode))
			    .InvertColors (Settings.Current.InvertPageColors || ThemeMode.ValueOf (Settings.Current.ThemeModeSetting) == ThemeMode.Night)
			    .ToGrayscale (Settings.Current.Grayscale)
			    .TextSelectionEnabled (Settings.Current.EnableTextSelection)
			    .UseImmersiveMode (Settings.Current.ImmersiveMode);

			if (Settings.Current.ShowPageNumberOverlay)
				conf.ShowPageNumberOverlay ();
			else
				conf.HidePageNumberOverlay ();

			if (Settings.Current.ShowPageLabels)
				conf.ShowPageLabels ();
			else
				conf.HidePageLabels ();

			if (Settings.Current.EnableSearch)
				conf.EnableSearch ();
			else
				conf.DisableSearch ();

			if (Settings.Current.ShowThumbnailGrid)
				conf.ShowThumbnailGrid ();
			else
				conf.HideThumbnailGrid ();

			if (Settings.Current.EnableDocumentOutline)
				conf.EnableOutline ();
			else
				conf.DisableOutline ();

			if (Settings.Current.EnableAnnotationList)
				conf.EnableAnnotationList ();
			else
				conf.DisableAnnotationList ();

			if (Settings.Current.EnableAnnotationEditing)
				conf.EnableAnnotationEditing ();
			else
				conf.DisableAnnotationEditing ();

			if (Settings.Current.EnableFormEditing)
				conf.EnableFormEditing ();
			else
				conf.DisableFormEditing ();

			//if (Settings.Current.ShowShareAction)
			//	conf.SetEnabledShareFeatures ()
			//else
			//	conf.DisableShare ();

			if (Settings.Current.ShowPrintAction)
				conf.EnablePrinting ();
			else
				conf.DisablePrinting ();

			return conf;
		}
	}
}
