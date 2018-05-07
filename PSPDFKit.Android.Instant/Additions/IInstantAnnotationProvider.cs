using System;
using System.Collections.Generic;
using System.Linq;
using Android.Runtime;

namespace PSPDFKit.Instant.Annotations {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.pspdfkit.instant.annotations']/interface[@name='InstantAnnotationProvider']"
	[Register ("com/pspdfkit/instant/annotations/InstantAnnotationProvider", "", "PSPDFKit.Instant.Annotations.IInstantAnnotationProviderInvoker")]
	public partial interface IInstantAnnotationProvider : global::PSPDFKit.Annotations.IAnnotationProvider {

		bool HasUnsavedChanges {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.annotations']/interface[@name='InstantAnnotationProvider']/method[@name='hasUnsavedChanges' and count(parameter)=0]"
			[Register ("hasUnsavedChanges", "()Z", "GetHasUnsavedChangesHandler:PSPDFKit.Instant.Annotations.IInstantAnnotationProviderInvoker, PSPDFKit.Android.Instant")]
			get;
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.annotations']/interface[@name='InstantAnnotationProvider']/method[@name='getAnnotationForIdentifier' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("getAnnotationForIdentifier", "(Ljava/lang/String;)Lcom/pspdfkit/annotations/Annotation;", "GetGetAnnotationForIdentifier_Ljava_lang_String_Handler:PSPDFKit.Instant.Annotations.IInstantAnnotationProviderInvoker, PSPDFKit.Android.Instant")]
		global::PSPDFKit.Annotations.Annotation GetAnnotationForIdentifier (string p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.annotations']/interface[@name='InstantAnnotationProvider']/method[@name='getIdentifierForAnnotation' and count(parameter)=1 and parameter[1][@type='com.pspdfkit.annotations.Annotation']]"
		[Register ("getIdentifierForAnnotation", "(Lcom/pspdfkit/annotations/Annotation;)Ljava/lang/String;", "GetGetIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_Handler:PSPDFKit.Instant.Annotations.IInstantAnnotationProviderInvoker, PSPDFKit.Android.Instant")]
		string GetIdentifierForAnnotation (global::PSPDFKit.Annotations.Annotation p0);

	}

	[global::Android.Runtime.Register ("com/pspdfkit/instant/annotations/InstantAnnotationProvider", DoNotGenerateAcw = true)]
	internal class IInstantAnnotationProviderInvoker : global::Java.Lang.Object, IInstantAnnotationProvider {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/pspdfkit/instant/annotations/InstantAnnotationProvider");

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IInstantAnnotationProviderInvoker); }
		}

		IntPtr class_ref;

		public static IInstantAnnotationProvider GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IInstantAnnotationProvider> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.pspdfkit.instant.annotations.InstantAnnotationProvider"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IInstantAnnotationProviderInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_hasUnsavedChanges;
#pragma warning disable 0169
		static Delegate GetHasUnsavedChangesHandler ()
		{
			if (cb_hasUnsavedChanges == null)
				cb_hasUnsavedChanges = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_HasUnsavedChanges);
			return cb_hasUnsavedChanges;
		}

		static bool n_HasUnsavedChanges (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.HasUnsavedChanges;
		}
#pragma warning restore 0169

		IntPtr id_hasUnsavedChanges;
		public unsafe bool HasUnsavedChanges {
			get {
				if (id_hasUnsavedChanges == IntPtr.Zero)
					id_hasUnsavedChanges = JNIEnv.GetMethodID (class_ref, "hasUnsavedChanges", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasUnsavedChanges);
			}
		}

		static Delegate cb_getAnnotationForIdentifier_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGetAnnotationForIdentifier_Ljava_lang_String_Handler ()
		{
			if (cb_getAnnotationForIdentifier_Ljava_lang_String_ == null)
				cb_getAnnotationForIdentifier_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetAnnotationForIdentifier_Ljava_lang_String_);
			return cb_getAnnotationForIdentifier_Ljava_lang_String_;
		}

		static IntPtr n_GetAnnotationForIdentifier_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetAnnotationForIdentifier (p0));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getAnnotationForIdentifier_Ljava_lang_String_;
		public unsafe global::PSPDFKit.Annotations.Annotation GetAnnotationForIdentifier (string p0)
		{
			if (id_getAnnotationForIdentifier_Ljava_lang_String_ == IntPtr.Zero)
				id_getAnnotationForIdentifier_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getAnnotationForIdentifier", "(Ljava/lang/String;)Lcom/pspdfkit/annotations/Annotation;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (native_p0);
			global::PSPDFKit.Annotations.Annotation __ret = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnotationForIdentifier_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p0);
			return __ret;
		}

		static Delegate cb_getIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_;
