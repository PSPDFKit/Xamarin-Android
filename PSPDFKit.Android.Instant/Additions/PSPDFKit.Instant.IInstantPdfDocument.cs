using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace PSPDFKit.Instant {

	[Register ("com/pspdfkit/instant/document/InstantPdfDocument", DoNotGenerateAcw = true)]
	public abstract class InstantPdfDocument : Java.Lang.Object {

		internal InstantPdfDocument ()
		{
		}

		// Metadata.xml XPath field reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/field[@name='SYNC_LOCAL_CHANGES_DISABLED']"
		[Register ("SYNC_LOCAL_CHANGES_DISABLED")]
		public const long SyncLocalChangesDisabled = (long) 9223372036854775807;

		// The following are fields from: com.pspdfkit.document.PdfDocument

		// The following are fields from: Android.Runtime.IJavaObject

		// The following are fields from: System.IDisposable
	}

	[Register ("com/pspdfkit/instant/document/InstantPdfDocument", DoNotGenerateAcw = true)]
	[global::System.Obsolete ("Use the 'InstantPdfDocument' type. This type will be removed in a future release.")]
	public abstract class InstantPdfDocumentConsts : InstantPdfDocument {

		private InstantPdfDocumentConsts ()
		{
		}
	}

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']"
	[Register ("com/pspdfkit/instant/document/InstantPdfDocument", "", "PSPDFKit.Instant.IInstantPdfDocumentInvoker")]
	public partial interface IInstantPdfDocument : global::PSPDFKit.Document.IPdfDocument {

		long DelayForSyncingLocalChanges {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='getDelayForSyncingLocalChanges' and count(parameter)=0]"
			[Register ("getDelayForSyncingLocalChanges", "()J", "GetGetDelayForSyncingLocalChangesHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
			get;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='setDelayForSyncingLocalChanges' and count(parameter)=1 and parameter[1][@type='long']]"
			[Register ("setDelayForSyncingLocalChanges", "(J)V", "GetSetDelayForSyncingLocalChanges_JHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
			set;
		}

		global::PSPDFKit.Instant.InstantDocumentState DocumentState {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='getDocumentState' and count(parameter)=0]"
			[Register ("getDocumentState", "()Lcom/pspdfkit/instant/document/InstantDocumentState;", "GetGetDocumentStateHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
			get;
		}

		global::PSPDFKit.Instant.InstantClient InstantClient {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='getInstantClient' and count(parameter)=0]"
			[Register ("getInstantClient", "()Lcom/pspdfkit/instant/client/InstantClient;", "GetGetInstantClientHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
			get;
		}

		global::PSPDFKit.Instant.InstantDocumentDescriptor InstantDocumentDescriptor {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='getInstantDocumentDescriptor' and count(parameter)=0]"
			[Register ("getInstantDocumentDescriptor", "()Lcom/pspdfkit/instant/client/InstantDocumentDescriptor;", "GetGetInstantDocumentDescriptorHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
			get;
		}

		bool IsListeningToServerChanges {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='isListeningToServerChanges' and count(parameter)=0]"
			[Register ("isListeningToServerChanges", "()Z", "GetIsListeningToServerChangesHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
			get;
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='addInstantDocumentListener' and count(parameter)=1 and parameter[1][@type='com.pspdfkit.instant.listeners.InstantDocumentListener']]"
		[Register ("addInstantDocumentListener", "(Lcom/pspdfkit/instant/listeners/InstantDocumentListener;)V", "GetAddInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_Handler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
		void AddInstantDocumentListener (global::PSPDFKit.Instant.IInstantDocumentListener p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='notifyConnectivityChanged' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("notifyConnectivityChanged", "(Z)V", "GetNotifyConnectivityChanged_ZHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
		void NotifyConnectivityChanged (bool p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='reauthenticateWithJwt' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("reauthenticateWithJwt", "(Ljava/lang/String;)V", "GetReauthenticateWithJwt_Ljava_lang_String_Handler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
		void ReauthenticateWithJwt (string p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='removeInstantDocumentListener' and count(parameter)=1 and parameter[1][@type='com.pspdfkit.instant.listeners.InstantDocumentListener']]"
		[Register ("removeInstantDocumentListener", "(Lcom/pspdfkit/instant/listeners/InstantDocumentListener;)V", "GetRemoveInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_Handler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
		void RemoveInstantDocumentListener (global::PSPDFKit.Instant.IInstantDocumentListener p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='removeLocalStorage' and count(parameter)=0]"
		[Register ("removeLocalStorage", "()V", "GetRemoveLocalStorageHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
		void RemoveLocalStorage ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='setListenToServerChanges' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setListenToServerChanges", "(Z)V", "GetSetListenToServerChanges_ZHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
		void SetListenToServerChanges (bool p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.pspdfkit.instant.document']/interface[@name='InstantPdfDocument']/method[@name='syncAnnotations' and count(parameter)=0]"
		[Register ("syncAnnotations", "()V", "GetSyncAnnotationsHandler:PSPDFKit.Instant.IInstantPdfDocumentInvoker, PSPDFKit.Android.Instant")]
		void SyncAnnotations ();

	}

	[global::Android.Runtime.Register ("com/pspdfkit/instant/document/InstantPdfDocument", DoNotGenerateAcw = true)]
	internal class IInstantPdfDocumentInvoker : global::Java.Lang.Object, IInstantPdfDocument {

		internal new static readonly JniPeerMembers _members = new JniPeerMembers ("com/pspdfkit/instant/document/InstantPdfDocument", typeof (IInstantPdfDocumentInvoker));

		static IntPtr java_class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		IntPtr class_ref;

		public static IInstantPdfDocument GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IInstantPdfDocument> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.pspdfkit.instant.document.InstantPdfDocument"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IInstantPdfDocumentInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_getDelayForSyncingLocalChanges;
#pragma warning disable 0169
		static Delegate GetGetDelayForSyncingLocalChangesHandler ()
		{
			if (cb_getDelayForSyncingLocalChanges == null)
				cb_getDelayForSyncingLocalChanges = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, long>) n_GetDelayForSyncingLocalChanges);
			return cb_getDelayForSyncingLocalChanges;
		}

		static long n_GetDelayForSyncingLocalChanges (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.DelayForSyncingLocalChanges;
		}
#pragma warning restore 0169

		static Delegate cb_setDelayForSyncingLocalChanges_J;
#pragma warning disable 0169
		static Delegate GetSetDelayForSyncingLocalChanges_JHandler ()
		{
			if (cb_setDelayForSyncingLocalChanges_J == null)
				cb_setDelayForSyncingLocalChanges_J = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, long>) n_SetDelayForSyncingLocalChanges_J);
			return cb_setDelayForSyncingLocalChanges_J;
		}

		static void n_SetDelayForSyncingLocalChanges_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.DelayForSyncingLocalChanges = p0;
		}
#pragma warning restore 0169

		IntPtr id_getDelayForSyncingLocalChanges;
		IntPtr id_setDelayForSyncingLocalChanges_J;
		public unsafe long DelayForSyncingLocalChanges {
			get {
				if (id_getDelayForSyncingLocalChanges == IntPtr.Zero)
					id_getDelayForSyncingLocalChanges = JNIEnv.GetMethodID (class_ref, "getDelayForSyncingLocalChanges", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getDelayForSyncingLocalChanges);
			}
			set {
				if (id_setDelayForSyncingLocalChanges_J == IntPtr.Zero)
					id_setDelayForSyncingLocalChanges_J = JNIEnv.GetMethodID (class_ref, "setDelayForSyncingLocalChanges", "(J)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDelayForSyncingLocalChanges_J, __args);
			}
		}

		static Delegate cb_getDocumentState;
#pragma warning disable 0169
		static Delegate GetGetDocumentStateHandler ()
		{
			if (cb_getDocumentState == null)
				cb_getDocumentState = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetDocumentState);
			return cb_getDocumentState;
		}

		static IntPtr n_GetDocumentState (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.DocumentState);
		}
#pragma warning restore 0169

		IntPtr id_getDocumentState;
		public unsafe global::PSPDFKit.Instant.InstantDocumentState DocumentState {
			get {
				if (id_getDocumentState == IntPtr.Zero)
					id_getDocumentState = JNIEnv.GetMethodID (class_ref, "getDocumentState", "()Lcom/pspdfkit/instant/document/InstantDocumentState;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.InstantDocumentState> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDocumentState), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getInstantClient;
#pragma warning disable 0169
		static Delegate GetGetInstantClientHandler ()
		{
			if (cb_getInstantClient == null)
				cb_getInstantClient = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInstantClient);
			return cb_getInstantClient;
		}

		static IntPtr n_GetInstantClient (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.InstantClient);
		}
#pragma warning restore 0169

		IntPtr id_getInstantClient;
		public unsafe global::PSPDFKit.Instant.InstantClient InstantClient {
			get {
				if (id_getInstantClient == IntPtr.Zero)
					id_getInstantClient = JNIEnv.GetMethodID (class_ref, "getInstantClient", "()Lcom/pspdfkit/instant/client/InstantClient;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.InstantClient> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInstantClient), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getInstantDocumentDescriptor;
#pragma warning disable 0169
		static Delegate GetGetInstantDocumentDescriptorHandler ()
		{
			if (cb_getInstantDocumentDescriptor == null)
				cb_getInstantDocumentDescriptor = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetInstantDocumentDescriptor);
			return cb_getInstantDocumentDescriptor;
		}

		static IntPtr n_GetInstantDocumentDescriptor (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.InstantDocumentDescriptor);
		}
#pragma warning restore 0169

		IntPtr id_getInstantDocumentDescriptor;
		public unsafe global::PSPDFKit.Instant.InstantDocumentDescriptor InstantDocumentDescriptor {
			get {
				if (id_getInstantDocumentDescriptor == IntPtr.Zero)
					id_getInstantDocumentDescriptor = JNIEnv.GetMethodID (class_ref, "getInstantDocumentDescriptor", "()Lcom/pspdfkit/instant/client/InstantDocumentDescriptor;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.InstantDocumentDescriptor> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getInstantDocumentDescriptor), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_isListeningToServerChanges;
#pragma warning disable 0169
		static Delegate GetIsListeningToServerChangesHandler ()
		{
			if (cb_isListeningToServerChanges == null)
				cb_isListeningToServerChanges = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsListeningToServerChanges);
			return cb_isListeningToServerChanges;
		}

		static bool n_IsListeningToServerChanges (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsListeningToServerChanges;
		}
#pragma warning restore 0169

		IntPtr id_isListeningToServerChanges;
		public unsafe bool IsListeningToServerChanges {
			get {
				if (id_isListeningToServerChanges == IntPtr.Zero)
					id_isListeningToServerChanges = JNIEnv.GetMethodID (class_ref, "isListeningToServerChanges", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isListeningToServerChanges);
			}
		}

		static Delegate cb_addInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_;
#pragma warning disable 0169
		static Delegate GetAddInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_Handler ()
		{
			if (cb_addInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ == null)
				cb_addInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_AddInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_);
			return cb_addInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_;
		}

		static void n_AddInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Instant.IInstantDocumentListener p0 = (global::PSPDFKit.Instant.IInstantDocumentListener) global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantDocumentListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddInstantDocumentListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_addInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_;
		public unsafe void AddInstantDocumentListener (global::PSPDFKit.Instant.IInstantDocumentListener p0)
		{
			if (id_addInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ == IntPtr.Zero)
				id_addInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ = JNIEnv.GetMethodID (class_ref, "addInstantDocumentListener", "(Lcom/pspdfkit/instant/listeners/InstantDocumentListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_, __args);
		}

		static Delegate cb_notifyConnectivityChanged_Z;
#pragma warning disable 0169
		static Delegate GetNotifyConnectivityChanged_ZHandler ()
		{
			if (cb_notifyConnectivityChanged_Z == null)
				cb_notifyConnectivityChanged_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_NotifyConnectivityChanged_Z);
			return cb_notifyConnectivityChanged_Z;
		}

		static void n_NotifyConnectivityChanged_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.NotifyConnectivityChanged (p0);
		}
#pragma warning restore 0169

		IntPtr id_notifyConnectivityChanged_Z;
		public unsafe void NotifyConnectivityChanged (bool p0)
		{
			if (id_notifyConnectivityChanged_Z == IntPtr.Zero)
				id_notifyConnectivityChanged_Z = JNIEnv.GetMethodID (class_ref, "notifyConnectivityChanged", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_notifyConnectivityChanged_Z, __args);
		}

		static Delegate cb_reauthenticateWithJwt_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetReauthenticateWithJwt_Ljava_lang_String_Handler ()
		{
			if (cb_reauthenticateWithJwt_Ljava_lang_String_ == null)
				cb_reauthenticateWithJwt_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_ReauthenticateWithJwt_Ljava_lang_String_);
			return cb_reauthenticateWithJwt_Ljava_lang_String_;
		}

		static void n_ReauthenticateWithJwt_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ReauthenticateWithJwt (p0);
		}
#pragma warning restore 0169

		IntPtr id_reauthenticateWithJwt_Ljava_lang_String_;
		public unsafe void ReauthenticateWithJwt (string p0)
		{
			if (id_reauthenticateWithJwt_Ljava_lang_String_ == IntPtr.Zero)
				id_reauthenticateWithJwt_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "reauthenticateWithJwt", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_reauthenticateWithJwt_Ljava_lang_String_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate cb_removeInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_;
#pragma warning disable 0169
		static Delegate GetRemoveInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_Handler ()
		{
			if (cb_removeInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ == null)
				cb_removeInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_RemoveInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_);
			return cb_removeInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_;
		}

		static void n_RemoveInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Instant.IInstantDocumentListener p0 = (global::PSPDFKit.Instant.IInstantDocumentListener) global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantDocumentListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveInstantDocumentListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_removeInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_;
		public unsafe void RemoveInstantDocumentListener (global::PSPDFKit.Instant.IInstantDocumentListener p0)
		{
			if (id_removeInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ == IntPtr.Zero)
				id_removeInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_ = JNIEnv.GetMethodID (class_ref, "removeInstantDocumentListener", "(Lcom/pspdfkit/instant/listeners/InstantDocumentListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeInstantDocumentListener_Lcom_pspdfkit_instant_listeners_InstantDocumentListener_, __args);
		}

		static Delegate cb_removeLocalStorage;
#pragma warning disable 0169
		static Delegate GetRemoveLocalStorageHandler ()
		{
			if (cb_removeLocalStorage == null)
				cb_removeLocalStorage = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_RemoveLocalStorage);
			return cb_removeLocalStorage;
		}

		static void n_RemoveLocalStorage (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.RemoveLocalStorage ();
		}
#pragma warning restore 0169

		IntPtr id_removeLocalStorage;
		public unsafe void RemoveLocalStorage ()
		{
			if (id_removeLocalStorage == IntPtr.Zero)
				id_removeLocalStorage = JNIEnv.GetMethodID (class_ref, "removeLocalStorage", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeLocalStorage);
		}

		static Delegate cb_setListenToServerChanges_Z;
#pragma warning disable 0169
		static Delegate GetSetListenToServerChanges_ZHandler ()
		{
			if (cb_setListenToServerChanges_Z == null)
				cb_setListenToServerChanges_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetListenToServerChanges_Z);
			return cb_setListenToServerChanges_Z;
		}

		static void n_SetListenToServerChanges_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetListenToServerChanges (p0);
		}
#pragma warning restore 0169

		IntPtr id_setListenToServerChanges_Z;
		public unsafe void SetListenToServerChanges (bool p0)
		{
			if (id_setListenToServerChanges_Z == IntPtr.Zero)
				id_setListenToServerChanges_Z = JNIEnv.GetMethodID (class_ref, "setListenToServerChanges", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setListenToServerChanges_Z, __args);
		}

		static Delegate cb_syncAnnotations;
#pragma warning disable 0169
		static Delegate GetSyncAnnotationsHandler ()
		{
			if (cb_syncAnnotations == null)
				cb_syncAnnotations = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_SyncAnnotations);
			return cb_syncAnnotations;
		}

		static void n_SyncAnnotations (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SyncAnnotations ();
		}
#pragma warning restore 0169

		IntPtr id_syncAnnotations;
		public unsafe void SyncAnnotations ()
		{
			if (id_syncAnnotations == IntPtr.Zero)
				id_syncAnnotations = JNIEnv.GetMethodID (class_ref, "syncAnnotations", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_syncAnnotations);
		}

		static Delegate cb_getAnnotationProvider;
#pragma warning disable 0169
		static Delegate GetGetAnnotationProviderHandler ()
		{
			if (cb_getAnnotationProvider == null)
				cb_getAnnotationProvider = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetAnnotationProvider);
			return cb_getAnnotationProvider;
		}

		static IntPtr n_GetAnnotationProvider (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.AnnotationProvider);
		}
#pragma warning restore 0169

		IntPtr id_getAnnotationProvider;
		public unsafe global::PSPDFKit.Annotations.IAnnotationProvider AnnotationProvider {
			get {
				if (id_getAnnotationProvider == IntPtr.Zero)
					id_getAnnotationProvider = JNIEnv.GetMethodID (class_ref, "getAnnotationProvider", "()Lcom/pspdfkit/annotations/AnnotationProvider;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Annotations.IAnnotationProvider> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnnotationProvider), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_isAutomaticLinkGenerationEnabled;
#pragma warning disable 0169
		static Delegate GetGetAutomaticLinkGenerationEnabledHandler ()
		{
			if (cb_isAutomaticLinkGenerationEnabled == null)
				cb_isAutomaticLinkGenerationEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_GetAutomaticLinkGenerationEnabled);
			return cb_isAutomaticLinkGenerationEnabled;
		}

		static bool n_GetAutomaticLinkGenerationEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.AutomaticLinkGenerationEnabled;
		}
#pragma warning restore 0169

		IntPtr id_isAutomaticLinkGenerationEnabled;
		public unsafe global::System.Boolean AutomaticLinkGenerationEnabled {
			get {
				if (id_isAutomaticLinkGenerationEnabled == IntPtr.Zero)
					id_isAutomaticLinkGenerationEnabled = JNIEnv.GetMethodID (class_ref, "isAutomaticLinkGenerationEnabled", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isAutomaticLinkGenerationEnabled);
			}
			set {

			}
		}

		static Delegate cb_getBookmarkProvider;
#pragma warning disable 0169
		static Delegate GetGetBookmarkProviderHandler ()
		{
			if (cb_getBookmarkProvider == null)
				cb_getBookmarkProvider = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetBookmarkProvider);
			return cb_getBookmarkProvider;
		}

		static IntPtr n_GetBookmarkProvider (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.BookmarkProvider);
		}
#pragma warning restore 0169

		IntPtr id_getBookmarkProvider;
		public unsafe global::PSPDFKit.Bookmarks.IBookmarkProvider BookmarkProvider {
			get {
				if (id_getBookmarkProvider == IntPtr.Zero)
					id_getBookmarkProvider = JNIEnv.GetMethodID (class_ref, "getBookmarkProvider", "()Lcom/pspdfkit/bookmarks/BookmarkProvider;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Bookmarks.IBookmarkProvider> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getBookmarkProvider), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getCheckpointer;
#pragma warning disable 0169
		static Delegate GetGetCheckpointerHandler ()
		{
			if (cb_getCheckpointer == null)
				cb_getCheckpointer = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetCheckpointer);
			return cb_getCheckpointer;
		}

		static IntPtr n_GetCheckpointer (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Checkpointer);
		}
#pragma warning restore 0169

		IntPtr id_getCheckpointer;
		public unsafe global::PSPDFKit.Document.Checkpoint.PdfDocumentCheckpointer Checkpointer {
			get {
				if (id_getCheckpointer == IntPtr.Zero)
					id_getCheckpointer = JNIEnv.GetMethodID (class_ref, "getCheckpointer", "()Lcom/pspdfkit/document/checkpoint/PdfDocumentCheckpointer;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.Checkpoint.PdfDocumentCheckpointer> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCheckpointer), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getDefaultDocumentSaveOptions;
#pragma warning disable 0169
		static Delegate GetGetDefaultDocumentSaveOptionsHandler ()
		{
			if (cb_getDefaultDocumentSaveOptions == null)
				cb_getDefaultDocumentSaveOptions = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetDefaultDocumentSaveOptions);
			return cb_getDefaultDocumentSaveOptions;
		}

		static IntPtr n_GetDefaultDocumentSaveOptions (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.DefaultDocumentSaveOptions);
		}
#pragma warning restore 0169

		IntPtr id_getDefaultDocumentSaveOptions;
		public unsafe global::PSPDFKit.Document.DocumentSaveOptions DefaultDocumentSaveOptions {
			get {
				if (id_getDefaultDocumentSaveOptions == IntPtr.Zero)
					id_getDefaultDocumentSaveOptions = JNIEnv.GetMethodID (class_ref, "getDefaultDocumentSaveOptions", "()Lcom/pspdfkit/document/DocumentSaveOptions;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.DocumentSaveOptions> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDefaultDocumentSaveOptions), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getDocumentSignatureInfo;
#pragma warning disable 0169
		static Delegate GetGetDocumentSignatureInfoHandler ()
		{
			if (cb_getDocumentSignatureInfo == null)
				cb_getDocumentSignatureInfo = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetDocumentSignatureInfo);
			return cb_getDocumentSignatureInfo;
		}

		static IntPtr n_GetDocumentSignatureInfo (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.DocumentSignatureInfo);
		}
#pragma warning restore 0169

		IntPtr id_getDocumentSignatureInfo;
		public unsafe global::PSPDFKit.Signatures.IDocumentSignatureInfo DocumentSignatureInfo {
			get {
				if (id_getDocumentSignatureInfo == IntPtr.Zero)
					id_getDocumentSignatureInfo = JNIEnv.GetMethodID (class_ref, "getDocumentSignatureInfo", "()Lcom/pspdfkit/signatures/DocumentSignatureInfo;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Signatures.IDocumentSignatureInfo> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDocumentSignatureInfo), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getDocumentSource;
#pragma warning disable 0169
		static Delegate GetGetDocumentSourceHandler ()
		{
			if (cb_getDocumentSource == null)
				cb_getDocumentSource = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetDocumentSource);
			return cb_getDocumentSource;
		}

		static IntPtr n_GetDocumentSource (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.DocumentSource);
		}
#pragma warning restore 0169

		IntPtr id_getDocumentSource;
		public unsafe global::PSPDFKit.Document.DocumentSource DocumentSource {
			get {
				if (id_getDocumentSource == IntPtr.Zero)
					id_getDocumentSource = JNIEnv.GetMethodID (class_ref, "getDocumentSource", "()Lcom/pspdfkit/document/DocumentSource;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.DocumentSource> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDocumentSource), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getDocumentSources;
#pragma warning disable 0169
		static Delegate GetGetDocumentSourcesHandler ()
		{
			if (cb_getDocumentSources == null)
				cb_getDocumentSources = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetDocumentSources);
			return cb_getDocumentSources;
		}

		static IntPtr n_GetDocumentSources (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList<global::PSPDFKit.Document.DocumentSource>.ToLocalJniHandle (__this.DocumentSources);
		}
#pragma warning restore 0169

		IntPtr id_getDocumentSources;
		public unsafe global::System.Collections.Generic.IList<global::PSPDFKit.Document.DocumentSource> DocumentSources {
			get {
				if (id_getDocumentSources == IntPtr.Zero)
					id_getDocumentSources = JNIEnv.GetMethodID (class_ref, "getDocumentSources", "()Ljava/util/List;");
				return global::Android.Runtime.JavaList<global::PSPDFKit.Document.DocumentSource>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDocumentSources), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getEmbeddedFilesProvider;
#pragma warning disable 0169
		static Delegate GetGetEmbeddedFilesProviderHandler ()
		{
			if (cb_getEmbeddedFilesProvider == null)
				cb_getEmbeddedFilesProvider = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetEmbeddedFilesProvider);
			return cb_getEmbeddedFilesProvider;
		}

		static IntPtr n_GetEmbeddedFilesProvider (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.EmbeddedFilesProvider);
		}
#pragma warning restore 0169

		IntPtr id_getEmbeddedFilesProvider;
		public unsafe global::PSPDFKit.Document.Files.IEmbeddedFilesProvider EmbeddedFilesProvider {
			get {
				if (id_getEmbeddedFilesProvider == IntPtr.Zero)
					id_getEmbeddedFilesProvider = JNIEnv.GetMethodID (class_ref, "getEmbeddedFilesProvider", "()Lcom/pspdfkit/document/files/EmbeddedFilesProvider;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.Files.IEmbeddedFilesProvider> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getEmbeddedFilesProvider), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getFormProvider;
#pragma warning disable 0169
		static Delegate GetGetFormProviderHandler ()
		{
			if (cb_getFormProvider == null)
				cb_getFormProvider = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetFormProvider);
			return cb_getFormProvider;
		}

		static IntPtr n_GetFormProvider (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.FormProvider);
		}
#pragma warning restore 0169

		IntPtr id_getFormProvider;
		public unsafe global::PSPDFKit.Forms.IFormProvider FormProvider {
			get {
				if (id_getFormProvider == IntPtr.Zero)
					id_getFormProvider = JNIEnv.GetMethodID (class_ref, "getFormProvider", "()Lcom/pspdfkit/forms/FormProvider;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Forms.IFormProvider> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getFormProvider), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_hasOutline;
#pragma warning disable 0169
		static Delegate GetHasOutlineHandler ()
		{
			if (cb_hasOutline == null)
				cb_hasOutline = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_HasOutline);
			return cb_hasOutline;
		}

		static bool n_HasOutline (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.HasOutline;
		}
#pragma warning restore 0169

		IntPtr id_hasOutline;
		public unsafe bool HasOutline {
			get {
				if (id_hasOutline == IntPtr.Zero)
					id_hasOutline = JNIEnv.GetMethodID (class_ref, "hasOutline", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasOutline);
			}
		}

		static Delegate cb_getPageBinding;
#pragma warning disable 0169
		static Delegate GetGetPageBindingHandler ()
		{
			if (cb_getPageBinding == null)
				cb_getPageBinding = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPageBinding);
			return cb_getPageBinding;
		}

		static IntPtr n_GetPageBinding (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.PageBinding);
		}
#pragma warning restore 0169

		static Delegate cb_setPageBinding_Lcom_pspdfkit_document_PageBinding_;
#pragma warning disable 0169
		static Delegate GetSetPageBinding_Lcom_pspdfkit_document_PageBinding_Handler ()
		{
			if (cb_setPageBinding_Lcom_pspdfkit_document_PageBinding_ == null)
				cb_setPageBinding_Lcom_pspdfkit_document_PageBinding_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetPageBinding_Lcom_pspdfkit_document_PageBinding_);
			return cb_setPageBinding_Lcom_pspdfkit_document_PageBinding_;
		}

		static void n_SetPageBinding_Lcom_pspdfkit_document_PageBinding_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Document.PageBinding p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.PageBinding> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.PageBinding = p0;
		}
#pragma warning restore 0169

		IntPtr id_getPageBinding;
		IntPtr id_setPageBinding_Lcom_pspdfkit_document_PageBinding_;
		public unsafe global::PSPDFKit.Document.PageBinding PageBinding {
			get {
				if (id_getPageBinding == IntPtr.Zero)
					id_getPageBinding = JNIEnv.GetMethodID (class_ref, "getPageBinding", "()Lcom/pspdfkit/document/PageBinding;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.PageBinding> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageBinding), JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (id_setPageBinding_Lcom_pspdfkit_document_PageBinding_ == IntPtr.Zero)
					id_setPageBinding_Lcom_pspdfkit_document_PageBinding_ = JNIEnv.GetMethodID (class_ref, "setPageBinding", "(Lcom/pspdfkit/document/PageBinding;)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue ((value == null) ? IntPtr.Zero : ((global::Java.Lang.Object) value).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPageBinding_Lcom_pspdfkit_document_PageBinding_, __args);
			}
		}

		static Delegate cb_isValidForEditing;
#pragma warning disable 0169
		static Delegate GetIsValidForEditingHandler ()
		{
			if (cb_isValidForEditing == null)
				cb_isValidForEditing = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsValidForEditing);
			return cb_isValidForEditing;
		}

		static bool n_IsValidForEditing (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsValidForEditing;
		}
#pragma warning restore 0169

		IntPtr id_isValidForEditing;
		public unsafe global::System.Boolean IsValidForEditing {
			get {
				if (id_isValidForEditing == IntPtr.Zero)
					id_isValidForEditing = JNIEnv.GetMethodID (class_ref, "isValidForEditing", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isValidForEditing);
			}
		}

		static Delegate cb_isWatermarkFilteringEnabled;
#pragma warning disable 0169
		static Delegate GetIsWatermarkFilteringEnabledHandler ()
		{
			if (cb_isWatermarkFilteringEnabled == null)
				cb_isWatermarkFilteringEnabled = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_IsWatermarkFilteringEnabled);
			return cb_isWatermarkFilteringEnabled;
		}

		static bool n_IsWatermarkFilteringEnabled (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.IsWatermarkFilteringEnabled;
		}
#pragma warning restore 0169

		IntPtr id_isWatermarkFilteringEnabled;
		public unsafe global::System.Boolean IsWatermarkFilteringEnabled {
			get {
				if (id_isWatermarkFilteringEnabled == IntPtr.Zero)
					id_isWatermarkFilteringEnabled = JNIEnv.GetMethodID (class_ref, "isWatermarkFilteringEnabled", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isWatermarkFilteringEnabled);
			}
		}

		static Delegate cb_getOutline;
#pragma warning disable 0169
		static Delegate GetGetOutlineHandler ()
		{
			if (cb_getOutline == null)
				cb_getOutline = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetOutline);
			return cb_getOutline;
		}

		static IntPtr n_GetOutline (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList<global::PSPDFKit.Document.OutlineElement>.ToLocalJniHandle (__this.Outline);
		}
#pragma warning restore 0169

		IntPtr id_getOutline;
		public unsafe global::System.Collections.Generic.IList<global::PSPDFKit.Document.OutlineElement> Outline {
			get {
				if (id_getOutline == IntPtr.Zero)
					id_getOutline = JNIEnv.GetMethodID (class_ref, "getOutline", "()Ljava/util/List;");
				return global::Android.Runtime.JavaList<global::PSPDFKit.Document.OutlineElement>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getOutline), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getPageCount;
#pragma warning disable 0169
		static Delegate GetGetPageCountHandler ()
		{
			if (cb_getPageCount == null)
				cb_getPageCount = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int>) n_GetPageCount);
			return cb_getPageCount;
		}

		static int n_GetPageCount (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.PageCount;
		}
#pragma warning restore 0169

		IntPtr id_getPageCount;
		public unsafe global::System.Int32 PageCount {
			get {
				if (id_getPageCount == IntPtr.Zero)
					id_getPageCount = JNIEnv.GetMethodID (class_ref, "getPageCount", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getPageCount);
			}
		}

		static Delegate cb_getPdfMetadata;
#pragma warning disable 0169
		static Delegate GetGetPdfMetadataHandler ()
		{
			if (cb_getPdfMetadata == null)
				cb_getPdfMetadata = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPdfMetadata);
			return cb_getPdfMetadata;
		}

		static IntPtr n_GetPdfMetadata (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.PdfMetadata);
		}
#pragma warning restore 0169

		IntPtr id_getPdfMetadata;
		public unsafe global::PSPDFKit.Document.Metadata.IDocumentPdfMetadata PdfMetadata {
			get {
				if (id_getPdfMetadata == IntPtr.Zero)
					id_getPdfMetadata = JNIEnv.GetMethodID (class_ref, "getPdfMetadata", "()Lcom/pspdfkit/document/metadata/DocumentPdfMetadata;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.Metadata.IDocumentPdfMetadata> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPdfMetadata), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getPdfVersion;
#pragma warning disable 0169
		static Delegate GetGetPdfVersionHandler ()
		{
			if (cb_getPdfVersion == null)
				cb_getPdfVersion = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPdfVersion);
			return cb_getPdfVersion;
		}

		static IntPtr n_GetPdfVersion (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.PdfVersion);
		}
#pragma warning restore 0169

		IntPtr id_getPdfVersion;
		public unsafe global::PSPDFKit.Document.PdfVersion PdfVersion {
			get {
				if (id_getPdfVersion == IntPtr.Zero)
					id_getPdfVersion = JNIEnv.GetMethodID (class_ref, "getPdfVersion", "()Lcom/pspdfkit/document/PdfVersion;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.PdfVersion> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPdfVersion), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getPermissions;
#pragma warning disable 0169
		static Delegate GetGetPermissionsHandler ()
		{
			if (cb_getPermissions == null)
				cb_getPermissions = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetPermissions);
			return cb_getPermissions;
		}

		static IntPtr n_GetPermissions (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Permissions);
		}
#pragma warning restore 0169

		IntPtr id_getPermissions;
		public unsafe global::Java.Util.EnumSet Permissions {
			get {
				if (id_getPermissions == IntPtr.Zero)
					id_getPermissions = JNIEnv.GetMethodID (class_ref, "getPermissions", "()Ljava/util/EnumSet;");
				return global::Java.Lang.Object.GetObject<global::Java.Util.EnumSet> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPermissions), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getTitle;
#pragma warning disable 0169
		static Delegate GetGetTitleHandler ()
		{
			if (cb_getTitle == null)
				cb_getTitle = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetTitle);
			return cb_getTitle;
		}

		static IntPtr n_GetTitle (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Title);
		}
#pragma warning restore 0169

		IntPtr id_getTitle;
		public unsafe global::System.String Title {
			get {
				if (id_getTitle == IntPtr.Zero)
					id_getTitle = JNIEnv.GetMethodID (class_ref, "getTitle", "()Ljava/lang/String;");
				return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTitle), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getUid;
#pragma warning disable 0169
		static Delegate GetGetUidHandler ()
		{
			if (cb_getUid == null)
				cb_getUid = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetUid);
			return cb_getUid;
		}

		static IntPtr n_GetUid (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.Uid);
		}
#pragma warning restore 0169

		IntPtr id_getUid;
		public unsafe global::System.String Uid {
			get {
				if (id_getUid == IntPtr.Zero)
					id_getUid = JNIEnv.GetMethodID (class_ref, "getUid", "()Ljava/lang/String;");
				return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getUid), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_getXmpMetadata;
#pragma warning disable 0169
		static Delegate GetGetXmpMetadataHandler ()
		{
			if (cb_getXmpMetadata == null)
				cb_getXmpMetadata = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetXmpMetadata);
			return cb_getXmpMetadata;
		}

		static IntPtr n_GetXmpMetadata (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.XmpMetadata);
		}
#pragma warning restore 0169

		IntPtr id_getXmpMetadata;
		public unsafe global::PSPDFKit.Document.Metadata.IDocumentXmpMetadata XmpMetadata {
			get {
				if (id_getXmpMetadata == IntPtr.Zero)
					id_getXmpMetadata = JNIEnv.GetMethodID (class_ref, "getXmpMetadata", "()Lcom/pspdfkit/document/metadata/DocumentXmpMetadata;");
				return global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.Metadata.IDocumentXmpMetadata> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getXmpMetadata), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate cb_setAutomaticLinkGenerationEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetAutomaticLinkGenerationEnabled_ZHandler ()
		{
			if (cb_setAutomaticLinkGenerationEnabled_Z == null)
				cb_setAutomaticLinkGenerationEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetAutomaticLinkGenerationEnabled_Z);
			return cb_setAutomaticLinkGenerationEnabled_Z;
		}

		static void n_SetAutomaticLinkGenerationEnabled_Z (IntPtr jnienv, IntPtr native__this, bool value)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.AutomaticLinkGenerationEnabled = value;
		}
#pragma warning restore 0169

		IntPtr id_setAutomaticLinkGenerationEnabled_Z;
		public unsafe void SetAutomaticLinkGenerationEnabled (bool value)
		{
			if (id_setAutomaticLinkGenerationEnabled_Z == IntPtr.Zero)
				id_setAutomaticLinkGenerationEnabled_Z = JNIEnv.GetMethodID (class_ref, "setAutomaticLinkGenerationEnabled", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (value);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAutomaticLinkGenerationEnabled_Z, __args);
		}

		static Delegate cb_getCharIndexAt_IFF;
#pragma warning disable 0169
		static Delegate GetGetCharIndexAt_IFFHandler ()
		{
			if (cb_getCharIndexAt_IFF == null)
				cb_getCharIndexAt_IFF = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, float, float, int>) n_GetCharIndexAt_IFF);
			return cb_getCharIndexAt_IFF;
		}

		static int n_GetCharIndexAt_IFF (IntPtr jnienv, IntPtr native__this, int p0, float p1, float p2)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetCharIndexAt (p0, p1, p2);
		}
#pragma warning restore 0169

		IntPtr id_getCharIndexAt_IFF;
		public unsafe global::System.Int32 GetCharIndexAt (int p0, float p1, float p2)
		{
			if (id_getCharIndexAt_IFF == IntPtr.Zero)
				id_getCharIndexAt_IFF = JNIEnv.GetMethodID (class_ref, "getCharIndexAt", "(IFF)I");
			JValue* __args = stackalloc JValue [3];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCharIndexAt_IFF, __args);
		}

		static Delegate cb_getPageBox_ILcom_pspdfkit_document_PdfBox_;
#pragma warning disable 0169
		static Delegate GetGetPageBox_ILcom_pspdfkit_document_PdfBox_Handler ()
		{
			if (cb_getPageBox_ILcom_pspdfkit_document_PdfBox_ == null)
				cb_getPageBox_ILcom_pspdfkit_document_PdfBox_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr>) n_GetPageBox_ILcom_pspdfkit_document_PdfBox_);
			return cb_getPageBox_ILcom_pspdfkit_document_PdfBox_;
		}

		static IntPtr n_GetPageBox_ILcom_pspdfkit_document_PdfBox_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Document.PdfBox p1 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.PdfBox> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetPageBox (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getPageBox_ILcom_pspdfkit_document_PdfBox_;
		public unsafe global::Android.Graphics.RectF GetPageBox (int p0, global::PSPDFKit.Document.PdfBox p1)
		{
			if (id_getPageBox_ILcom_pspdfkit_document_PdfBox_ == IntPtr.Zero)
				id_getPageBox_ILcom_pspdfkit_document_PdfBox_ = JNIEnv.GetMethodID (class_ref, "getPageBox", "(ILcom/pspdfkit/document/PdfBox;)Landroid/graphics/RectF;");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
			global::Android.Graphics.RectF __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.RectF> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageBox_ILcom_pspdfkit_document_PdfBox_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

		static Delegate cb_getPageIndexForPageLabel_Ljava_lang_String_Z;
#pragma warning disable 0169
		static Delegate GetGetPageIndexForPageLabel_Ljava_lang_String_ZHandler ()
		{
			if (cb_getPageIndexForPageLabel_Ljava_lang_String_Z == null)
				cb_getPageIndexForPageLabel_Ljava_lang_String_Z = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool, IntPtr>) n_GetPageIndexForPageLabel_Ljava_lang_String_Z);
			return cb_getPageIndexForPageLabel_Ljava_lang_String_Z;
		}

		static IntPtr n_GetPageIndexForPageLabel_Ljava_lang_String_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.GetPageIndexForPageLabel (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getPageIndexForPageLabel_Ljava_lang_String_Z;
		public unsafe global::Java.Lang.Integer GetPageIndexForPageLabel (string p0, bool p1)
		{
			if (id_getPageIndexForPageLabel_Ljava_lang_String_Z == IntPtr.Zero)
				id_getPageIndexForPageLabel_Ljava_lang_String_Z = JNIEnv.GetMethodID (class_ref, "getPageIndexForPageLabel", "(Ljava/lang/String;Z)Ljava/lang/Integer;");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (native_p0);
			__args [1] = new JValue (p1);
			global::Java.Lang.Integer __ret = global::Java.Lang.Object.GetObject<global::Java.Lang.Integer> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageIndexForPageLabel_Ljava_lang_String_Z, __args), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef (native_p0);
			return __ret;
		}

		static Delegate cb_getPageLabel_IZ;
