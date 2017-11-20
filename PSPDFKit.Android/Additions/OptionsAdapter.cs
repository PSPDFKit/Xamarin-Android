using System;
using Android.Runtime;

namespace PSPDFKit.UI.Inspector.Views {

	public sealed partial class OptionPickerInspectorView {
		public partial class OptionsAdapter : global::Android.Support.V7.Widget.RecyclerView.Adapter {

			static IntPtr id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I;

			[Register ("onBindViewHolder", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V", "")]
			public override sealed unsafe void OnBindViewHolder (global::Android.Support.V7.Widget.RecyclerView.ViewHolder holder, int position)
			{
				if (id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I == IntPtr.Zero)
					id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I = JNIEnv.GetMethodID (class_ref, "onBindViewHolder", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V");
				try {
					JValue* __args = stackalloc JValue[2];
					__args[0] = new JValue (holder);
					__args[1] = new JValue (position);
					JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I, __args);
				} finally {
				}
			}
		}
	}
}
