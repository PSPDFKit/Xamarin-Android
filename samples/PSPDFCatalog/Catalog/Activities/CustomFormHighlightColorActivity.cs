using System;

using Android.App;
using Android.Graphics;
using AndroidX.Core.Content;
using AndroidX.Core.Graphics.Drawable;
using Android.Views;

using PSPDFKit.Configuration.Activity;
using PSPDFKit.UI;

namespace PSPDFCatalog {
	[Activity (Label = "Custom Form Highlight Color", WindowSoftInputMode = SoftInput.AdjustNothing)]
	public class CustomFormHighlightColorActivity : PdfActivity {

		const int toggleFormHighlightColorMenuItemId = 1;

		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			base.OnPrepareOptionsMenu (menu);
			var menuItem = menu.Add (0, toggleFormHighlightColorMenuItemId, 0, "Toggle highlight color");
			menuItem.SetShowAsAction (ShowAsAction.Always);

			var tintedDrawable = DrawableCompat.Wrap (ContextCompat.GetDrawable (this, Resource.Drawable.pspdf__ic_highlight));
			DrawableCompat.SetTint (tintedDrawable, Color.White);
			menuItem.SetIcon (tintedDrawable);

			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == toggleFormHighlightColorMenuItemId) {
				ToggleFormHighlightColor ();
				return true;
			}
			return base.OnOptionsItemSelected (item);
		}

		// Toggles form highlight color between transparent color and highlight color set in the theme.
		void ToggleFormHighlightColor ()
		{
			if (Configuration.Theme == PdfActivityConfiguration.NoTheme)
				Configuration = new PdfActivityConfiguration.Builder (Configuration).Theme (Resource.Style.PSPDFCatalog_Theme_FormSelectionNoHighlight).Build ();
			else
				Configuration = new PdfActivityConfiguration.Builder (Configuration).Theme (PdfActivityConfiguration.NoTheme).Build ();
		}
	}
}