#pragma warning disable 0169
		static Delegate GetGetIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_Handler ()
		{
			if (cb_getIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_ == null)
				cb_getIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_);
			return cb_getIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_;
		}

		static IntPtr n_GetIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Annotation p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.NewString (__this.GetIdentifierForAnnotation (p0));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_;
		public unsafe string GetIdentifierForAnnotation (global::PSPDFKit.Annotations.Annotation p0)
		{
			if (id_getIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_ == IntPtr.Zero)
				id_getIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_ = JNIEnv.GetMethodID (class_ref, "getIdentifierForAnnotation", "(Lcom/pspdfkit/annotations/Annotation;)Ljava/lang/String;");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			string __ret = JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getIdentifierForAnnotation_Lcom_pspdfkit_annotations_Annotation_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

		static Delegate cb_isDirty;
#pragma warning disable 0169
		static Delegate GetIsDirtyHandler ()
		{
			if (cb_isDirty == null)
				cb_isDirty = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsDirty);
			return cb_isDirty;
		}

		static bool n_IsDirty (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsDirty;
		}
#pragma warning restore 0169

		IntPtr id_isDirty;
		public unsafe global::System.Boolean IsDirty {
			get {
				if (id_isDirty == IntPtr.Zero)
					id_isDirty = JNIEnv.GetMethodID (class_ref, "isDirty", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isDirty);
			}
		}

		static Delegate cb_addAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_;
#pragma warning disable 0169
		static Delegate GetAddAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_Handler ()
		{
			if (cb_addAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_ == null)
				cb_addAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_AddAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_);
			return cb_addAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_;
		}

		static void n_AddAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Annotation p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddAnnotationToPage (p0);
		}
#pragma warning restore 0169

		IntPtr id_addAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_;
		public unsafe void AddAnnotationToPage (global::PSPDFKit.Annotations.Annotation p0)
		{
			if (id_addAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_ == IntPtr.Zero)
				id_addAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_ = JNIEnv.GetMethodID (class_ref, "addAnnotationToPage", "(Lcom/pspdfkit/annotations/Annotation;)V");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addAnnotationToPage_Lcom_pspdfkit_annotations_Annotation_, __args);
		}

		static Delegate cb_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_;
#pragma warning disable 0169
		static Delegate GetAddAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Handler ()
		{
			if (cb_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ == null)
				cb_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_AddAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_);
			return cb_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_;
		}

		static void n_AddAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator p0 = (global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator) global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddAppearanceStreamGenerator (p0);
		}
#pragma warning restore 0169

		IntPtr id_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_;
		public unsafe void AddAppearanceStreamGenerator (global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator p0)
		{
			if (id_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ == IntPtr.Zero)
				id_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ = JNIEnv.GetMethodID (class_ref, "addAppearanceStreamGenerator", "(Lcom/pspdfkit/annotations/appearance/AppearanceStreamGenerator;)V");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_, __args);
		}

		static Delegate cb_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z;
