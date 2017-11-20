using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace XFSample {
	public partial class XFSamplePage : ContentPage {
		public XFSamplePage ()
		{
			InitializeComponent ();
		}

		async void ShowPDF (object sender, System.EventArgs e)
		{
			// We need storage permission, we can use Permissions Plugin to help here
			var status = await CrossPermissions.Current.CheckPermissionStatusAsync (Permission.Storage);
			if (status != PermissionStatus.Granted) {
				if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync (Permission.Storage))
					await DisplayAlert ("Need Storage Permission", "Need access to store yor PDF documents", "OK");
				
				var results = await CrossPermissions.Current.RequestPermissionsAsync (Permission.Storage);
				//Best practice to always check that the key exists
				if (results.ContainsKey (Permission.Storage))
					status = results [Permission.Storage];
			}

			if (status == PermissionStatus.Granted) {
				
				// Gets pdfService that will allow us to call ShowPdfActivity from MainActivity.cs
				var pdfService = DependencyService.Get<IPdfService> ();
				pdfService.ShowPdfActivity ();
			
			} else if (status != PermissionStatus.Unknown)
				await DisplayAlert ("Storage Permission Denied", "Cannot continue, try again.", "OK");
		}
	}
}
