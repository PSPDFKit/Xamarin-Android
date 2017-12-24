using System;
using System.Collections.ObjectModel;

namespace PSPDFCatalog {

	public class CatalogExamples : ObservableCollection<Example> {
		public CatalogExamples (string categoryName) => CategoryName = categoryName;
		public string CategoryName { get; set; }
	}

	public class Example {
		public string Name { get; set; }
		public string Description { get; set; }
		public Type ExampleClass { get; set; }
	}
}
