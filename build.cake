#addin nuget:?package=Cake.Git

var target = Argument ("target", "Default");

// Nice online pom dependency explorer
// https://jar-download.com/

var PSPDFKIT_VERSION = "4.8.0";
var RXANDROID_VERSION = "2.0.1";
var RXJAVA_VERSION = "2.1.3"; // Check Reactive-Streams if updated.
var REACTIVESTREAMS_VERSION = "1.0.1";
var YOUTUBE_VERSION = "1.2.2";
var RELINKER_VERSION = "1.2.2";
var KOTLINSTDLIB_VERSION = "1.2.21"; // Check Annotations version if updated.
var KOTLIANNOTATIONS_VERSION = "13.0";
var YEARCLASS_VERSION = "2.0.0";

var OKHTTP3_VERSION = "3.9.0"; // Check OKIO version if updated.
var OKIO_VERSION = "1.13.0";

var RXANDROIDURL = $"http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava2/rxandroid/{RXANDROID_VERSION}/rxandroid-{RXANDROID_VERSION}.aar";
var RXJAVAURL = $"http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava2/rxjava/{RXJAVA_VERSION}/rxjava-{RXJAVA_VERSION}.jar";
var YOUTUBEURL = $"https://developers.google.com/youtube/android/player/downloads/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}.zip";
var REACTIVESTREAMSURL = $"http://search.maven.org/remotecontent?filepath=org/reactivestreams/reactive-streams/{REACTIVESTREAMS_VERSION}/reactive-streams-{REACTIVESTREAMS_VERSION}.jar";
var RELINKERURL = $"https://dl.bintray.com/keepsafesoftware/Android/com/getkeepsafe/relinker/relinker/{RELINKER_VERSION}/relinker-{RELINKER_VERSION}.aar";
var OKHTTP3URL = $"http://search.maven.org/remotecontent?filepath=com/squareup/okhttp3/okhttp/{OKHTTP3_VERSION}/okhttp-{OKHTTP3_VERSION}.jar";
var OKIOURL = $"http://search.maven.org/remotecontent?filepath=com/squareup/okio/okio/{OKIO_VERSION}/okio-{OKIO_VERSION}.jar";
var KOTLINSTDLIBURL = $"http://search.maven.org/remotecontent?filepath=org/jetbrains/kotlin/kotlin-stdlib/{KOTLINSTDLIB_VERSION}/kotlin-stdlib-{KOTLINSTDLIB_VERSION}.jar";
var KOTLIANNOTATIONSURL = $"http://search.maven.org/remotecontent?filepath=org/jetbrains/annotations/{KOTLIANNOTATIONS_VERSION}/annotations-{KOTLIANNOTATIONS_VERSION}.jar";
var YEARCLASSURL = $"http://search.maven.org/remotecontent?filepath=com/facebook/device/yearclass/yearclass/{YEARCLASS_VERSION}/yearclass-{YEARCLASS_VERSION}.jar";

Task ("FetchDependencies")
	.Does (() => {
		// PSPDFKit.Android
		Information ("Downloading all the dependencies...");
		DownloadFile (RXANDROIDURL, $"./PSPDFKit.Android/Jars/rxandroid-{RXANDROID_VERSION}.aar");
		DownloadFile (RXJAVAURL, $"./PSPDFKit.Android/Jars/rxjava-{RXJAVA_VERSION}.jar");
		DownloadFile (REACTIVESTREAMSURL, $"./PSPDFKit.Android/Jars/reactive-streams-{REACTIVESTREAMS_VERSION}.jar");
		DownloadFile (YOUTUBEURL, $"./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}.zip");
		DownloadFile (RELINKERURL, $"./PSPDFKit.Android/Jars/relinker-{RELINKER_VERSION}.aar");
		DownloadFile (KOTLINSTDLIBURL, $"./PSPDFKit.Android/Jars/kotlin-stdlib-{KOTLINSTDLIB_VERSION}.jar");
		DownloadFile (KOTLIANNOTATIONSURL, $"./PSPDFKit.Android/Jars/annotations-{KOTLIANNOTATIONS_VERSION}.jar");
		DownloadFile (YEARCLASSURL, $"./PSPDFKit.Android/Jars/yearclass-{YEARCLASS_VERSION}.jar");
		
		// PSPDFKit.Android.Instant
		DownloadFile (OKHTTP3URL, $"./PSPDFKit.Android.Instant/Jars/okhttp-{OKHTTP3_VERSION}.jar");
		DownloadFile (OKIOURL, $"./PSPDFKit.Android.Instant/Jars/okio-{OKIO_VERSION}.jar");
});

