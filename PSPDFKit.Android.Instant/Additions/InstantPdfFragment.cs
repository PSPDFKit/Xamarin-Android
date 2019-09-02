using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace PSPDFKit.Instant {
	public partial class InstantPdfFragment {
		static Delegate cb_setOverlaidAnnotationTypes_Ljava_util_EnumSet_;
#pragma warning disable 0169
        static Delegate GetSetOverlaidAnnotationTypes_Ljava_util_EnumSet_Handler ()
        {
            if (cb_setOverlaidAnnotationTypes_Ljava_util_EnumSet_ == null)
                cb_setOverlaidAnnotationTypes_Ljava_util_EnumSet_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetOverlaidAnnotationTypes_Ljava_util_EnumSet_);
            return cb_setOverlaidAnnotationTypes_Ljava_util_EnumSet_;
        }

        static void n_SetOverlaidAnnotationTypes_Ljava_util_EnumSet_ (IntPtr jnienv, IntPtr native__this, IntPtr native_overlayAnnotationTypes)
        {
            global::PSPDFKit.Instant.InstantPdfFragment __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.InstantPdfFragment> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Java.Util.EnumSet overlayAnnotationTypes = global::Java.Lang.Object.GetObject<global::Java.Util.EnumSet> (native_overlayAnnotationTypes, JniHandleOwnership.DoNotTransfer);
            __this.SetOverlaidAnnotationTypes (overlayAnnotationTypes);
        }
#pragma warning restore 0169

        [Register ("setOverlaidAnnotationTypes", "(Ljava/util/EnumSet;)V", "GetSetOverlaidAnnotationTypes_Ljava_util_EnumSet_Handler")]
        public unsafe void SetOverlaidAnnotationTypes (global::Java.Util.EnumSet overlayAnnotationTypes)
        {
            const string __id = "setOverlaidAnnotationTypes.(Ljava/util/EnumSet;)V";
            try {
                JniArgumentValue* __args = stackalloc JniArgumentValue [1];
                __args [0] = new JniArgumentValue ((overlayAnnotationTypes == null) ? IntPtr.Zero : ((global::Java.Lang.Object) overlayAnnotationTypes).Handle);
                _members.InstanceMethods.InvokeVirtualVoidMethod (__id, this, __args);
            } finally {
            }
        }
	}
}
