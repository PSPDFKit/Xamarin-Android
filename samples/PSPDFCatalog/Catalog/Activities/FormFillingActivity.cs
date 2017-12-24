using System.Collections.Generic;
using System.Threading.Tasks;

using Android.App;
using Android.Runtime;
using Android.Views;

using PSPDFKit.Document;
using PSPDFKit.Forms;
using PSPDFKit.UI;

namespace PSPDFCatalog {

	// This activity shows how to programmatically fill document forms.
	[Activity (Label = "Form Filling", WindowSoftInputMode = SoftInput.AdjustNothing)]
	public class FormFillingActivity : PdfActivity {

		const int resetFormMenuItemId = 1;
		const int fillByFieldName = 2;

		public override void OnDocumentLoaded (PdfDocument document)
		{
			base.OnDocumentLoaded (document);
			FillAllFormFields ();
		}

		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			base.OnPrepareOptionsMenu (menu);
			menu.Add (0, resetFormMenuItemId, 0, "Reset form");
			menu.Add (0, fillByFieldName, 0, "Fill by field name");
			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (item.ItemId == resetFormMenuItemId) {
				ResetForm ();
				return true;
			} else if (item.ItemId == fillByFieldName) {
				FillByName ();
				return true;
			} else
				return base.OnOptionsItemSelected (item);
		}

		// Fills form fields in the document with text "Example <field name>".
		void FillAllFormFields ()
		{
			if (Document == null) return;

			Task.Factory.StartNew (() => {
				var elements = Document.FormProvider.FormElements;
				if (elements == null) return;

				foreach (var element in elements) {
					if (element.Type == FormType.Text)
						element.JavaCast<TextFormElement> ().Text = $"Example {element.Name}";
					else if (element.Type == FormType.Checkbox)
						element.JavaCast<CheckBoxFormElement> ().ToggleSelection ();
				}
			});
		}

		// Resets all form fields in the document to their default values.
		void ResetForm ()
		{
			if (Document == null) return;

			Task.Factory.StartNew (() => {
				var fields = Document.FormProvider.FormFields;
				if (fields == null) return;

				foreach (var field in fields)
					field.Reset ();
			});
		}

		// Shows how to query form fields/elements by their name.
		void FillByName ()
		{
			if (Document == null) return;

			// Form fields can be queried by their fully qualified name.
			// Each form field can have multiple child form elements that are
			// the widget annotations that are visually representing actionable
			// controls inside the form field.
			Task.Factory.StartNew (() => {
				var field = Document.FormProvider.GetFormFieldWithFullyQualifiedName ("Sex");
				var formElement = field.JavaCast<RadioButtonFormField> ();

				// Sex radio button field has 2 child form elements. These are representing 2 radio buttons in the radio group.

				// First radio element has the name "Sex.0" and represents the MALE option.
				//      'formElement.FormElements [0];'

				// Second radio element has name "Sex.1" and represents the FEMALE option.
				//      'formElement.FormElements [1];'

				// Select the MALE radio option.
				formElement.FormElements [0].JavaCast<RadioButtonFormElement> ().Select ();
			});

			// Form elements (visible portion of the form field) can be queried by their name and filled that way.
			Task.Factory.StartNew (() => {
				var field = Document.FormProvider.GetFormElementWithName ("Name_Last");
				var formElement = field.JavaCast<TextFormElement> ();
				formElement.Text = "John";
			});

			Task.Factory.StartNew (() => {
				var field = Document.FormProvider.GetFormElementWithName ("Name_First");
				var formElement = field.JavaCast<TextFormElement> ();
				formElement.Text = "Appleseed";
			});

			// Querying form elements by name can be slow. If you need to fill many form
			// elements at once, retrieve list of all form fields/elements first and iterate through it.
			Task.Factory.StartNew (() => {
				var elements = Document.FormProvider.FormElements;
				var dict = new Dictionary<string, string> {
					{"Address_1", "7440-7498 S Hanna St."},
					{"Address_2", string.Empty},
					{"City", "Fort Wayne"},
					{"STATE", "IN"},
					{"ZIP", "46774"}
				};
				foreach (var element in elements) {
					if (element.Type != FormType.Text)
						continue;

					var textFormElement = element.JavaCast<TextFormElement> ();
					if (dict.TryGetValue (textFormElement.Name, out string val))
						textFormElement.Text = val;
				}
			});
		}
	}
}