#pragma warning disable 0169
		static Delegate GetGetPageLabel_IZHandler ()
		{
			if (cb_getPageLabel_IZ == null)
				cb_getPageLabel_IZ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, bool, IntPtr>) n_GetPageLabel_IZ);
			return cb_getPageLabel_IZ;
		}

		static IntPtr n_GetPageLabel_IZ (IntPtr jnienv, IntPtr native__this, int p0, bool p1)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GetPageLabel (p0, p1));
		}
#pragma warning restore 0169

		IntPtr id_getPageLabel_IZ;
		public unsafe global::System.String GetPageLabel (int p0, bool p1)
		{
			if (id_getPageLabel_IZ == IntPtr.Zero)
				id_getPageLabel_IZ = JNIEnv.GetMethodID (class_ref, "getPageLabel", "(IZ)Ljava/lang/String;");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageLabel_IZ, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_getPageRotation_I;
#pragma warning disable 0169
		static Delegate GetGetPageRotation_IHandler ()
		{
			if (cb_getPageRotation_I == null)
				cb_getPageRotation_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int>) n_GetPageRotation_I);
			return cb_getPageRotation_I;
		}

		static int n_GetPageRotation_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetPageRotation (p0);
		}
#pragma warning restore 0169

		IntPtr id_getPageRotation_I;
		public unsafe global::System.Int32 GetPageRotation (int p0)
		{
			if (id_getPageRotation_I == IntPtr.Zero)
				id_getPageRotation_I = JNIEnv.GetMethodID (class_ref, "getPageRotation", "(I)I");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getPageRotation_I, __args);
		}

		static Delegate cb_getPageSize_I;
