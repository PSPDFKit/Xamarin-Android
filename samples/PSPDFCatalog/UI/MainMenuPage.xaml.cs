using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PSPDFCatalog {

	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class MainMenuPage : ContentPage {

		public event EventHandler<OptionSelectedEventArgs> OptionSelected;

		public MainMenuPage ()
		{
			InitializeComponent ();

			ExamplesListView.ItemsSource = Examples;
			ExamplesListView.ItemSelected += ExamplesListView_ItemSelected;
			ExamplesListView.ItemTapped += ExamplesListView_ItemTapped;
		}

		// Remove highlight from selected item
		void ExamplesListView_ItemSelected (object sender, SelectedItemChangedEventArgs e) => ((ListView) sender).SelectedItem = null;

		void ExamplesListView_ItemTapped (object sender, ItemTappedEventArgs e) => 
		OptionSelected?.Invoke (this, new OptionSelectedEventArgs ((e.Item as Example).ExampleClass));

		public static ObservableCollection<CatalogExamples> Examples = new ObservableCollection<CatalogExamples> {
			new CatalogExamples ("OPENING DOCUMENTS") {
				new Example {
					Name = "Basic Example",
					Description = "Opens the demo document from the assets folder.",
					ExampleClass = typeof (BasicExample)
				},
				new Example {
					Name = "Try Instant",
					Description = "Downloads a document for collaborative editing.",
					ExampleClass = typeof (InstantExample)
				},
				new Example {
					Name = "Fragment Example",
					Description = "Shows how to create an activity using the PdfFragment.",
					ExampleClass = typeof (FragmentExample)
				},
				new Example {
					Name = "Document Download Example",
					Description = "How to download a PDF document from the web.",
					ExampleClass = typeof (DocumentDownloadExample)
				},
				new Example {
					Name = "External Document",
					Description = "Choose a document from the file system.",
					ExampleClass = typeof (ExternalDocumentExample)
				},
				new Example {
					Name = "Custom Data Provider",
					Description = "How to implement a DataProvider that can be used with PdfActivity.",
					ExampleClass = typeof (CustomDataProviderExample)
				},
				new Example {
					Name = "Password Protected PDF",
					Description = "Password is: test123",
					ExampleClass = typeof (PasswordExample)
				},
				new Example {
					Name = "Annotation Configuration",
					Description = "How to customize annotation configuration",
					ExampleClass = typeof (AnnotationConfigurationExample)
				},
			},
			new CatalogExamples ("FORMS") {
				new Example {
					Name = "Form Filling",
					Description = "Shows how to fill forms programmatically.",
					ExampleClass = typeof (FormFillingExample)
				},
				new Example {
					Name = "Custom Form Highlight Color",
					Description = "Shows how to toggle the form highlight color.",
					ExampleClass = typeof (CustomFormHighlightColorExample)
				},
				new Example {
					Name = "Digital Signatures",
					Description = "Showcases digital signing of documents. Certificate password is: test",
					ExampleClass = typeof (DigitalSignatureExample)
				},
			},
		};
	}
}