#pragma warning disable 0169
		static Delegate GetAddAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ZHandler ()
		{
			if (cb_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z == null)
				cb_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, bool>) n_AddAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z);
			return cb_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z;
		}

		static void n_AddAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator p0 = (global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator) global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddAppearanceStreamGenerator (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z;
		public unsafe void AddAppearanceStreamGenerator (global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator p0, bool p1)
		{
			if (id_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z == IntPtr.Zero)
				id_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z = JNIEnv.GetMethodID (class_ref, "addAppearanceStreamGenerator", "(Lcom/pspdfkit/annotations/appearance/AppearanceStreamGenerator;Z)V");
			JValue* __args = stackalloc JValue[2];
			__args[0] = new JValue (p0);
			__args[1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Z, __args);
		}

		static Delegate cb_addOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_;
#pragma warning disable 0169
		static Delegate GetAddOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_Handler ()
		{
			if (cb_addOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ == null)
				cb_addOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_AddOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_);
			return cb_addOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_;
		}

		static void n_AddOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.IAnnotationProviderOnAnnotationUpdatedListener p0 = (global::PSPDFKit.Annotations.IAnnotationProviderOnAnnotationUpdatedListener) global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.IAnnotationProviderOnAnnotationUpdatedListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddOnAnnotationUpdatedListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_addOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_;
		public unsafe void AddOnAnnotationUpdatedListener (global::PSPDFKit.Annotations.IAnnotationProviderOnAnnotationUpdatedListener p0)
		{
			if (id_addOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ == IntPtr.Zero)
				id_addOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ = JNIEnv.GetMethodID (class_ref, "addOnAnnotationUpdatedListener", "(Lcom/pspdfkit/annotations/AnnotationProvider$OnAnnotationUpdatedListener;)V");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_, __args);
		}

		static Delegate cb_appendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_;
#pragma warning disable 0169
		static Delegate GetAppendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_Handler ()
		{
			if (cb_appendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_ == null)
				cb_appendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_AppendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_);
			return cb_appendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_;
		}

		static void n_AppendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Annotation p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Note.AnnotationStateChange p1 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Note.AnnotationStateChange> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AppendAnnotationState (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_appendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_;
		public unsafe void AppendAnnotationState (global::PSPDFKit.Annotations.Annotation p0, global::PSPDFKit.Annotations.Note.AnnotationStateChange p1)
		{
			if (id_appendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_ == IntPtr.Zero)
				id_appendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_ = JNIEnv.GetMethodID (class_ref, "appendAnnotationState", "(Lcom/pspdfkit/annotations/Annotation;Lcom/pspdfkit/annotations/note/AnnotationStateChange;)V");
			JValue* __args = stackalloc JValue[2];
			__args[0] = new JValue (p0);
			__args[1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_appendAnnotationState_Lcom_pspdfkit_annotations_Annotation_Lcom_pspdfkit_annotations_note_AnnotationStateChange_, __args);
		}

		static Delegate cb_clearDirty;
#pragma warning disable 0169
		static Delegate GetClearDirtyHandler ()
		{
			if (cb_clearDirty == null)
				cb_clearDirty = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ClearDirty);
			return cb_clearDirty;
		}

		static void n_ClearDirty (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ClearDirty ();
		}
#pragma warning restore 0169

		IntPtr id_clearDirty;
		public unsafe void ClearDirty ()
		{
			if (id_clearDirty == IntPtr.Zero)
				id_clearDirty = JNIEnv.GetMethodID (class_ref, "clearDirty", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearDirty);
		}

		static Delegate cb_createAnnotationFromInstantJson_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetCreateAnnotationFromInstantJson_Ljava_lang_String_Handler ()
		{
			if (cb_createAnnotationFromInstantJson_Ljava_lang_String_ == null)
				cb_createAnnotationFromInstantJson_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_CreateAnnotationFromInstantJson_Ljava_lang_String_);
			return cb_createAnnotationFromInstantJson_Ljava_lang_String_;
		}

		static IntPtr n_CreateAnnotationFromInstantJson_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.CreateAnnotationFromInstantJson (p0));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_createAnnotationFromInstantJson_Ljava_lang_String_;
		public unsafe global::PSPDFKit.Annotations.Annotation CreateAnnotationFromInstantJson (string p0)
		{
			if (id_createAnnotationFromInstantJson_Ljava_lang_String_ == IntPtr.Zero)
				id_createAnnotationFromInstantJson_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "createAnnotationFromInstantJson", "(Ljava/lang/String;)Lcom/pspdfkit/annotations/Annotation;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (native_p0);
			global::PSPDFKit.Annotations.Annotation __ret = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_createAnnotationFromInstantJson_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p0);
			return __ret;
		}

		static Delegate cb_getAnnotation_II;
