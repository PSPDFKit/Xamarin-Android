#Xamarin PSPDFKit.Android Bindings

Xamarin.Android Bindings for PSPDFKit `v2.8.1`

## Building PSPDFKit.Android.dll

### Requirements

PSPDFKit runs on Android devices running:

* **Xamarin.Android >= 7.0.x**
* **64-bit version of JDK 1.8**
* Android 4.1 or newer / API level 16 or higher
* 32/64-bit ARM (armeabi-v7a / arm64-v8a) or 32-bit Intel x86 CPU (MIPS and x86-64 builds are available by request and are not included by default due to size constraints.)
* Projects using PSPDFKit.Android.dll **must** set Target Framework to API 24 (Android 7.0).

Note: Building this binding project has only been tested with Xamarin Studio on macOS 10.11+. Other versions or Visual Studio are not supported. That said you can use the resulting PSPDFKit.Android.dll in Visual Studio.

###Step 1 - Get PSPDFKit .aar file

1. Download PSPDFKit from your [customer portal](https://customers.pspdfkit.com) if you haven't done so already, or [request an evaluation version](https://pspdfkit.com/#trynow).
2. Unzip the file you downloaded in step 1 and copy `pspdfkit-x.x.x.aar` to [`PSPDFKit.Android/Jars`](PSPDFKit.Android/Jars) folder.
3. run `make` command from `root` or `binding` directory, this will download additional resources needed by the binding.

Note: Ensure the file is really named  `pspdfkit-x.x.x.aar` and that there's no hidden `.zip` file ending. OS X likes to add these things and doesn't show them by default. Use the Inspector to be sure.

Xamarin Studio will use the default Java, but this can be customized in Preferences -> SDK Locations -> Java SDK (JDK).

### Step 2 - Get your Dll

You have two options to get it:

####Build from PSPDFKit.Android.sln

1. Open `PSPDFKit.Android.sln` in `Xamarin Studio` or `Visual Studio`
2. Build the project
3. Get the dll from the `PSPDFKit.Android/bin` folder
4. Enjoy 

####Build from terminal

1. Just run `make dll` command from `root` or `binding` directory
2. Get the dll from the `Dll` folder
3. Enjoy

Note: Currently building the dll is only supported on OS X 10.11 with Xamarin Studio. We're working on an update that will allow Windows as well.

##Integrating with your own project

In order to use **PSPDFKit.Android.dll** with your own project you will need to add it as a reference to it. You can achieve this by doing the following:

1. Right click in your **References** folder from your project and select **Edit References...**
2. Select **.Net Assembly** tab and click **Browse**
3. Locate your **PSPDFKit.Android.dll** copy

Once you have done this you will need to add some [NuGet](https://www.nuget.org/) packages to you project

* [Xamarin Support Library v4](https://www.nuget.org/packages/Xamarin.Android.Support.v4/)
* [Xamarin Support Library v7 AppCompat](https://www.nuget.org/packages/Xamarin.Android.Support.v7.AppCompat/)
* [Xamarin Support Library v7 RecyclerView](https://www.nuget.org/packages/Xamarin.Android.Support.v7.RecyclerView/)
* [Xamarin Support Library v7 CardView](https://www.nuget.org/packages/Xamarin.Android.Support.v7.CardView/)
* [Xamarin Support Library Design](https://www.nuget.org/packages/Xamarin.Android.Support.Design/)

If you need to know how to add NuGet packages to your Xamarin project please refer to [Walkthrough: Including a NuGet in your project](http://developer.xamarin.com/guides/cross-platform/application_fundamentals/nuget_walkthrough/) from Xamarin site.

##Usage

PSPDFKit can display documents either in a new Activity or a Fragment you include into your hierarchy.

Note that currently only local files are supported for PSPDFKit.

###Checking for compatibility

You can include PSPDFKit into applications which will be distributed to devices not supported by PSPDFkit. In that case you can attempt initializing and catch PSPDFInitializationFailedException to check for device compatibility.

```csharp
try {
	PSPDFKitGlobal.Initialize(this, "<YOUR LICENSE>");
} catch (PSPDFInitializationFailedException ex) {
	Console.WriteLine ("Current device is not compatible with PSPDFKit: {0}", ex.Message);
}
```

###Display PSPDFKit Activity

* Add PSPDFKit viewer activity to your applications **AndroidManifest.xml**

```xml
<application android:largeHeap="true">
    <activity android:name="com.pspdfkit.ui.PSPDFActivity"
              android:windowSoftInputMode="adjustNothing">
</application>
```

>You can use android:theme attribute to customize actionbar, background and other elements of the activity theme if you so desire. Note that if you want to use appcompat-v7 material themes, you'll have to use `PSPDFAppCompatActivity` instead of `PSPDFActivity`. 

* Make sure you have `android:largeHeap="true"` property in your `<application>` tag in **AndroidManifest.xml**. Rendering PDF files is memory intensive and this property will ensure your app has enough heap allocated to avoid out of memory errors.

* Create `PSPDFActivityConfiguration` object and then call `PSPDFActivity.ShowDocument()` to display the document. Document location is expressed with an Uri object.

```csharp
var pdfDocument = Android.Net.Uri.FromFile (new Java.IO.File (Android.OS.Environment.ExternalStorageDirectory, "document.pdf"));
var configuration = new PSPDFActivityConfiguration.Builder("<YOUR_LICENSE>").Build();
PSPDFActivity.ShowDocument(this, pdfDocument, configuration);
```

>You can create an Uri object from file using `Android.Net.Uri.FromFile(File)` call or you can pass in Uri returned by [Storage Access Framework](https://developer.android.com/guide/topics/providers/document-provider.html). For all configuration options refer to included JavaDoc.

###Display PSPDFKit Fragment

* Make sure you have `android:largeHeap="true"` property in your `<application>` tag in **AndroidManifest.xml**. Rendering PDF files is memory intensive and this property will ensure your app has enough heap allocated to avoid out of memory errors.

```xml
<application android:largeHeap="true">
    ...
</application>
```

* Create `PSPDFConfiguration` object and then call `PSPDFFragment.NewInstance()` to create a new Fragment instance for a document.
* Attach Fragment to your view hiearchy. Remember that fragments are retained over configuration changes, so do not recreate fragment if it's already attached - that will lead to bugs and out of memory errors.

```csharp
var pdfDocument = Android.Net.Uri.FromFile (new Java.IO.File (Android.OS.Environment.ExternalStorageDirectory, "document.pdf"));
var configuration = new PSPDFConfiguration.Builder("<YOUR_LICENSE>")
	.ScrollDirection (PageScrollDirection.Horizontal)
	.Build();

var fragment = PSPDFFragment.NewInstance(pdfDocument, configuration);
SupportFragmentManager.BeginTransaction().Replace(Resource.Id.Content, fragment).Commit();
```

>Note that the Fragment extends Android.Support.V4.App.Fragment and not Android.App.Fragment.

###Render page to a bitmap

You can use PSPDFKit to render PDF to bitmaps without showing them in activities. To do that, use PSPDFKit and PSPDFDocument class calls.

Example:

```csharp
PSPDFKitGlobal.Initialize (this, "<YOUR LICENSE>");
try {
	var pdfDocument = PSPDFKitGlobal.OpenDocument (this, Android.Net.Uri.FromFile (new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory, "document.pdf")));
	var pageToRender = 1; // This is 0-indexed, use pdfDocument.PageCount to retrieve number of pages
	var pageBitmap = pdfDocument.RenderPageToBitmap(this,
		pageToRender,
		// This is the size of bitmap that will be generated
		pdfDocument.GetPageSize (pageToRender).Width,
		pdfDocument.GetPageSize (pageToRender).Height);
} catch (IOException ex) {
	Console.WriteLine ("Failed to open PDF document: {0}", ex.Message);
}
```

###Customization

To customize PSPDFKit Activity UI elements use standard Android themes. When using AppCompat, PSPDFKit will color actionbar and other elements according to colorPrimary and colorAccent attributes. Example theme definition:

```xml
<style name="MyApplicationTheme.Theme" parent="Theme.AppCompat.Light.DarkActionBar">
    <item name="colorPrimary">@color/mymain_color</item>
    <item name="colorPrimaryDark">@color/mymain_color_dark</item>
    <item name="colorAccent">@color/mymain_color_accent</item>
</style>
```

And then it should be applied in AndroidManifest.xml:

```xml
<activity android:name="com.pspdfkit.ui.PSPDFAppCompatActivity"
      android:windowSoftInputMode="adjustNothing"
      android:theme="@style/MyApplicationTheme.Theme" />
```

Other configuration options for UI elements (icons, element sizes) can be found in `PSPDFActivityConfiguration` class.

###More information

For more documentation about PSPDFKit check out [PSPDFKit online documentation](https://pspdfkit.com/guides/android/current) and bundled Javadoc.

###Known Issues

**Unsupported devices**

- Samsung Galaxy Note 2 (GT-N7100) / Android 4.4.2 (N7100XXUFND3)
Memory issues because of defective garbage collection.
Source: [https://code.google.com/p/android/issues/detail?id=71073](https://code.google.com/p/android/issues/detail?id=71073)
