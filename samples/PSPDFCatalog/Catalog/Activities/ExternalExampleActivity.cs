using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;

using AndroidHUD;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using PSPDFKit;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.Document.Download;
using PSPDFKit.UI;

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

				// On Android 6.0+ we ask for SD card access permission. This isn't strictly necessary, but PSPDFKit
				// being able to access file directly will significantly improve performance.
				// Since documents can be annotated we ask for write permission as well.
				var status = await CrossPermissions.Current.CheckPermissionStatusAsync (Permission.Storage);
				if (status != PermissionStatus.Granted) {
					if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync (Permission.Storage))
						AndHUD.Shared.Show (this, "Need Storage Permission", maskType: MaskType.Clear, timeout: TimeSpan.FromSeconds (1));

					var results = await CrossPermissions.Current.RequestPermissionsAsync (Permission.Storage);
					//Best practice to always check that the key exists
					if (results.ContainsKey (Permission.Storage))
						status = results [Permission.Storage];
				}

				if (status == PermissionStatus.Granted)
					ShowOpenFileDialog ();
				else if (status != PermissionStatus.Unknown)
					AndHUD.Shared.ShowError (this, "Storage Permission Denied", MaskType.Clear, TimeSpan.FromSeconds (2));
			}

			void ShowOpenFileDialog ()
			{
				// Prepare an implicit intent which allows the user to select any document.
				var openIntent = new Intent (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat ? Intent.ActionOpenDocument : Intent.ActionGetContent);
				openIntent.AddCategory (Intent.CategoryOpenable);
				openIntent.SetType ("application/*");

				// Set of the intent for result, so we can retrieve the Uri of the selected document.
				StartActivityForResult (openIntent, requestOpenDocument);
			}
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			if (requestCode == requestOpenDocument && resultCode == Result.Ok && data != null) {
				var uri = data.Data;

				// Some URIs can be opened directly, including local filesystem, app assets, and content provider URIs.
				if (PSPDFKitGlobal.IsOpenableUri (this, uri)) {
					var intent = PdfActivityIntentBuilder.FromUri (this, uri)
														 .Configuration (configuration)
														 .Build ();
					StartActivity (intent);
					Finish ();

				} else {
					// The Uri cannot be directly opened. Download the PDF document from the uri, for local access.
					// Find the DownloadProgressFragment for showing download progress, or create a new one.
					var downloadFragment = SupportFragmentManager?.FindFragmentByTag (downloadProgressFragment)?.JavaCast<DownloadProgressFragment> ();
					if (downloadFragment == null) {
						var job = DownloadJob.StartDownload (new DownloadRequest.Builder (this).Uri (uri).Build ());
						downloadFragment = new DownloadProgressFragment ();

						// We use a small hack JavaCast<T> because at build time we expect a 'AndroidX.Fragment.App.FragmentManager'
						downloadFragment.Show (SupportFragmentManager.JavaCast<AndroidX.Fragment.App.FragmentManager> (), downloadProgressFragment);
						downloadFragment.Job = job;
					}

					// Once the download is complete we launch the PdfActivity from the downloaded file.
					downloadFragment.Job.Complete += (sender, e) => {
						var intent = PdfActivityIntentBuilder.FromUri (this, Android.Net.Uri.FromFile (e.P0))
															 .Configuration (configuration)
															 .Build ();
						StartActivity (intent);
						Finish ();
					};
				}
			}
		}

		public override void OnRequestPermissionsResult (int requestCode, string [] permissions, Android.Content.PM.Permission [] grantResults)
		{
			base.OnRequestPermissionsResult (requestCode, permissions, grantResults);
			PermissionsImplementation.Current.OnRequestPermissionsResult (requestCode, permissions, grantResults);
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
