using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFSample {
	public partial class XFSamplePage : ContentPage {
		public XFSamplePage ()
		{
			InitializeComponent ();
		}

		async void ShowPDF (object sender, System.EventArgs e)
		{
			var status = await AskPermission ();
			if (status == PermissionStatus.Granted) {
				
				// Gets pdfService that will allow us to call ShowPdfActivity from MainActivity.cs
				var pdfService = DependencyService.Get<IPdfService> ();
				pdfService.ShowPdfActivity ();
			
			} else
				await DisplayAlert ("Storage Permission Denied", "Cannot continue, try again.", "OK");
		}

		async void ShowPDFFragment (object sender, System.EventArgs e)
		{
			var status = await AskPermission ();
			if (status == PermissionStatus.Granted)
				await Navigation.PushModalAsync (new PdfViewerPage ());
			else
				await DisplayAlert ("Storage Permission Denied", "Cannot continue, try again.", "OK");
		}

		async Task<PermissionStatus> AskPermission ()
		{

			if (DeviceInfo.Platform == DevicePlatform.Android && DeviceInfo.Version.Major >= 13)
				return PermissionStatus.Granted;

			var sRead = await Permissions.CheckStatusAsync<Permissions.StorageRead> ();
			if (sRead != PermissionStatus.Granted)
				sRead = await Permissions.RequestAsync<Permissions.StorageRead> ();

			return sRead;
		}
	}
}