#pragma warning disable 0169
		static Delegate GetGetAnnotation_IIHandler ()
		{
			if (cb_getAnnotation_II == null)
				cb_getAnnotation_II = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, IntPtr>) n_GetAnnotation_II);
			return cb_getAnnotation_II;
		}

		static IntPtr n_GetAnnotation_II (IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.GetAnnotation (p0, p1));
		}
#pragma warning restore 0169

		IntPtr id_getAnnotation_II;
		public unsafe global::PSPDFKit.Annotations.Annotation GetAnnotation (int p0, int p1)
		{
			if (id_getAnnotation_II == IntPtr.Zero)
				id_getAnnotation_II = JNIEnv.GetMethodID (class_ref, "getAnnotation", "(II)Lcom/pspdfkit/annotations/Annotation;");
			JValue* __args = stackalloc JValue[2];
			__args[0] = new JValue (p0);
			__args[1] = new JValue (p1);
			return global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnotation_II, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_getAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_;
#pragma warning disable 0169
		static Delegate GetGetAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_Handler ()
		{
			if (cb_getAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ == null)
				cb_getAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_);
			return cb_getAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_;
		}

		static IntPtr n_GetAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Annotation p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = global::Android.Runtime.JavaList.ToLocalJniHandle (__this.GetAnnotationReplies (p0).Cast<global::PSPDFKit.Annotations.Annotation> ().ToList ());
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_;
		public unsafe global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Annotation> GetAnnotationReplies (global::PSPDFKit.Annotations.Annotation p0)
		{
			if (id_getAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ == IntPtr.Zero)
				id_getAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ = JNIEnv.GetMethodID (class_ref, "getAnnotationReplies", "(Lcom/pspdfkit/annotations/Annotation;)Ljava/util/List;");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Annotation> __ret = (global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Annotation>) global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

		static Delegate cb_getAnnotations_I;
#pragma warning disable 0169
		static Delegate GetGetAnnotations_IHandler ()
		{
			if (cb_getAnnotations_I == null)
				cb_getAnnotations_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetAnnotations_I);
			return cb_getAnnotations_I;
		}

		static IntPtr n_GetAnnotations_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList.ToLocalJniHandle (__this.GetAnnotations (p0).Cast<global::PSPDFKit.Annotations.Annotation> ().ToList ());
		}
#pragma warning restore 0169

		IntPtr id_getAnnotations_I;
		public unsafe global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Annotation> GetAnnotations (int p0)
		{
			if (id_getAnnotations_I == IntPtr.Zero)
				id_getAnnotations_I = JNIEnv.GetMethodID (class_ref, "getAnnotations", "(I)Ljava/util/List;");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			return global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnotations_I, __args), JniHandleOwnership.TransferLocalRef).Cast<global::PSPDFKit.Annotations.Annotation> ().ToList ();
		}

		static Delegate cb_getAnnotations_Ljava_util_Collection_;
#pragma warning disable 0169
		static Delegate GetGetAnnotations_Ljava_util_Collection_Handler ()
		{
			if (cb_getAnnotations_Ljava_util_Collection_ == null)
				cb_getAnnotations_Ljava_util_Collection_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetAnnotations_Ljava_util_Collection_);
			return cb_getAnnotations_Ljava_util_Collection_;
		}

		static IntPtr n_GetAnnotations_Ljava_util_Collection_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Annotations.IAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.IAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var p0 = global::Android.Runtime.JavaCollection<global::Java.Lang.Integer>.FromJniHandle (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = global::Android.Runtime.JavaList<global::PSPDFKit.Annotations.Annotation>.ToLocalJniHandle (__this.GetAnnotations (p0));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getAnnotations_Ljava_util_Collection_;
		public unsafe global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Annotation> GetAnnotations (global::System.Collections.Generic.ICollection<global::Java.Lang.Integer> p0)
		{
			if (id_getAnnotations_Ljava_util_Collection_ == IntPtr.Zero)
				id_getAnnotations_Ljava_util_Collection_ = JNIEnv.GetMethodID (class_ref, "getAnnotations", "(Ljava/util/Collection;)Ljava/util/List;");
			IntPtr native_p0 = global::Android.Runtime.JavaCollection<global::Java.Lang.Integer>.ToLocalJniHandle (p0);
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (native_p0);
			global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Annotation> __ret = global::Android.Runtime.JavaList<global::PSPDFKit.Annotations.Annotation>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnotations_Ljava_util_Collection_, __args), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p0);
			return __ret;
		}

		static Delegate cb_getFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_;
