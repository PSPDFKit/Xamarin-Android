using System;
using System.IO;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Java.Interop;

using PSPDFKit.Configuration.Activity;
using PSPDFKit.Document.Providers;
using PSPDFKit.UI;

namespace PSPDFCatalog {

	// This example shows how to create a custom data provider that reads a document from the 'raw' resources
	// of the app. Furthermore, it implements 'IParcelable' to allow using the data provider with 'PdfActivity'.
	public class CustomDataProviderExample : PdfExampleBase {
		protected override string AssetPath => null;

		public override void LaunchExample (Context ctx, PdfActivityConfiguration.Builder configuration)
		{
			// Create an instance of the custom data provider. See the implementation details below.
			var dataProvider = new RawResourceDataProvider (Resource.Raw.guide);

			// Start the activity using our data provider.
			var intent = PdfActivityIntentBuilder.FromDataProvider (ctx, dataProvider)
			                                     .Configuration (configuration.Build ())
			                                     .Build ();

			ctx.StartActivity (intent);
		}

		public class RawResourceDataProvider : InputStreamDataProvider, IParcelable {

			int resId;

			// The size of the raw resource. This will be cached after the first call to 'Size ()'.
			long size = DataProvider.FileSizeUnknown;

			public RawResourceDataProvider (int resId) => this.resId = resId;

			// Return the InputStream for the referenced raw resource.
			protected override Stream OpenInputStream () => Context.Resources.OpenRawResource (resId);

			// This method returns the size of our resource. Android only gives us an 'InputStream' for
			// accessing the resources.
			public override long Size {
				get {
					if (size != DataProvider.FileSizeUnknown)
						return size;

					try {
						if (InputStreamPosition != 0)
							ReopenInputStream ();

						// size = OpenInputStream ().Length;
						// Hack: Length ^ is not implemented so we copy the entire
						// stream into a 'MemoryStream' and get the length out of it.
						// This is not ideal but still doing it for the sake of testing
						// that custom data providers work.
						using (var ms = new MemoryStream ()) {
							var stream = OpenInputStream ();
							stream.CopyTo (ms);
							size = ms.Length;
						}
						return size;
					} catch (System.Exception) {
						return DataProvider.FileSizeUnknown;
					}
				}
			}

			public override string Uid => Context.Resources.GetResourceName (resId);

			// Since we don't know the file name we just return null
			public override string Title => null;

			// The code below is standard Android parcelation code. If you don't know how to implement the Parcelable
			// interface start looking at http://developer.android.com/reference/android/os/Parcelable.html.
			// Link: https://plugins.jetbrains.com/plugin/7332?pr=idea

			public int DescribeContents () => 0;

			// We simply write the id of the PDF resource to the parcel.
			public void WriteToParcel (Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags) => dest.WriteInt (resId);

			// Constructor required for unparcelation, takes a in Parcel and reads the raw resource id from it.
			public RawResourceDataProvider (Parcel inParcel) => resId = inParcel.ReadInt ();

			[ExportField ("CREATOR")] // This must be mapped as 'CREATOR'
			public static RawResourceDataProviderParcelableCreator GetCreator () => new RawResourceDataProviderParcelableCreator ();

			public class RawResourceDataProviderParcelableCreator : Java.Lang.Object, IParcelableCreator {
				public Java.Lang.Object CreateFromParcel (Parcel source) => new RawResourceDataProvider (source);

				public Java.Lang.Object [] NewArray (int size) => new RawResourceDataProvider [size];
			}
		}
	}
}
