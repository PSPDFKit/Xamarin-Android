using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XFSample {
	public partial class PdfViewerPage : ContentPage {

		public Func<bool> OnBackPressed;

		public PdfViewerPage ()
		{
			InitializeComponent ();
		}

		protected override bool OnBackButtonPressed () => OnBackPressed.Invoke () ? true : base.OnBackButtonPressed ();
	}
}
