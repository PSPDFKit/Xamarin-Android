using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Views.InputMethods;
using AndroidHUD;
using PSPDFKit.Configuration.Activity;
using PSPDFKit.Instant;

namespace PSPDFCatalog {
	// Allows to connect to the example Instant server.
	[Activity (Label = "Try Instant", WindowSoftInputMode = SoftInput.AdjustResize, Theme = "@style/PSPDFCatalog.Theme.Light")]
	public class InstantExampleConnectionActivity : AppCompatActivity {
		// Name of the extra in activity intent holding 'PdfActivityConfiguration' that should be passed to created 'InstantPdfActivity'.
		public static string ConfigurationArg = "InstantExampleConnectionActivity.PSPDFKitConfiguration";

		// Configuration that will be passed to created 'InstantExampleActivity'.
		PdfActivityConfiguration configuration;

		// Edit box for entering document code of an existing editing group.
		Android.Widget.EditText documentCodeEditText;

		// Interfaces with our web-preview server to create and access documents.
		// In your own app you would connect to your own server backend to get Instant document identifiers and authentication tokens.
		WebPreviewApiClient apiClient = new WebPreviewApiClient ();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.TryInstantConnect);

			// Extract PdfActivity configuration from extras.
			configuration = Intent.GetParcelableExtra (ConfigurationArg).JavaCast<PdfActivityConfiguration> ();
			if (configuration is null)
				throw new InvalidOperationException ("'InstantExampleConnectionActivity' was not initialized with proper arguments: Missing configuration extra!");

			// Configure toolbar.
			var toolbar = FindViewById<Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);

			// Configure new document button.
			var documentButton = FindViewById<Android.Widget.Button> (Resource.Id.button_new_document);
			documentButton.Click += async (sender, e) => await CreateNewDocument ();

			// Configure edit document button.
			var editDocumentButton = FindViewById<Android.Widget.Button> (Resource.Id.button_edit_document);
			editDocumentButton.Enabled = false;
			editDocumentButton.Click += async (sender, e) => await EditDocument (documentCodeEditText.Text);

			// Configure document code edit box.
			documentCodeEditText = FindViewById<Android.Widget.EditText> (Resource.Id.edit_text_document_code);
			documentCodeEditText.EditorAction += async (sender, e) => {
				if (e.ActionId == ImeAction.Go && (e.Event == null || e.Event?.Action == KeyEventActions.Up)) {
					await EditDocument (documentCodeEditText.Text);
					e.Handled = true;
				}
				e.Handled = false;
			};

			documentCodeEditText.AfterTextChanged += (sender, e) => {
				var code = (sender as Android.Widget.EditText).Text;
				editDocumentButton.Enabled = code?.Length == WebPreviewApiClient.CodeLength;
			};
		}

		async Task CreateNewDocument ()
		{
			AndHUD.Shared.Show (this, $"Creating...");
			documentCodeEditText.Enabled = false;
			try {
				var documentInfo = await apiClient.CreateNewDocument ();
				AndHUD.Shared.Dismiss ();
				documentCodeEditText.Enabled = true;
				ShowInstantDocument (documentInfo);
			} catch {
				// Catch an exception here
				AndHUD.Shared.Dismiss ();
				documentCodeEditText.Enabled = true;
				AndHUD.Shared.ShowToast (this, "Something went wrong.", timeout: TimeSpan.FromSeconds (1), centered: false);
			}
		}

		async Task EditDocument (string code)
		{
			if (documentCodeEditText == null)
				return;

			AndHUD.Shared.Show (this, $"Connecting...");
			documentCodeEditText.Enabled = false;
			try {
				var documentInfo = await apiClient.ResolveDocument (code);
				AndHUD.Shared.Dismiss ();
				documentCodeEditText.Enabled = true;
				ShowInstantDocument (documentInfo);
			} catch {
				// Catch an exception here
				AndHUD.Shared.Dismiss ();
				documentCodeEditText.Enabled = true;
				AndHUD.Shared.ShowToast (this, "Invalid Code.", timeout: TimeSpan.FromSeconds (1), centered: false);
			}
		}

		void ShowInstantDocument (InstantDocumentInfo documentInfo)
		{
			InstantClient.Create (this, documentInfo.ServerUrl).RemoveLocalStorage ();
			var builder = InstantPdfActivityIntentBuilder.FromInstantDocument (this, documentInfo.ServerUrl, documentInfo.Jwt);
			var intent = builder
				.Configuration (configuration)
				.ActivityClass (Java.Lang.Class.FromType (typeof (InstantExampleActivity)))
				.Build ();
			intent.PutExtra (InstantExampleActivity.DocumentDescriptor, documentInfo.ToJson ());
			StartActivity (intent);
			Finish ();
		}
	}
}
