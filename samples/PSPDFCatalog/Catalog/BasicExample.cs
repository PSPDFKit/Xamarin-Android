using System;
namespace PSPDFCatalog {

	// Opens the 'PdfActivity' for viewing a PDF stored within the app's asset folder.
	public class BasicExample : PdfExampleBase {
		protected override string AssetPath => demoPdf;
	}
}