#pragma warning disable 0169
		static Delegate GetGetPageSize_IHandler ()
		{
			if (cb_getPageSize_I == null)
				cb_getPageSize_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetPageSize_I);
			return cb_getPageSize_I;
		}

		static IntPtr n_GetPageSize_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.GetPageSize (p0));
		}
#pragma warning restore 0169

		IntPtr id_getPageSize_I;
		public unsafe global::PSPDFKit.Utils.Size GetPageSize (int p0)
		{
			if (id_getPageSize_I == IntPtr.Zero)
				id_getPageSize_I = JNIEnv.GetMethodID (class_ref, "getPageSize", "(I)Lcom/pspdfkit/utils/Size;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return global::Java.Lang.Object.GetObject<global::PSPDFKit.Utils.Size> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageSize_I, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_getPageText_I;
#pragma warning disable 0169
		static Delegate GetGetPageText_IHandler ()
		{
			if (cb_getPageText_I == null)
				cb_getPageText_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr>) n_GetPageText_I);
			return cb_getPageText_I;
		}

		static IntPtr n_GetPageText_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GetPageText (p0));
		}
#pragma warning restore 0169

		IntPtr id_getPageText_I;
		public unsafe global::System.String GetPageText (int p0)
		{
			if (id_getPageText_I == IntPtr.Zero)
				id_getPageText_I = JNIEnv.GetMethodID (class_ref, "getPageText", "(I)Ljava/lang/String;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageText_I, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_getPageText_ILandroid_graphics_RectF_;
#pragma warning disable 0169
		static Delegate GetGetPageText_ILandroid_graphics_RectF_Handler ()
		{
			if (cb_getPageText_ILandroid_graphics_RectF_ == null)
				cb_getPageText_ILandroid_graphics_RectF_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr>) n_GetPageText_ILandroid_graphics_RectF_);
			return cb_getPageText_ILandroid_graphics_RectF_;
		}

		static IntPtr n_GetPageText_ILandroid_graphics_RectF_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Graphics.RectF p1 = global::Java.Lang.Object.GetObject<global::Android.Graphics.RectF> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.NewString (__this.GetPageText (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getPageText_ILandroid_graphics_RectF_;
		public unsafe global::System.String GetPageText (int p0, global::Android.Graphics.RectF p1)
		{
			if (id_getPageText_ILandroid_graphics_RectF_ == IntPtr.Zero)
				id_getPageText_ILandroid_graphics_RectF_ = JNIEnv.GetMethodID (class_ref, "getPageText", "(ILandroid/graphics/RectF;)Ljava/lang/String;");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
			global::System.String __ret = JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageText_ILandroid_graphics_RectF_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

		static Delegate cb_getPageText_III;
#pragma warning disable 0169
		static Delegate GetGetPageText_IIIHandler ()
		{
			if (cb_getPageText_III == null)
				cb_getPageText_III = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int, IntPtr>) n_GetPageText_III);
			return cb_getPageText_III;
		}

		static IntPtr n_GetPageText_III (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.GetPageText (p0, p1, p2));
		}
