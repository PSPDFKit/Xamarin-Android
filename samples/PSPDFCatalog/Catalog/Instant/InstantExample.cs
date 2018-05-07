using System;
using Android.Content;
using PSPDFKit.Configuration.Activity;

namespace PSPDFCatalog {
	public class InstantExample : PdfExampleBase {
		protected override string AssetPath => null;

		public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			// Instant example starts with a simple login/connection screen.
			var intent = new Intent (ctx, typeof (InstantExampleConnectionActivity));

			// Pass the configuration to the connection activity. This configuration will
			// be passed to created InstantPdfActivity with downloaded Instant document.
			intent.PutExtra (InstantExampleConnectionActivity.ConfigurationArg, configuration.Build ());

			ctx.StartActivity (intent);
		}
	}
}
