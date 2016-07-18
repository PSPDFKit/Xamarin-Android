using System;
using Android.Runtime;

namespace PSPDFKit.UI.Search {
	public sealed partial class PSPDFSearchViewInline {
		static IntPtr id_isShown;
		public override unsafe bool IsShown {
			[Register ("isShown", "()Z", "GetIsShownHandler")]
			get {
				if (id_isShown == IntPtr.Zero)
					id_isShown = JNIEnv.GetMethodID (class_ref, "isShown", "()Z");
				try {
					return JNIEnv.CallBooleanMethod (Handle, id_isShown);
				}
				finally {
				}
			}
		}
	}
}