#pragma warning disable 0169
		static Delegate GetGetFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_Handler ()
		{
			if (cb_getFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ == null)
				cb_getFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_);
			return cb_getFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_;
		}

		static IntPtr n_GetFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Annotation p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = global::Android.Runtime.JavaList.ToLocalJniHandle (__this.GetFlattenedAnnotationReplies (p0).Cast<global::PSPDFKit.Annotations.Annotation> ().ToList ());
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_;
		public unsafe global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Annotation> GetFlattenedAnnotationReplies (global::PSPDFKit.Annotations.Annotation p0)
		{
			if (id_getFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ == IntPtr.Zero)
				id_getFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_ = JNIEnv.GetMethodID (class_ref, "getFlattenedAnnotationReplies", "(Lcom/pspdfkit/annotations/Annotation;)Ljava/util/List;");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Annotation> __ret = global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFlattenedAnnotationReplies_Lcom_pspdfkit_annotations_Annotation_, __args), JniHandleOwnership.TransferLocalRef).Cast<global::PSPDFKit.Annotations.Annotation> ().ToList ();
			return __ret;
		}

		static Delegate cb_getReviewHistory_Lcom_pspdfkit_annotations_Annotation_;
#pragma warning disable 0169
		static Delegate GetGetReviewHistory_Lcom_pspdfkit_annotations_Annotation_Handler ()
		{
			if (cb_getReviewHistory_Lcom_pspdfkit_annotations_Annotation_ == null)
				cb_getReviewHistory_Lcom_pspdfkit_annotations_Annotation_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_GetReviewHistory_Lcom_pspdfkit_annotations_Annotation_);
			return cb_getReviewHistory_Lcom_pspdfkit_annotations_Annotation_;
		}

		static IntPtr n_GetReviewHistory_Lcom_pspdfkit_annotations_Annotation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Annotation p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = global::Android.Runtime.JavaList.ToLocalJniHandle (__this.GetReviewHistory (p0).Cast<global::PSPDFKit.Annotations.Note.AnnotationStateChange> ().ToList ());
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getReviewHistory_Lcom_pspdfkit_annotations_Annotation_;
		public unsafe global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Note.AnnotationStateChange> GetReviewHistory (global::PSPDFKit.Annotations.Annotation p0)
		{
			if (id_getReviewHistory_Lcom_pspdfkit_annotations_Annotation_ == IntPtr.Zero)
				id_getReviewHistory_Lcom_pspdfkit_annotations_Annotation_ = JNIEnv.GetMethodID (class_ref, "getReviewHistory", "(Lcom/pspdfkit/annotations/Annotation;)Ljava/util/List;");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			global::System.Collections.Generic.IList<global::PSPDFKit.Annotations.Note.AnnotationStateChange> __ret = global::Android.Runtime.JavaList.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getReviewHistory_Lcom_pspdfkit_annotations_Annotation_, __args), JniHandleOwnership.TransferLocalRef).Cast<global::PSPDFKit.Annotations.Note.AnnotationStateChange> ().ToList ();
			return __ret;
		}

		static Delegate cb_getReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetGetReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_Handler ()
		{
			if (cb_getReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_ == null)
				cb_getReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_);
			return cb_getReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_;
		}

		static IntPtr n_GetReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Annotation p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (native_p0, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetReviewSummary (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_;
		public unsafe global::PSPDFKit.Annotations.Note.AnnotationReviewSummary GetReviewSummary (global::PSPDFKit.Annotations.Annotation p0, string p1)
		{
			if (id_getReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_ == IntPtr.Zero)
				id_getReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "getReviewSummary", "(Lcom/pspdfkit/annotations/Annotation;Ljava/lang/String;)Lcom/pspdfkit/annotations/note/AnnotationReviewSummary;");
			IntPtr native_p1 = JNIEnv.NewString (p1);
			JValue* __args = stackalloc JValue[2];
			__args[0] = new JValue (p0);
			__args[1] = new JValue (native_p1);
			global::PSPDFKit.Annotations.Note.AnnotationReviewSummary __ret = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Note.AnnotationReviewSummary> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getReviewSummary_Lcom_pspdfkit_annotations_Annotation_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p1);
			return __ret;
		}

		static Delegate cb_prepareForSave;
