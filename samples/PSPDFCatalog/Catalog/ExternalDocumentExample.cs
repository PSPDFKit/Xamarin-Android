using System;
using Android.Content;
using PSPDFKit.Configuration.Activity;

namespace PSPDFCatalog {

	// This example shows how to build an activity that can select and download any document using the correct intents.
	public class ExternalDocumentExample : PdfExampleBase {
		protected override string AssetPath => null;

		public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			// In this example we use a custom activity to build an intent that allows the user to
			// select a document.
			var intent = new Intent (ctx, typeof (ExternalExampleActivity));
			intent.PutExtra (ExternalExampleActivity.ExtraConfiguration, configuration.Build ());
			ctx.StartActivity (intent);
		}
	}
}
