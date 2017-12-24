using System;
using Android.Content;
using SampleTools;

using PSPDFKit.Configuration.Activity;
using PSPDFKit.UI;
using PSPDFKit;
using AndroidHUD;

namespace PSPDFCatalog {

	public interface ILaunchable {
		void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration);
	}

	public abstract class PdfExampleBase : ILaunchable {

		public const string demoPdf = "demo.pdf";

		// The path to the asset that we want to display.
		protected abstract string AssetPath { get; }

		// Allows subclasses to adjust the configuration before displaying the document.
		protected virtual void PrepareConfiguration (PdfActivityConfiguration.Builder configuration)
		{
			
		}

		public virtual void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			// Extract the pdf from assets if not already extracted
			var docUri = Utils.ExtractAsset (ctx, AssetPath);

			PrepareConfiguration (configuration);

			// Start the PSPDFKitAppCompat activity by passing it the Uri of the file.
			if (PSPDFKitGlobal.IsOpenableUri (ctx, docUri))			
				PdfActivity.ShowDocument (ctx, docUri, configuration.Build ());
			else
				AndHUD.Shared.ShowError (ctx, $"This document uri cannot be opened:\n{docUri}", MaskType.Black, TimeSpan.FromSeconds (2));
		}
	}
}

