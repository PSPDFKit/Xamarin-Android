using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.Fragment.App;
using Android.Views;
using Xamarin.Essentials;

using AndroidHUD;

using PSPDFKit;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.UI;

using SampleTools;

namespace PSPDFCatalog {
	[Activity (Label = "External Document", WindowSoftInputMode = SoftInput.AdjustNothing)]
	public class ExternalExampleActivity : FragmentActivity {

		public static string ExtraConfiguration { get; } = "PSPDFKit.ExternalExampleActivity.configuration";

		PdfActivityConfiguration configuration;
		bool waitingForResult;
		const string isWaitingForResult = "PSPDFKit.ExternalExampleActivity.waitingForResult";
		const string downloadProgressFragment = "DownloadProgressFragment";
		const int requestOpenDocument = 1;

		protected override async void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Make sure the example activity is launched with the required extras.
			if (!Intent.HasExtra (ExtraConfiguration))
				throw new InvalidOperationException ($"{nameof (ExternalExampleActivity)} was started without a 'PdfActivityConfiguration'.");

			// Extract the configuration for displaying the viewer activity.
			configuration = Intent.GetParcelableExtra (ExtraConfiguration)?.JavaCast<PdfActivityConfiguration> ();

			// Check if the activity was recreated, and see if the user already started document picking.
			waitingForResult = savedInstanceState?.GetBoolean (isWaitingForResult, false) ?? false;

			// Prevent the example from requesting multiple documents at the same time.
			if (!waitingForResult) {
				waitingForResult = true;

				PermissionStatus status;

				if (DeviceInfo.Platform == DevicePlatform.Android && DeviceInfo.Version.Major >= 13)
					status = PermissionStatus.Granted;
				else {
					// On Android 6.0+ we ask for SD card access permission. This isn't strictly necessary, but PSPDFKit
					// being able to access file directly will significantly improve performance.
					// Since documents can be annotated we ask for write permission as well.
					status = await Permissions.CheckStatusAsync<Permissions.StorageRead> ();
					if (status != PermissionStatus.Granted) {
						AndHUD.Shared.Show (this, "Need Storage Permission", maskType: MaskType.Clear, timeout: TimeSpan.FromSeconds (1));
						status = await Permissions.RequestAsync<Permissions.StorageRead> ();
					}
				}

				if (status == PermissionStatus.Granted)
					ShowOpenFileDialog ();
				else if (status != PermissionStatus.Unknown)
					AndHUD.Shared.ShowError (this, "Storage Permission Denied", MaskType.Clear, TimeSpan.FromSeconds (2));
			}

			void ShowOpenFileDialog ()
			{
				// Prepare an implicit intent which allows the user to select any document.
				var intent = new Intent (Intent.ActionOpenDocument);
				intent.AddCategory (Intent.CategoryOpenable);
				intent.SetType ("*/*");
				intent.PutExtra (Intent.ExtraMimeTypes, new [] { "application/pdf", "image/*" });

				// Set of the intent for result, so we can retrieve the Uri of the selected document.
				StartActivityForResult (intent, requestOpenDocument);
			}
		}

		protected async override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			if (requestCode == requestOpenDocument && resultCode == Result.Ok && data != null) {
				Android.Net.Uri uri = null;

				// Some URIs can be opened directly, including local filesystem, app assets, and content provider URIs.
				if (!PSPDFKitGlobal.IsOpenableUri (this, data.Data)) {
					// The Uri cannot be directly opened. Download the PDF document from the uri, for local access.
					AndHUD.Shared.Show (this, "Downloading file", 0);

					var docPath = Path.Combine (ApplicationContext.CacheDir.ToString (), DateTime.Now.Ticks.ToString () + ".pdf");
					var progressReporter = new Progress<DownloadBytesProgress> ();
					progressReporter.ProgressChanged += (s, args) => AndHUD.Shared.Show (this, "Downloading file", (int)(100 * args.PercentComplete));
					uri = await Utils.DownloadDocument (this, data.Data, docPath, progressReporter);
					AndHUD.Shared.Dismiss (this);
				} else
					uri = data.Data;

				var intent = PdfActivityIntentBuilder
					.FromUri (this, uri)
					.Configuration (configuration)
					.Build ();

				StartActivity (intent);
				Finish ();
			}
		}

		public override void OnRequestPermissionsResult (int requestCode, string [] permissions, Android.Content.PM.Permission [] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult (requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult (requestCode, permissions, grantResults);
		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			base.OnSaveInstanceState (outState);

			// Retain if we are currently waiting for an intent to return, so we don't set it off
			// twice by accident.
			outState.PutBoolean (isWaitingForResult, waitingForResult);
		}
	}
}
