using System;
using Android.Content;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.UI;
using SampleTools;

namespace PSPDFCatalog {
    public class AnnotationConfigurationExample : PdfExampleBase {
        protected override string AssetPath => demoPdf;

        public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
        {
            // Extract the pdf from assets if not already extracted
            var docUri = Utils.ExtractAsset (ctx, AssetPath);

            var intent = PdfActivityIntentBuilder.FromUri (ctx, docUri)
                                                 .Configuration (configuration.Build ())
                                                 .ActivityClass (Java.Lang.Class.FromType (typeof (AnnotationConfigurationExampleActivity)))
                                                 .Build ();
            ctx.StartActivity(intent);
        }
    }
}
