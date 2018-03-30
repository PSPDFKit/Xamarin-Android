using System;
using Android.Runtime;
using PSPDFKit.Document;

namespace PSPDFKit.Instant {
	public sealed partial class InstantPdfDocument : PdfDocument {

		static IntPtr id_setAutomaticLinkGenerationEnabled_Z;
		public override unsafe bool AutomaticLinkGenerationEnabled {
			get {
				return base.AutomaticLinkGenerationEnabled;
			}
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/class[@name='InstantPdfDocument']/method[@name='setAutomaticLinkGenerationEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setAutomaticLinkGenerationEnabled", "(Z)V", "")]
			set {
				if (id_setAutomaticLinkGenerationEnabled_Z == IntPtr.Zero)
					id_setAutomaticLinkGenerationEnabled_Z = JNIEnv.GetMethodID (class_ref, "setAutomaticLinkGenerationEnabled", "(Z)V");
				try {
					JValue* __args = stackalloc JValue[1];
					__args[0] = new JValue (value);
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAutomaticLinkGenerationEnabled_Z, __args);
				} finally {
				}
			}
		}
	}
}
