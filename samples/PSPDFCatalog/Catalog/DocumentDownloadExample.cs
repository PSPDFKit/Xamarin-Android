using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using Android.Content;
using AndroidHUD;

using PSPDFKit;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.UI;

namespace PSPDFCatalog {

	// This is an example showing how to download and show a PDF document from the web.
	public class DocumentDownloadExample : PdfExampleBase {
		protected override string AssetPath => $"{DateTime.Now.Ticks}.pdf";

		protected override void PrepareConfiguration (PdfActivityConfiguration.Builder configuration) => configuration.Title ("Case Study Box");

		public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			Task.Factory.StartNew (async () => {
				using (var wc = new WebClient ()) {
					AndHUD.Shared.Show (ctx, $"Downloading file....", progress: 0, cancelCallback: wc.CancelAsync);
					PrepareConfiguration (configuration);

					var docUrl = "https://pspdfkit.com/downloads/case-study-box.pdf";
					var docPath = Path.Combine (ctx.CacheDir.ToString (), AssetPath);
					wc.DownloadProgressChanged += (sender, e) => AndHUD.Shared.Show (ctx, $"Downloading file....\n{e.ProgressPercentage}%", e.ProgressPercentage);
					wc.DownloadFileCompleted += (sender, e) => AndHUD.Shared.Dismiss (ctx);
					await wc.DownloadFileTaskAsync (docUrl, docPath);
					AndHUD.Shared.Dismiss (ctx);

					var jfile = new Java.IO.File (docPath);
					var docUri = Android.Net.Uri.FromFile (jfile);

					// Start the PSPDFKitAppCompat activity by passing it the Uri of the file.
					if (PSPDFKitGlobal.IsOpenableUri (ctx, docUri))
						PdfActivity.ShowDocument (ctx, docUri, configuration.Build ());
					else
						AndHUD.Shared.ShowError (ctx, $"This document uri cannot be opened:\n{docUri}", MaskType.Black, TimeSpan.FromSeconds (2));
				}
			});
		}

	}
}
