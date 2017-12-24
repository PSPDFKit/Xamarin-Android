using System;

using Android.Content;
using Android.Runtime;
using AndroidHUD;
using Java.Security.Cert;

using PSPDFKit.Configuration.Activity;
using PSPDFKit.Signatures;
using PSPDFKit.Signatures.Signers;
using PSPDFKit.UI;

using SampleTools;

namespace PSPDFCatalog {
	public class DigitalSignatureExample : PdfExampleBase {
		protected override string AssetPath => "Form_example.pdf";

		public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			// Our test certificate is self-signed, so we need to add it to trusted certificate store for it to validate. Otherwise
			// the new signature won't validate. Since PSPDFKit and other readers (like Acrobat) will warn when using self-signed certificates
			// your app should use a CA issued certificate instead.
			AddJohnAppleseedCertificateToTrustedCertificates (ctx);

			// The signer is a named entity holding a certificate (usually a person) and has a display name shown in the app. Registration of the Signer instance
			// has to happen using a unique string identifier. The signer can be associated with a signature for signing the document.
			var johnAppleseed = new Pkcs12Signer ("John Appleseed", Android.Net.Uri.Parse ("file:///android_asset/JohnAppleseed.p12"));
			SignatureManager.AddSigner ("john_appleseed", johnAppleseed);

			// Load and show the signature example PDF.
			// Extract the pdf from assets if not already extracted
			var docUri = Utils.ExtractAsset (ctx, AssetPath);

			var intent = PdfActivityIntentBuilder.FromUri (ctx, docUri)
												 .Configuration (configuration.Build ())
												 .Build ();
			ctx.StartActivity (intent);
		}

		void AddJohnAppleseedCertificateToTrustedCertificates (Context ctx)
		{
			try {
				var keystoreFile = ctx.Assets.Open ("JohnAppleseed.p12");

				// Inside a p12 we have both the certificate and private key used for signing. We just need the certificate here.
				// Proper signatures should have a root CA approved certificate making this step unnecessary.
				var key = SignatureManager.LoadPrivateKeyPairFromStream (keystoreFile, "test", null, null);
				if (key.Certificate.Type == "X.509")
					SignatureManager.AddTrustedCertificate (key.Certificate.JavaCast<X509Certificate> ());
			} catch {
				AndHUD.Shared.ShowError (ctx, "Couldn't load and add John Appleseed certificate to trusted certificate list!", timeout: TimeSpan.FromSeconds (2));
			}
		}
	}
}