#pragma warning restore 0169

		IntPtr id_getPageText_III;
		public unsafe global::System.String GetPageText (int p0, int p1, int p2)
		{
			if (id_getPageText_III == IntPtr.Zero)
				id_getPageText_III = JNIEnv.GetMethodID (class_ref, "getPageText", "(III)Ljava/lang/String;");
			JValue* __args = stackalloc JValue [3];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageText_III, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_getPageTextLength_I;
#pragma warning disable 0169
		static Delegate GetGetPageTextLength_IHandler ()
		{
			if (cb_getPageTextLength_I == null)
				cb_getPageTextLength_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int>) n_GetPageTextLength_I);
			return cb_getPageTextLength_I;
		}

		static int n_GetPageTextLength_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetPageTextLength (p0);
		}
#pragma warning restore 0169

		IntPtr id_getPageTextLength_I;
		public unsafe global::System.Int32 GetPageTextLength (int p0)
		{
			if (id_getPageTextLength_I == IntPtr.Zero)
				id_getPageTextLength_I = JNIEnv.GetMethodID (class_ref, "getPageTextLength", "(I)I");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getPageTextLength_I, __args);
		}

		static Delegate cb_getPageTextRects_III;
#pragma warning disable 0169
		static Delegate GetGetPageTextRects_IIIHandler ()
		{
			if (cb_getPageTextRects_III == null)
				cb_getPageTextRects_III = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int, IntPtr>) n_GetPageTextRects_III);
			return cb_getPageTextRects_III;
		}

		static IntPtr n_GetPageTextRects_III (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList<global::Android.Graphics.RectF>.ToLocalJniHandle (__this.GetPageTextRects (p0, p1, p2));
		}
