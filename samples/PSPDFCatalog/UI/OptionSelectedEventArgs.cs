using System;
namespace PSPDFCatalog {
	public class OptionSelectedEventArgs : EventArgs {
		public Type SampleClass { get; private set; }
		public OptionSelectedEventArgs (Type sampleClass) => SampleClass = sampleClass;
	}
}
