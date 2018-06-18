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

	// Shows how to create an activity using the PdfFragment
	public class FragmentExample : PdfExampleBase {
		protected override string AssetPath => demoPdf;

		public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			// Load and show the signature example PDF.
			// Extract the pdf from assets if not already extracted
			var docUri = Utils.ExtractAsset (ctx, AssetPath);
			var intent = new Intent (ctx, typeof (CustomFragmentActivity));
			intent.PutExtra (CustomFragmentActivity.ExtraUri, docUri);
                ctx.StartActivity (intent);
		}
	}
}