#pragma warning restore 0169

		IntPtr id_getPageTextRects_III;
		public unsafe global::System.Collections.Generic.IList<global::Android.Graphics.RectF> GetPageTextRects (int p0, int p1, int p2)
		{
			if (id_getPageTextRects_III == IntPtr.Zero)
				id_getPageTextRects_III = JNIEnv.GetMethodID (class_ref, "getPageTextRects", "(III)Ljava/util/List;");
			JValue* __args = stackalloc JValue [3];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			return global::Android.Runtime.JavaList<global::Android.Graphics.RectF>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageTextRects_III, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_getPageTextRects_IIIZ;
#pragma warning disable 0169
		static Delegate GetGetPageTextRects_IIIZHandler ()
		{
			if (cb_getPageTextRects_IIIZ == null)
				cb_getPageTextRects_IIIZ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int, int, bool, IntPtr>) n_GetPageTextRects_IIIZ);
			return cb_getPageTextRects_IIIZ;
		}

		static IntPtr n_GetPageTextRects_IIIZ (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2, bool p3)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return global::Android.Runtime.JavaList<global::Android.Graphics.RectF>.ToLocalJniHandle (__this.GetPageTextRects (p0, p1, p2, p3));
		}
#pragma warning restore 0169

		IntPtr id_getPageTextRects_IIIZ;
		public unsafe global::System.Collections.Generic.IList<global::Android.Graphics.RectF> GetPageTextRects (int p0, int p1, int p2, bool p3)
		{
			if (id_getPageTextRects_IIIZ == IntPtr.Zero)
				id_getPageTextRects_IIIZ = JNIEnv.GetMethodID (class_ref, "getPageTextRects", "(IIIZ)Ljava/util/List;");
			JValue* __args = stackalloc JValue [4];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			__args [3] = new JValue (p3);
			return global::Android.Runtime.JavaList<global::Android.Graphics.RectF>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPageTextRects_IIIZ, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate cb_getRotationOffset_I;
#pragma warning disable 0169
		static Delegate GetGetRotationOffset_IHandler ()
		{
			if (cb_getRotationOffset_I == null)
				cb_getRotationOffset_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, int>) n_GetRotationOffset_I);
			return cb_getRotationOffset_I;
		}

		static int n_GetRotationOffset_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetRotationOffset (p0);
		}