#pragma warning disable 0169
		static Delegate GetPrepareForSaveHandler ()
		{
			if (cb_prepareForSave == null)
				cb_prepareForSave = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_PrepareForSave);
			return cb_prepareForSave;
		}

		static void n_PrepareForSave (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.PrepareForSave ();
		}
#pragma warning restore 0169

		IntPtr id_prepareForSave;
		public unsafe void PrepareForSave ()
		{
			if (id_prepareForSave == IntPtr.Zero)
				id_prepareForSave = JNIEnv.GetMethodID (class_ref, "prepareForSave", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_prepareForSave);
		}

		static Delegate cb_removeAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_;
#pragma warning disable 0169
		static Delegate GetRemoveAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_Handler ()
		{
			if (cb_removeAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_ == null)
				cb_removeAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RemoveAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_);
			return cb_removeAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_;
		}

		static void n_RemoveAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Annotation p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Annotation> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveAnnotationFromPage (p0);
		}
#pragma warning restore 0169

		IntPtr id_removeAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_;
		public unsafe void RemoveAnnotationFromPage (global::PSPDFKit.Annotations.Annotation p0)
		{
			if (id_removeAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_ == IntPtr.Zero)
				id_removeAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_ = JNIEnv.GetMethodID (class_ref, "removeAnnotationFromPage", "(Lcom/pspdfkit/annotations/Annotation;)V");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeAnnotationFromPage_Lcom_pspdfkit_annotations_Annotation_, __args);
		}

		static Delegate cb_removeAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_;
#pragma warning disable 0169
		static Delegate GetRemoveAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_Handler ()
		{
			if (cb_removeAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ == null)
				cb_removeAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RemoveAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_);
			return cb_removeAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_;
		}

		static void n_RemoveAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator p0 = (global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator) global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveAppearanceStreamGenerator (p0);
		}
#pragma warning restore 0169

		IntPtr id_removeAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_;
		public unsafe void RemoveAppearanceStreamGenerator (global::PSPDFKit.Annotations.Appearance.IAppearanceStreamGenerator p0)
		{
			if (id_removeAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ == IntPtr.Zero)
				id_removeAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_ = JNIEnv.GetMethodID (class_ref, "removeAppearanceStreamGenerator", "(Lcom/pspdfkit/annotations/appearance/AppearanceStreamGenerator;)V");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeAppearanceStreamGenerator_Lcom_pspdfkit_annotations_appearance_AppearanceStreamGenerator_, __args);
		}

		static Delegate cb_removeOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_;
#pragma warning disable 0169
		static Delegate GetRemoveOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_Handler ()
		{
			if (cb_removeOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ == null)
				cb_removeOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RemoveOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_);
			return cb_removeOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_;
		}

		static void n_RemoveOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.Annotations.IInstantAnnotationProvider> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Annotations.IAnnotationProviderOnAnnotationUpdatedListener p0 = (global::PSPDFKit.Annotations.IAnnotationProviderOnAnnotationUpdatedListener) global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.IAnnotationProviderOnAnnotationUpdatedListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveOnAnnotationUpdatedListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_removeOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_;
		public unsafe void RemoveOnAnnotationUpdatedListener (global::PSPDFKit.Annotations.IAnnotationProviderOnAnnotationUpdatedListener p0)
		{
			if (id_removeOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ == IntPtr.Zero)
				id_removeOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_ = JNIEnv.GetMethodID (class_ref, "removeOnAnnotationUpdatedListener", "(Lcom/pspdfkit/annotations/AnnotationProvider$OnAnnotationUpdatedListener;)V");
			JValue* __args = stackalloc JValue[1];
			__args[0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeOnAnnotationUpdatedListener_Lcom_pspdfkit_annotations_AnnotationProvider_OnAnnotationUpdatedListener_, __args);
		}

	}

}
