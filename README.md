# Xamarin PSPDFKit.Android Bindings

Xamarin.Android Bindings for PSPDFKit `v4.8.0`

Xamarin.iOS Bindings for PSPDFKit for iOS: [PSPDFKit/Xamarin-iOS](https://github.com/PSPDFKit/Xamarin-iOS)

#### PSPDFKit

The [PSPDFKit SDK](https://pspdfkit.com/) is a framework that allows you to view, annotate, sign, and fill PDF forms on iOS, Android, Windows, macOS, and Web.

[PSPDFKit Instant](https://pspdfkit.com/instant) adds real-time collaboration features to seamlessly share, edit, and annotate PDF documents.

## Building PSPDFKit.Android.dll

### Requirements

PSPDFKit runs on Android devices running:

* **Xamarin.Android >= 7.3.x**
* **64-bit version of JDK 1.8**
* Android **4.4** or newer / API level **19** or higher
* 32/64-bit ARM (armeabi-v7a with NEON/ arm64-v8a) or 32-bit Intel x86 CPU.
* Projects using PSPDFKit.Android.dll **must** set [Target Framework](https://developer.xamarin.com/guides/android/application_fundamentals/understanding_android_api_levels/#framework) to API 26 (Android 8.0).

### Step 1 - Get PSPDFKit .aar File

1. Download PSPDFKit from your [customer portal](https://customers.pspdfkit.com) if you haven't done so already, or [request an evaluation version](https://pspdfkit.com/#trynow).
2. Unzip the file you downloaded in step 1 and copy `pspdfkit-x.x.x.aar` to [`PSPDFKit.Android/Jars`](PSPDFKit.Android/Jars) folder and also copy `pspdfkit-instant-x.x.x.aar` into [`PSPDFKit.Android.Instant/Jars`](PSPDFKit.Android.Instant/Jars) folder.
3. run `./build.sh` (on macOS) or `./build.ps1` (on Windows, PowerShell) command from root directory. This will download additional resources needed by the binding. Note that running this will require you to have [Xamarin](https://www.xamarin.com/platform) already installed on your computer.

**💡 Note:** Ensure the files are really named `pspdfkit-x.x.x.aar` and `pspdfkit-instant-x.x.x.aar` so there is no hidden `.zip` file ending. OS X likes to add these things and doesn't show them by default. Use the Inspector to be sure.

Visual Studio will use the default Java, but this can be customized in Preferences -> SDK Locations -> Java SDK (JDK).

### Step 2 - Get your Dlls

You have two options to get it:

#### Build from PSPDFKit.Android.sln

1. Open `PSPDFKit.Android.sln` in `Visual Studio`.
2. Build the project.
3. Get the dlls from the `PSPDFKit.Android/bin` and `PSPDFKit.Android.Instant/bin` folders.
4. Enjoy.

#### Build from Terminal

1. Just grab `PSPDFKit.Android.dll` and `PSPDFKit.Android.Instant.dll` from the root folder, if you successfuly followed **Step 1** both should be there.
2. Enjoy.

**💡 Note:** `PSPDFKit.Android.Instant.dll` is an **optional** dependency, you only need it if you are using [PSPDFKit Instant](https://pspdfkit.com/instant/) collaboration features in your application.

## Integrating with your own Project

In order to use **PSPDFKit.Android.dll** and **PSPDFKit.Android.Instant.dll** with your own project you will need to add both as a reference to it. You can achieve this by doing the following:

1. Right click in your **References** folder from your project and select **Edit References...**
2. Select **.Net Assembly** tab and click **Browse**
3. Locate your **PSPDFKit.Android.dll** and **PSPDFKit.Android.Instant.dll** copies.

Once you have done this you will need to add some [NuGet](https://www.nuget.org/) packages to you project

* [Xamarin Support Library v4](https://www.nuget.org/packages/Xamarin.Android.Support.v4/)
* [Xamarin Support Library v7 AppCompat](https://www.nuget.org/packages/Xamarin.Android.Support.v7.AppCompat/)
* [Xamarin Support Library v7 RecyclerView](https://www.nuget.org/packages/Xamarin.Android.Support.v7.RecyclerView/)
* [Xamarin Support Library v7 CardView](https://www.nuget.org/packages/Xamarin.Android.Support.v7.CardView/)
* [Xamarin Support Library Design](https://www.nuget.org/packages/Xamarin.Android.Support.Design/)

If you need to know how to add NuGet packages to your Xamarin project please refer to [Walkthrough: Including a NuGet in your project](http://developer.xamarin.com/guides/cross-platform/application_fundamentals/nuget_walkthrough/) from Xamarin site.

## Usage

PSPDFKit can display documents either in a new Activity or a Fragment you include into your hierarchy.

Note that currently only local files are supported for PSPDFKit.

### Xamarin.Android and ProGuard

In order to integrate ProGuard with Xamarin you can read the following [documentation on Xamarin's Site](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/proguard/).

### Checking for Compatibility

You can include PSPDFKit into applications which will be distributed to devices not supported by PSPDFkit. In that case you can attempt initializing and catch PSPDFInitializationFailedException to check for device compatibility.

```csharp
try {
	PSPDFKitGlobal.Initialize(this, "<YOUR LICENSE>");
} catch (PSPDFInitializationFailedException ex) {
	Console.WriteLine ("Current device is not compatible with PSPDFKit: {0}", ex.Message);
}
```

### Display PSPDFKit Activity

* Add PSPDFKit viewer activity to your applications **AndroidManifest.xml**

```xml
<application android:largeHeap="true">
    <activity android:name="com.pspdfkit.ui.PSPDFActivity"
              android:windowSoftInputMode="adjustNothing" />
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

### Display PSPDFKit Fragment

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

### Render Page to a Bitmap

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

### Customization

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

### More Information

For more documentation about PSPDFKit check out [PSPDFKit online documentation](https://pspdfkit.com/guides/android/current) and bundled Javadoc.

## Xamarin Forms

You can use PSPDFKit SDK with Xamarin.Forms in 3 ways:

1. Using a Custom PageRenderer and embedding a `PdfFragment`, see `PdfViewerPageRenderer.cs` and `PdfViewerPage.cs` inside our [provided Xamarin.Forms example](https://github.com/PSPDFKit/Xamarin-iOS/tree/master/Examples/XamarinForms).
2. Showing a `PdfActivity`. See [the provided Xamarin.Forms example](https://github.com/PSPDFKit/Xamarin-iOS/tree/master/Examples/XamarinForms) for further details.
3. Using [Xamarin.Forms embedding](https://blog.xamarin.com/unleashed-embedding-xamarin-forms-in-xamarin-native/), you can take any ContentPage and add it to your native applications.

# PSPDFKit Instant

Support for Instant was added with the Xamarin.Android Bindings for PSPDFKit 4.5.1 for Android.

With PSPDFKit Instant, it’s easier than ever to add real-time collaboration features to your PSPDFKit-powered app, allowing your users to seamlessly share, edit, and annotate PDF documents across iOS, Android, and web. With just a few lines of code, PSPDFKit Instant gives your users a massive productivity boost.

For more information about Instant, please have a look at our [website](https://pspdfkit.com/instant/).

# Examples

You can find several sample projects in the `samples` folder, including a catalog and Xamarin.Forms example.

## How to Run the Example Projects

1. Complete **Step 1** to download additional resources needed for the examples.
2. Open the `PSPDFKit.Android.sln` solution in Visual Studio.
3. Select the example project and device you want to run it on (alternatively you can also right-click on the project and select "Build `Project Name`").
<img width="60%" src="Images/Project-setup.png"/>
4. Tap on the triangle on the left to run the project.

### PSPDFKit Instant Example

This example is included in the PSPDFCatalog example, but you can also find the code [here][Instant Example].

The PSPDFKit Instant example shows how easy and efficient Instant works. Just go the [Instant demo page](https://pspdfkit.com/instant/demo/) and tap on `Instant on Android`, this will show a code at step three, which you have to enter in the example on your device. Afterwards you'll be connected to the server and you can start testing!

<div id="image-table">
     <table>
  	    <tr>
      	    <td>
             <img width="90%" src="Images/Instant-device.png"/>
           </td>
           <td>
             <img width="90%" src="Images/Instant-desktop.png"/>
           </td>
       </tr>
    </table>
</div>


### PSPDFCatalog

The `PSPSDFCatalog` project has various little example projects in it, including a basic example, which opens a demo document in PSPSDFKit, an example for automatically filling out forms, or one for creating a password protected PDF.

<img width="80%" src="Images/Catalog.png"/>


### Xamarin.Forms

`XFSample.Droid` is an example showcasing how to build an app with PSPDFKit using Xamarin.Forms.

<img width="80%" src="Images/XForms.png"/>


### AndroidSimple

`AndroidSimple` is an example project showing showing how to open and present document, or how to open a document from various file providers or the local file directory.

<img width="55%" src="Images/AndroidSimple.png"/>


### Known Issues

**Unsupported devices**

- Samsung Galaxy Note 2 (GT-N7100) / Android 4.4.2 (N7100XXUFND3)
Memory issues because of defective garbage collection.
Source: [https://code.google.com/p/android/issues/detail?id=71073](https://code.google.com/p/android/issues/detail?id=71073)

### Contributing

Please ensure [you signed our CLA](https://pspdfkit.com/guides/web/current/miscellaneous/contributing/) so we can accept your contributions.

[Instant Example]: https://github.com/PSPDFKit/Xamarin-Android/tree/master/samples/PSPDFCatalog/Catalog/Instant