#pragma warning restore 0169

		IntPtr id_getRotationOffset_I;
		public unsafe global::System.Int32 GetRotationOffset (int p0)
		{
			if (id_getRotationOffset_I == IntPtr.Zero)
				id_getRotationOffset_I = JNIEnv.GetMethodID (class_ref, "getRotationOffset", "(I)I");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getRotationOffset_I, __args);
		}

		static Delegate cb_hasPermission_Lcom_pspdfkit_document_DocumentPermissions_;
#pragma warning disable 0169
		static Delegate GetHasPermission_Lcom_pspdfkit_document_DocumentPermissions_Handler ()
		{
			if (cb_hasPermission_Lcom_pspdfkit_document_DocumentPermissions_ == null)
				cb_hasPermission_Lcom_pspdfkit_document_DocumentPermissions_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_HasPermission_Lcom_pspdfkit_document_DocumentPermissions_);
			return cb_hasPermission_Lcom_pspdfkit_document_DocumentPermissions_;
		}

		static bool n_HasPermission_Lcom_pspdfkit_document_DocumentPermissions_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Document.DocumentPermissions p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.DocumentPermissions> (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.HasPermission (p0);
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_hasPermission_Lcom_pspdfkit_document_DocumentPermissions_;
		public unsafe global::System.Boolean HasPermission (global::PSPDFKit.Document.DocumentPermissions p0)
		{
			if (id_hasPermission_Lcom_pspdfkit_document_DocumentPermissions_ == IntPtr.Zero)
				id_hasPermission_Lcom_pspdfkit_document_DocumentPermissions_ = JNIEnv.GetMethodID (class_ref, "hasPermission", "(Lcom/pspdfkit/document/DocumentPermissions;)Z");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			global::System.Boolean __ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasPermission_Lcom_pspdfkit_document_DocumentPermissions_, __args);
			return __ret;
		}

		static Delegate cb_initPageCache;