Task ("ExtractAars")
	.IsDependentOn ("FetchDependencies")
	.Does (() => {
		Information ("Unzipping needed dependencies...");
		Unzip ($"./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}.zip", $"./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}");
		Unzip ($"./PSPDFKit.Android/Jars/rxandroid-{RXANDROID_VERSION}.aar", $"./PSPDFKit.Android/Jars/rxandroid-{RXANDROID_VERSION}");
		Unzip ($"./PSPDFKit.Android/Jars/relinker-{RELINKER_VERSION}.aar", $"./PSPDFKit.Android/Jars/relinker-{RELINKER_VERSION}");
		CopyFile ($"./PSPDFKit.Android/Jars/rxandroid-{RXANDROID_VERSION}/classes.jar", $"./PSPDFKit.Android/Jars/rxandroid-{RXANDROID_VERSION}.jar");
		CopyFile ($"./PSPDFKit.Android/Jars/relinker-{RELINKER_VERSION}/classes.jar", $"./PSPDFKit.Android/Jars/relinker-{RELINKER_VERSION}.jar");
});

Task ("RestoreNugets")
	.Does (() => {
		Information ("Restoring NuGets...");
		NuGetRestore ("./PSPDFKit.Android.sln");
});

Task ("BuildPSPDFKit")
	.Does (() => {
		if (FileExists ($"./PSPDFKit.Android/Jars/pspdfkit-{PSPDFKIT_VERSION}.aar")) {
			Information ("Building PSPDFKit.Android.dll");
			Information ("PLEASE WAIT, it might take a few minutes to build...");
			MSBuild ("./PSPDFKit.Android/PSPDFKit.Android.csproj", new MSBuildSettings ()
				.SetConfiguration ("Release")
			);
			if (FileExists ("./PSPDFKit.Android/bin/Release/PSPDFKit.Android.dll"))
				CopyFile ("./PSPDFKit.Android/bin/Release/PSPDFKit.Android.dll", "./PSPDFKit.Android.dll");
		} else {
			Warning ($"./PSPDFKit.Android/Jars/pspdfkit-{PSPDFKIT_VERSION}.aar file not found.");
			Warning ($"PSPDFKit.Android.dll was not built.");
		}
});

Task ("BuildInstant")
	.Does (() => {
		if (FileExists ($"./PSPDFKit.Android.Instant/Jars/pspdfkit-instant-{PSPDFKIT_VERSION}.aar")) {
			Information ("Building PSPDFKit.Android.Instant.dll");
			Information ("PLEASE WAIT, it might take a few minutes to build...");
			MSBuild ("./PSPDFKit.Android.Instant/PSPDFKit.Android.Instant.csproj", new MSBuildSettings ()
				.SetConfiguration ("Release")
			);
			if (FileExists ("./PSPDFKit.Android.Instant/bin/Release/PSPDFKit.Android.Instant.dll"))
				CopyFile ("./PSPDFKit.Android.Instant/bin/Release/PSPDFKit.Android.Instant.dll", "./PSPDFKit.Android.Instant.dll");
		} else {
			Warning ($"./PSPDFKit.Android.Instant/Jars/pspdfkit-instant-{PSPDFKIT_VERSION}.aar file not found.");
			Warning ($"PSPDFKit.Android.Instant.dll was not built.");
		}
});

Task ("Default")
	.IsDependentOn ("ExtractAars")
	.IsDependentOn ("RestoreNugets")
	.IsDependentOn ("BuildPSPDFKit")
	.IsDependentOn ("BuildInstant")
	.Does (() => {
		Information ("Build Done!");
});

Task ("Clean")
	.Does (() => {
		if (FileExists ("./PSPDFKit.Android.dll"))
			DeleteFile ("./PSPDFKit.Android.dll");

		if (FileExists ("./PSPDFKit.Android.Instant.dll"))
			DeleteFile ("./PSPDFKit.Android.Instant.dll");

		var delDirSettings = new DeleteDirectorySettings { Recursive = true, Force = true };

		if (DirectoryExists ("./packages/"))
			DeleteDirectory ("./packages", delDirSettings);

		if (DirectoryExists ("./PSPDFKit.Android/bin/"))
			DeleteDirectory ("./PSPDFKit.Android/bin", delDirSettings);

		if (DirectoryExists ("./PSPDFKit.Android/obj/"))
			DeleteDirectory ("./PSPDFKit.Android/obj", delDirSettings);

		if (DirectoryExists ("./PSPDFKit.Android/Jars/")) {
			DeleteDirectory ("./PSPDFKit.Android/Jars", delDirSettings);
			GitCheckout ("./", new FilePath [] { "./PSPDFKit.Android/Jars" });
		}

		if (DirectoryExists ("./PSPDFKit.Android.Instant/bin/"))
			DeleteDirectory ("./PSPDFKit.Android.Instant/bin", delDirSettings);

		if (DirectoryExists ("./PSPDFKit.Android.Instant/obj/"))
			DeleteDirectory ("./PSPDFKit.Android.Instant/obj", delDirSettings);

		if (DirectoryExists ("./PSPDFKit.Android.Instant/Jars/")) {
			DeleteDirectory ("./PSPDFKit.Android.Instant/Jars", delDirSettings);
			GitCheckout ("./", new FilePath [] { "./PSPDFKit.Android.Instant/Jars" });
		}
});

RunTarget (target);