using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Android.Content;
using AndroidHUD;

using PSPDFKit;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.UI;

using SampleTools;
using Xamarin.Android.Net;

namespace PSPDFCatalog {

	// This is an example showing how to download and show a PDF document from the web.
	public class DocumentDownloadExample : PdfExampleBase {
		HttpClient client = new HttpClient (new AndroidClientHandler ());

		protected override string AssetPath => $"{DateTime.Now.Ticks}.pdf";

		protected override void PrepareConfiguration (PdfActivityConfiguration.Builder configuration) => configuration.Title ("Case Study Box");

		public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			Task.Factory.StartNew (async () => {
				AndHUD.Shared.Show (ctx, $"Downloading file....", cancelCallback: client.CancelPendingRequests);
				PrepareConfiguration (configuration);
				var docUrl = "https://pspdfkit.com/downloads/case-study-box.pdf";
				var docPath = Path.Combine (ctx.CacheDir.ToString (), AssetPath);

				using (var file = new FileStream (docPath, FileMode.Create, FileAccess.Write, FileShare.None))
					await client.DownloadDataAsync (docUrl, file);

				AndHUD.Shared.Dismiss (ctx);

				var jfile = new Java.IO.File (docPath);
				var docUri = Android.Net.Uri.FromFile (jfile);

				// Start the PSPDFKitAppCompat activity by passing it the Uri of the file.
				if (PSPDFKitGlobal.IsOpenableUri (ctx, docUri))
					PdfActivity.ShowDocument (ctx, docUri, configuration.Build ());
				else
					AndHUD.Shared.ShowError (ctx, $"This document uri cannot be opened:\n{docUri}", MaskType.Black, TimeSpan.FromSeconds (2));
			});
		}



	}
}