#pragma warning disable 0169
		static Delegate GetInitPageCacheHandler ()
		{
			if (cb_initPageCache == null)
				cb_initPageCache = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_InitPageCache);
			return cb_initPageCache;
		}

		static void n_InitPageCache (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.InitPageCache ();
		}
#pragma warning restore 0169

		IntPtr id_initPageCache;
		public unsafe void InitPageCache ()
		{
			if (id_initPageCache == IntPtr.Zero)
				id_initPageCache = JNIEnv.GetMethodID (class_ref, "initPageCache", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_initPageCache);
		}

		static Delegate cb_invalidateCache;
#pragma warning disable 0169
		static Delegate GetInvalidateCacheHandler ()
		{
			if (cb_invalidateCache == null)
				cb_invalidateCache = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_InvalidateCache);
			return cb_invalidateCache;
		}

		static void n_InvalidateCache (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.InvalidateCache ();
		}
#pragma warning restore 0169

		IntPtr id_invalidateCache;
		public unsafe void InvalidateCache ()
		{
			if (id_invalidateCache == IntPtr.Zero)
				id_invalidateCache = JNIEnv.GetMethodID (class_ref, "invalidateCache", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_invalidateCache);
		}

		static Delegate cb_invalidateCacheForPage_I;
#pragma warning disable 0169
		static Delegate GetInvalidateCacheForPage_IHandler ()
		{
			if (cb_invalidateCacheForPage_I == null)
				cb_invalidateCacheForPage_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>) n_InvalidateCacheForPage_I);
			return cb_invalidateCacheForPage_I;
		}

		static void n_InvalidateCacheForPage_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.InvalidateCacheForPage (p0);
		}
#pragma warning restore 0169

		IntPtr id_invalidateCacheForPage_I;
		public unsafe void InvalidateCacheForPage (int p0)
		{
			if (id_invalidateCacheForPage_I == IntPtr.Zero)
				id_invalidateCacheForPage_I = JNIEnv.GetMethodID (class_ref, "invalidateCacheForPage", "(I)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_invalidateCacheForPage_I, __args);
		}

		static Delegate cb_renderPageToBitmap_Landroid_content_Context_III;
#pragma warning disable 0169
		static Delegate GetRenderPageToBitmap_Landroid_content_Context_IIIHandler ()
		{
			if (cb_renderPageToBitmap_Landroid_content_Context_III == null)
				cb_renderPageToBitmap_Landroid_content_Context_III = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, int, int, int, IntPtr>) n_RenderPageToBitmap_Landroid_content_Context_III);
			return cb_renderPageToBitmap_Landroid_content_Context_III;
		}

		static IntPtr n_RenderPageToBitmap_Landroid_content_Context_III (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, int p3)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.RenderPageToBitmap (p0, p1, p2, p3));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_renderPageToBitmap_Landroid_content_Context_III;
		public unsafe global::Android.Graphics.Bitmap RenderPageToBitmap (global::Android.Content.Context p0, int p1, int p2, int p3)
		{
			if (id_renderPageToBitmap_Landroid_content_Context_III == IntPtr.Zero)
				id_renderPageToBitmap_Landroid_content_Context_III = JNIEnv.GetMethodID (class_ref, "renderPageToBitmap", "(Landroid/content/Context;III)Landroid/graphics/Bitmap;");
			JValue* __args = stackalloc JValue [4];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			__args [3] = new JValue (p3);
			global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_renderPageToBitmap_Landroid_content_Context_III, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

		static Delegate cb_renderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_;
#pragma warning disable 0169
		static Delegate GetRenderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_Handler ()
		{
			if (cb_renderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_ == null)
				cb_renderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, int, int, int, IntPtr, IntPtr>) n_RenderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_);
			return cb_renderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_;
		}

		static IntPtr n_RenderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, int p2, int p3, IntPtr native_p4)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Context p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_p0, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Configuration.Rendering.PageRenderConfiguration p4 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Configuration.Rendering.PageRenderConfiguration> (native_p4, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.RenderPageToBitmap (p0, p1, p2, p3, p4));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_renderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_;
		public unsafe global::Android.Graphics.Bitmap RenderPageToBitmap (global::Android.Content.Context p0, int p1, int p2, int p3, global::PSPDFKit.Configuration.Rendering.PageRenderConfiguration p4)
		{
			if (id_renderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_ == IntPtr.Zero)
				id_renderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_ = JNIEnv.GetMethodID (class_ref, "renderPageToBitmap", "(Landroid/content/Context;IIILcom/pspdfkit/configuration/rendering/PageRenderConfiguration;)Landroid/graphics/Bitmap;");
			JValue* __args = stackalloc JValue [5];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			__args [3] = new JValue (p3);
			__args [4] = new JValue ((p4 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p4).Handle);
			global::Android.Graphics.Bitmap __ret = global::Java.Lang.Object.GetObject<global::Android.Graphics.Bitmap> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_renderPageToBitmap_Landroid_content_Context_IIILcom_pspdfkit_configuration_rendering_PageRenderConfiguration_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

		static Delegate cb_save_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSave_Ljava_lang_String_Handler ()
		{
			if (cb_save_Ljava_lang_String_ == null)
				cb_save_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_Save_Ljava_lang_String_);
			return cb_save_Ljava_lang_String_;
		}

		static void n_Save_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Save (p0);
		}
#pragma warning restore 0169

		IntPtr id_save_Ljava_lang_String_;
		public unsafe void Save (string p0)
		{
			if (id_save_Ljava_lang_String_ == IntPtr.Zero)
				id_save_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "save", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_save_Ljava_lang_String_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate cb_save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_;
#pragma warning disable 0169
		static Delegate GetSave_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_Handler ()
		{
			if (cb_save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ == null)
				cb_save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, IntPtr>) n_Save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_);
			return cb_save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_;
		}

		static void n_Save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Document.DocumentSaveOptions p1 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.DocumentSaveOptions> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.Save (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_;
		public unsafe void Save (string p0, global::PSPDFKit.Document.DocumentSaveOptions p1)
		{
			if (id_save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ == IntPtr.Zero)
				id_save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ = JNIEnv.GetMethodID (class_ref, "save", "(Ljava/lang/String;Lcom/pspdfkit/document/DocumentSaveOptions;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (native_p0);
			__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_save_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate cb_saveIfModified;
#pragma warning disable 0169
		static Delegate GetSaveIfModifiedHandler ()
		{
			if (cb_saveIfModified == null)
				cb_saveIfModified = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_SaveIfModified);
			return cb_saveIfModified;
		}

		static bool n_SaveIfModified (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.SaveIfModified ();
		}
#pragma warning restore 0169

		IntPtr id_saveIfModified;
		public unsafe global::System.Boolean SaveIfModified ()
		{
			if (id_saveIfModified == IntPtr.Zero)
				id_saveIfModified = JNIEnv.GetMethodID (class_ref, "saveIfModified", "()Z");
			return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_saveIfModified);
		}

		static Delegate cb_saveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_;
#pragma warning disable 0169
		static Delegate GetSaveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_Handler ()
		{
			if (cb_saveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_ == null)
				cb_saveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_SaveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_);
			return cb_saveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_;
		}

		static bool n_SaveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Document.DocumentSaveOptions p0 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.DocumentSaveOptions> (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.SaveIfModified (p0);
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_saveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_;
		public unsafe global::System.Boolean SaveIfModified (global::PSPDFKit.Document.DocumentSaveOptions p0)
		{
			if (id_saveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_ == IntPtr.Zero)
				id_saveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_ = JNIEnv.GetMethodID (class_ref, "saveIfModified", "(Lcom/pspdfkit/document/DocumentSaveOptions;)Z");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			global::System.Boolean __ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_saveIfModified_Lcom_pspdfkit_document_DocumentSaveOptions_, __args);
			return __ret;
		}

		static Delegate cb_saveIfModified_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetSaveIfModified_Ljava_lang_String_Handler ()
		{
			if (cb_saveIfModified_Ljava_lang_String_ == null)
				cb_saveIfModified_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, bool>) n_SaveIfModified_Ljava_lang_String_);
			return cb_saveIfModified_Ljava_lang_String_;
		}

		static bool n_SaveIfModified_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.SaveIfModified (p0);
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_saveIfModified_Ljava_lang_String_;
		public unsafe global::System.Boolean SaveIfModified (string p0)
		{
			if (id_saveIfModified_Ljava_lang_String_ == IntPtr.Zero)
				id_saveIfModified_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "saveIfModified", "(Ljava/lang/String;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			global::System.Boolean __ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_saveIfModified_Ljava_lang_String_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
			return __ret;
		}

		static Delegate cb_saveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_;
