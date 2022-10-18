using System;
using System.IO;

using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Android.Widget;

using PSPDFKit;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.Configuration.Page;
using PSPDFKit.UI;
using SampleTools;
using AndroidHUD;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;
using Environment = System.Environment;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using PSPDFKit.Document.Download;
using Android.Icu.Util;
using Java.Lang;
using Exception = System.Exception;
using Java.Net;
using PSPDFKit.Document.Download.Source;
using PSPDFKit.Document.Processor;
using System.Net.Http;

// This will add your license key into AndroidManifest.xml at build time. For more info on how this Attribute works see:
// https://developer.xamarin.com/guides/android/advanced_topics/working_with_androidmanifest.xml/
//[assembly: MetaData (
//	name:"pspdfkit_license_key",
//	Value = "LICENSE_KEY_GOES_HERE"
//)]

namespace AndroidSample {
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
	public class MainActivity : Activity {

		const string sampleDoc = "demo.pdf";
		const int RequestOpenDocument = 1;

		// On Marshmallow+ devices this is used to ask for the necessary write permission.
		const int RequestWritePermission = 2;
		readonly string [] PermissionsExternalStorage = {
			Manifest.Permission.ReadExternalStorage,
			Manifest.Permission.WriteExternalStorage
		};

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            //var openDemoDocumentFromUrlAndroidButton = FindViewById<Button>(Resource.Id.main_btn_open_from_url_android_example);
            var openDemoDocumentFromUrlButton = FindViewById<Button>(Resource.Id.main_btn_open_from_url_example);
            var openDemoDocumentButton = FindViewById<Button>(Resource.Id.main_btn_open_example);
            var openDocumentButton = FindViewById <Button> (Resource.Id.main_btn_open_document);

            // Opens a demo document from url
            openDemoDocumentFromUrlButton.Click += async (sender, e) => {
                var downloadedFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "newDocument.pdf");

                var success = await DownloadFileAsync("https://pspdfkit.com/downloads/case-study-box.pdf", downloadedFilePath);

                if (success)
                {
                    Console.WriteLine($"File downloaded to: {downloadedFilePath}");
                }
                else
                {
                    Console.WriteLine("Download failed");
                }

                var file = new Java.IO.File(downloadedFilePath);
                var filePath = Android.Net.Uri.FromFile(file);

                ShowPdfDocument(filePath);
                return;
            };

            // Opens a demo document from assets directory
            openDemoDocumentButton.Click += (sender, e) => {
                // On Marshmallow devices the user must grant write permission to the extrnal storage.
                const string permission = Manifest.Permission.WriteExternalStorage;
                if (ContextCompat.CheckSelfPermission(this, permission) == (int)Permission.Granted)
                {
                    ShowDocumentFromAssets();
                    return;
                }

                ActivityCompat.RequestPermissions(this, PermissionsExternalStorage, RequestWritePermission);
            };

            // Opens a document from Android document provider
            openDocumentButton.Click += (sender, e) => {
				var openIntent = new Intent (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat ? Intent.ActionOpenDocument : Intent.ActionGetContent);
				openIntent.AddCategory (Intent.CategoryOpenable);
				openIntent.SetType ("application/*");
				StartActivityForResult (openIntent, RequestOpenDocument);
			};
        }

        private void Job_Complete(object sender, DownloadJob.CompleteEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> DownloadFileAsync(string fileUrl, string downloadedFilePath)
        {
            try
            {
                using var client = new HttpClient();

                var downloadStream = await client.GetStreamAsync(fileUrl);

                using var fileStream = File.Create(downloadedFilePath);

                await downloadStream.CopyToAsync(fileStream);

                return true;
            }
            catch (Exception ex)
            {
                //TODO handle exception
                return false;
            }
            return true;
        }

        void ShowDocumentFromAssets()
        {
            // Extract the pdf from assets if not already extracted
            var docUri = Utils.ExtractAsset(this, sampleDoc);
            ShowPdfDocument(docUri);
            return;
        }

        void ShowPdfDocument (Android.Net.Uri docUri)
		{
			// Show Document using PSPDFKit activity
			var pspdfkitConfiguration = new PdfActivityConfiguration.Builder (ApplicationContext)
				.ScrollDirection (PageScrollDirection.Horizontal)
				.ShowPageNumberOverlay ()
				.ShowThumbnailGrid ()
				.FitMode (PageFitMode.FitToWidth)
				.Build ();

			if (!PSPDFKitGlobal.IsOpenableUri (this, docUri))
				ShowError ("This document uri cannot be opened \n " + docUri.ToString ());
			else
				PdfActivity.ShowDocument (this, docUri, pspdfkitConfiguration);
		}

		protected async override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			if (requestCode == RequestOpenDocument && resultCode == Result.Ok && data != null) {
				// Only document accessible as files are openable directly with PSPDFKit so we have to
				// transfer other documents to application cache
				if (!PSPDFKitGlobal.IsOpenableUri (this, data.Data)) {
					AndHUD.Shared.Show (this, "Downloading file", 0);

					var docPath = Path.Combine (ApplicationContext.CacheDir.ToString (), DateTime.Now.Ticks.ToString () + ".pdf");
					var progressReporter = new Progress<DownloadBytesProgress> ();
					progressReporter.ProgressChanged += (s, args) => AndHUD.Shared.Show (this, "Downloading file", (int)(100 * args.PercentComplete));
					var docUri = await Utils.DownloadDocument (this, data.Data, docPath, progressReporter);
					AndHUD.Shared.Dismiss (this);
					ShowPdfDocument (docUri);
				} else
					ShowPdfDocument (data.Data);
			}
		}
			
		public override void OnRequestPermissionsResult (int requestCode, string[] permissions, Permission[] grantResults)
		{
			if (requestCode == RequestWritePermission && grantResults[0] == Permission.Granted)
				ShowDocumentFromAssets ();
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


