using System;
using Android.Content;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.UI;
using SampleTools;

namespace PSPDFCatalog {

	public class FormFillingExample : PdfExampleBase {
		protected override string AssetPath => "Form_example.pdf";

		protected override void PrepareConfiguration (PdfActivityConfiguration.Builder configuration)
		{
			// Turn off saving, so we have the clean original document every time the example is launched.
			configuration
				.AutosaveEnabled (false)
				.EnableFormEditing ();
		}

		public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			PrepareConfiguration (configuration);

			// Extract the pdf from assets if not already extracted
			var docUri = Utils.ExtractAsset (ctx, AssetPath);

			var intent = PdfActivityIntentBuilder.FromUri (ctx, docUri)
												 .Configuration (configuration.Build ())
			                                     .ActivityClass (Java.Lang.Class.FromType (typeof (FormFillingActivity)))
												 .Build ();
			ctx.StartActivity (intent);
		}
	}
}