#pragma warning disable 0169
		static Delegate GetSaveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_Handler ()
		{
			if (cb_saveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ == null)
				cb_saveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, bool>) n_SaveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_);
			return cb_saveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_;
		}

		static bool n_SaveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Document.DocumentSaveOptions p1 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Document.DocumentSaveOptions> (native_p1, JniHandleOwnership.DoNotTransfer);
			bool __ret = __this.SaveIfModified (p0, p1);
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_saveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_;
		public unsafe global::System.Boolean SaveIfModified (string p0, global::PSPDFKit.Document.DocumentSaveOptions p1)
		{
			if (id_saveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ == IntPtr.Zero)
				id_saveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_ = JNIEnv.GetMethodID (class_ref, "saveIfModified", "(Ljava/lang/String;Lcom/pspdfkit/document/DocumentSaveOptions;)Z");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (native_p0);
			__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
			global::System.Boolean __ret = JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_saveIfModified_Ljava_lang_String_Lcom_pspdfkit_document_DocumentSaveOptions_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
			return __ret;
		}

		static Delegate cb_setRotationOffset_II;
#pragma warning disable 0169
		static Delegate GetSetRotationOffset_IIHandler ()
		{
			if (cb_setRotationOffset_II == null)
				cb_setRotationOffset_II = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int, int>) n_SetRotationOffset_II);
			return cb_setRotationOffset_II;
		}

		static void n_SetRotationOffset_II (IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetRotationOffset (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_setRotationOffset_II;
		public unsafe void SetRotationOffset (int p0, int p1)
		{
			if (id_setRotationOffset_II == IntPtr.Zero)
				id_setRotationOffset_II = JNIEnv.GetMethodID (class_ref, "setRotationOffset", "(II)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setRotationOffset_II, __args);
		}

		static Delegate cb_setRotationOffsets_Landroid_util_SparseIntArray_;
#pragma warning disable 0169
		static Delegate GetSetRotationOffsets_Landroid_util_SparseIntArray_Handler ()
		{
			if (cb_setRotationOffsets_Landroid_util_SparseIntArray_ == null)
				cb_setRotationOffsets_Landroid_util_SparseIntArray_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_SetRotationOffsets_Landroid_util_SparseIntArray_);
			return cb_setRotationOffsets_Landroid_util_SparseIntArray_;
		}

		static void n_SetRotationOffsets_Landroid_util_SparseIntArray_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Util.SparseIntArray p0 = global::Java.Lang.Object.GetObject<global::Android.Util.SparseIntArray> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetRotationOffsets (p0);
		}
#pragma warning restore 0169

		IntPtr id_setRotationOffsets_Landroid_util_SparseIntArray_;
		public unsafe void SetRotationOffsets (global::Android.Util.SparseIntArray p0)
		{
			if (id_setRotationOffsets_Landroid_util_SparseIntArray_ == IntPtr.Zero)
				id_setRotationOffsets_Landroid_util_SparseIntArray_ = JNIEnv.GetMethodID (class_ref, "setRotationOffsets", "(Landroid/util/SparseIntArray;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setRotationOffsets_Landroid_util_SparseIntArray_, __args);
		}

		static Delegate cb_setWatermarkTextFilteringEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetWatermarkTextFilteringEnabled_ZHandler ()
		{
			if (cb_setWatermarkTextFilteringEnabled_Z == null)
				cb_setWatermarkTextFilteringEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_SetWatermarkTextFilteringEnabled_Z);
			return cb_setWatermarkTextFilteringEnabled_Z;
		}

		static void n_SetWatermarkTextFilteringEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetWatermarkTextFilteringEnabled (p0);
		}
#pragma warning restore 0169

		IntPtr id_setWatermarkTextFilteringEnabled_Z;
		public unsafe void SetWatermarkTextFilteringEnabled (bool p0)
		{
			if (id_setWatermarkTextFilteringEnabled_Z == IntPtr.Zero)
				id_setWatermarkTextFilteringEnabled_Z = JNIEnv.GetMethodID (class_ref, "setWatermarkTextFilteringEnabled", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWatermarkTextFilteringEnabled_Z, __args);
		}

		static Delegate cb_wasModified;
#pragma warning disable 0169
		static Delegate GetWasModifiedHandler ()
		{
			if (cb_wasModified == null)
				cb_wasModified = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, bool>) n_WasModified);
			return cb_wasModified;
		}

		static bool n_WasModified (IntPtr jnienv, IntPtr native__this)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.WasModified ();
		}
#pragma warning restore 0169

		IntPtr id_wasModified;
		public unsafe global::System.Boolean WasModified ()
		{
			if (id_wasModified == IntPtr.Zero)
				id_wasModified = JNIEnv.GetMethodID (class_ref, "wasModified", "()Z");
			return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_wasModified);
		}

		static Delegate cb_getHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_;
#pragma warning disable 0169
		static Delegate GetGetHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_Handler ()
		{
			if (cb_getHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ == null)
				cb_getHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr>) n_GetHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_);
			return cb_getHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_;
		}

		static IntPtr n_GetHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var p1 = global::Android.Runtime.JavaList<global::Java.Lang.Long>.FromJniHandle (native_p1, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Signatures.HashAlgorithm p2 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Signatures.HashAlgorithm> (native_p2, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.NewArray (__this.GetHashForDocumentRange (p0, p1, p2));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_;
		public unsafe byte [] GetHashForDocumentRange (int p0, global::System.Collections.Generic.IList<global::Java.Lang.Long> p1, global::PSPDFKit.Signatures.HashAlgorithm p2)
		{
			if (id_getHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ == IntPtr.Zero)
				id_getHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ = JNIEnv.GetMethodID (class_ref, "getHashForDocumentRange", "(ILjava/util/List;Lcom/pspdfkit/signatures/HashAlgorithm;)[B");
			IntPtr native_p1 = global::Android.Runtime.JavaList<global::Java.Lang.Long>.ToLocalJniHandle (p1);
			JValue* __args = stackalloc JValue [3];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (native_p1);
			__args [2] = new JValue ((p2 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p2).Handle);
			byte [] __ret = (byte []) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHashForDocumentRange_ILjava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
			JNIEnv.DeleteLocalRef (native_p1);
			return __ret;
		}

		static Delegate cb_getHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_;
#pragma warning disable 0169
		static Delegate GetGetHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_Handler ()
		{
			if (cb_getHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ == null)
				cb_getHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>) n_GetHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_);
			return cb_getHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_;
		}

		static IntPtr n_GetHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			global::PSPDFKit.Instant.IInstantPdfDocument __this = global::Java.Lang.Object.GetObject<global::PSPDFKit.Instant.IInstantPdfDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var p0 = global::Android.Runtime.JavaList<global::Java.Lang.Long>.FromJniHandle (native_p0, JniHandleOwnership.DoNotTransfer);
			global::PSPDFKit.Signatures.HashAlgorithm p1 = global::Java.Lang.Object.GetObject<global::PSPDFKit.Signatures.HashAlgorithm> (native_p1, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.NewArray (__this.GetHashForDocumentRange (p0, p1));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_getHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_;
		public unsafe byte [] GetHashForDocumentRange (global::System.Collections.Generic.IList<global::Java.Lang.Long> p0, global::PSPDFKit.Signatures.HashAlgorithm p1)
		{
			if (id_getHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ == IntPtr.Zero)
				id_getHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_ = JNIEnv.GetMethodID (class_ref, "getHashForDocumentRange", "(Ljava/util/List;Lcom/pspdfkit/signatures/HashAlgorithm;)[B");
			IntPtr native_p0 = global::Android.Runtime.JavaList<global::Java.Lang.Long>.ToLocalJniHandle (p0);
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (native_p0);
			__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
			byte [] __ret = (byte []) JNIEnv.GetArray (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getHashForDocumentRange_Ljava_util_List_Lcom_pspdfkit_signatures_HashAlgorithm_, __args), JniHandleOwnership.TransferLocalRef, typeof (byte));
			JNIEnv.DeleteLocalRef (native_p0);
			return __ret;
		}

	}

}
