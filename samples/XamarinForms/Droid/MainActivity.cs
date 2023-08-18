using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Plugin.CurrentActivity;
using PSPDFKit;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.Configuration.Page;
using PSPDFKit.UI;
using XFSample.Droid;
using SampleTools;

// This will add your license key into AndroidManifest.xml at build time. For more info on how this Attribute works see:
// https://developer.xamarin.com/guides/android/advanced_topics/working_with_androidmanifest.xml/
//[assembly: MetaData (
//	name: "pspdfkit_license_key",
//	Value = "LICENSE_KEY_GOES_HERE"
//)]

// Register MainActivity into Xamarin.Forms's Dependency Service
[assembly: Xamarin.Forms.Dependency (typeof (MainActivity))]

namespace XFSample.Droid {
	[Activity (Label = "XFSample.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IPdfService {

		internal const string sampleDoc = "demo.pdf";

		protected override void OnCreate (Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate (savedInstanceState);

			CrossCurrentActivity.Current.Init (this, savedInstanceState);
			Xamarin.Essentials.Platform.Init (this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init (this, savedInstanceState);

			LoadApplication (new App ());
		}

		public override void OnRequestPermissionsResult (int requestCode, string [] permissions, Permission [] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult (requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult (requestCode, permissions, grantResults);
		}

		// Opens a demo document from assets directory, called from Xamarin.Forms's DependencyService, see 'ShowPDF ()' method in XFSamplePage.xaml.cs
		public void ShowPdfActivity ()
		{
			// Extract the pdf from assets if not already extracted
			var docUri = Utils.ExtractAsset (CrossCurrentActivity.Current.Activity, sampleDoc);

			// Show Document using PSPDFKit activity
			var pspdfkitConfiguration = new PdfActivityConfiguration.Builder (CrossCurrentActivity.Current.Activity)
				.ScrollDirection (PageScrollDirection.Horizontal)
				.ShowPageNumberOverlay ()
				.ShowThumbnailGrid ()
				.FitMode (PageFitMode.FitToWidth)
				.Build ();

			if (!PSPDFKitGlobal.IsOpenableUri (this, docUri))
				ShowError ("This document uri cannot be opened \n " + docUri.ToString ());
			else
				PdfActivity.ShowDocument (CrossCurrentActivity.Current.Activity, docUri, pspdfkitConfiguration);
		}

		void ShowError (string message = null)
		{
			var alert = new AlertDialog.Builder (this);

			alert.SetTitle ("Error");
			alert.SetMessage (message ?? "There was an error");

			alert.SetPositiveButton ("Ok", (senderAlert, args) => {
				// Do something here to handle error
			});

			if (message != null) {
				alert.SetNeutralButton ("Visit", (sender, e) => {
					var uri = Android.Net.Uri.Parse ("https://pspdfkit.com/android/");
					var intent = new Intent (Intent.ActionView, uri);
					StartActivity (intent);
				});
			}

			RunOnUiThread (() => {
				alert.Show ();
			});
		}
	}
}
