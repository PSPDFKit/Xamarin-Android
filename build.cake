#addin nuget:?package=Cake.Git&version=0.21.0

var target = Argument ("target", "Default");

// Nice online pom dependency explorer
// https://jar-download.com/

var PSPDFKIT_VERSION = "6.1.0";
var SERVICERELEASE_VERSION = "0"; // This is combined with the PSPDFKIT_VERSION variable for the NuGet Package version
var RXANDROID_VERSION = "2.1.0";
var RXJAVA_VERSION = "2.2.4"; // Check Reactive-Streams if updated.
var REACTIVESTREAMS_VERSION = "1.0.2";
var YOUTUBE_VERSION = "1.2.2";
var RELINKER_VERSION = "1.3.1";
var KOTLINSTDLIB_VERSION = "1.3.50"; // Check Annotations version if updated.
var KOTLIANNOTATIONS_VERSION = "13.0";
var KOTLINSTDLIBCOMMON_VERSION = "1.3.50";
var YEARCLASS_VERSION = "2.0.0";

var OKHTTP3_VERSION = "3.9.0"; // Check OKIO version if updated.
var OKHTTP3LOGGING_VERSION = "3.9.0";
var OKIO_VERSION = "1.13.0";

var RXANDROIDURL = $"http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava2/rxandroid/{RXANDROID_VERSION}/rxandroid-{RXANDROID_VERSION}.aar";
var RXJAVAURL = $"http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava2/rxjava/{RXJAVA_VERSION}/rxjava-{RXJAVA_VERSION}.jar";
var YOUTUBEURL = $"https://developers.google.com/youtube/android/player/downloads/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}.zip";
var REACTIVESTREAMSURL = $"http://search.maven.org/remotecontent?filepath=org/reactivestreams/reactive-streams/{REACTIVESTREAMS_VERSION}/reactive-streams-{REACTIVESTREAMS_VERSION}.jar";
var RELINKERURL = $"https://dl.bintray.com/keepsafesoftware/Android/com/getkeepsafe/relinker/relinker/{RELINKER_VERSION}/relinker-{RELINKER_VERSION}.aar";
var OKHTTP3URL = $"http://search.maven.org/remotecontent?filepath=com/squareup/okhttp3/okhttp/{OKHTTP3_VERSION}/okhttp-{OKHTTP3_VERSION}.jar";
var OKHTTP3LOGGINGURL = $"https://search.maven.org/remotecontent?filepath=com/squareup/okhttp3/logging-interceptor/{OKHTTP3LOGGING_VERSION}/logging-interceptor-{OKHTTP3LOGGING_VERSION}.jar";
var OKIOURL = $"http://search.maven.org/remotecontent?filepath=com/squareup/okio/okio/{OKIO_VERSION}/okio-{OKIO_VERSION}.jar";
var KOTLINSTDLIBURL = $"http://search.maven.org/remotecontent?filepath=org/jetbrains/kotlin/kotlin-stdlib/{KOTLINSTDLIB_VERSION}/kotlin-stdlib-{KOTLINSTDLIB_VERSION}.jar";
var KOTLINSTDLIBCOMMONURL = $"http://search.maven.org/remotecontent?filepath=org/jetbrains/kotlin/kotlin-stdlib-common/{KOTLINSTDLIBCOMMON_VERSION}/kotlin-stdlib-common-{KOTLINSTDLIBCOMMON_VERSION}.jar";
var KOTLIANNOTATIONSURL = $"http://search.maven.org/remotecontent?filepath=org/jetbrains/annotations/{KOTLIANNOTATIONS_VERSION}/annotations-{KOTLIANNOTATIONS_VERSION}.jar";
var YEARCLASSURL = $"http://search.maven.org/remotecontent?filepath=com/facebook/device/yearclass/yearclass/{YEARCLASS_VERSION}/yearclass-{YEARCLASS_VERSION}.jar";

Task ("FetchDependencies")
	.Does (() => {
		// PSPDFKit.Android
		Information ("Downloading all the dependencies...");
		DownloadFile (RXANDROIDURL, $"./PSPDFKit.Android/Jars/rxandroid-{RXANDROID_VERSION}.aar");
		DownloadFile (RXJAVAURL, $"./PSPDFKit.Android/Jars/rxjava-{RXJAVA_VERSION}.jar");
		DownloadFile (REACTIVESTREAMSURL, $"./PSPDFKit.Android/Jars/reactive-streams-{REACTIVESTREAMS_VERSION}.jar");
		// DownloadFile (YOUTUBEURL, $"./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}.zip");
		DownloadFile (RELINKERURL, $"./PSPDFKit.Android/Jars/relinker-{RELINKER_VERSION}.aar");
		//DownloadFile (KOTLINSTDLIBURL, $"./PSPDFKit.Android/Jars/kotlin-stdlib-{KOTLINSTDLIB_VERSION}.jar");
		//DownloadFile (KOTLINSTDLIBCOMMONURL, $"./PSPDFKit.Android/Jars/kotlin-stdlib-common-{KOTLINSTDLIBCOMMON_VERSION}.jar");
		//DownloadFile (KOTLIANNOTATIONSURL, $"./PSPDFKit.Android/Jars/annotations-{KOTLIANNOTATIONS_VERSION}.jar");
		DownloadFile (YEARCLASSURL, $"./PSPDFKit.Android/Jars/yearclass-{YEARCLASS_VERSION}.jar");
		//DownloadFile (OKHTTP3URL, $"./PSPDFKit.Android/Jars/okhttp-{OKHTTP3_VERSION}.jar");
		//DownloadFile (OKHTTP3LOGGINGURL, $"./PSPDFKit.Android/Jars/logging-interceptor-{OKHTTP3LOGGING_VERSION}.jar");
		//DownloadFile (OKIOURL, $"./PSPDFKit.Android/Jars/okio-{OKIO_VERSION}.jar");
});

Task ("ExtractAars")
	.IsDependentOn ("FetchDependencies")
	.Does (() => {
		Information ("Unzipping needed dependencies...");

		var delDirSettings = new DeleteDirectorySettings { Recursive = true, Force = true };
		if(DirectoryExists ($"./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}"))
			DeleteDirectory ($"./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}", delDirSettings);
		if(DirectoryExists ($"./PSPDFKit.Android/Jars/rxandroid-{RXANDROID_VERSION}"))
			DeleteDirectory ($"./PSPDFKit.Android/Jars/rxandroid-{RXANDROID_VERSION}", delDirSettings);
		if(DirectoryExists ($"./PSPDFKit.Android/Jars/relinker-{RELINKER_VERSION}"))
			DeleteDirectory ($"./PSPDFKit.Android/Jars/relinker-{RELINKER_VERSION}", delDirSettings);

		// Unzip ($"./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}.zip", $"./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{YOUTUBE_VERSION}");
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

Task ("Default")
	.IsDependentOn ("ExtractAars")
	.IsDependentOn ("RestoreNugets")
	.IsDependentOn ("BuildPSPDFKit")
	.Does (() => {
		Information ("Build Done!");
});

Task ("NuGet")
	.IsDependentOn("Default")
	.Does (() =>
{
	if(!DirectoryExists("./nuget/pkgs/"))
		CreateDirectory("./nuget/pkgs");

	var head = GitLogTip("./");
	var commit = head.Sha.Substring (0,7);
	NuGetPack ("./nuget/pspdfkit-android.nuspec", new NuGetPackSettings {
		Version = $"{PSPDFKIT_VERSION}.{SERVICERELEASE_VERSION}+sha.{commit}",
		OutputDirectory = "./nuget/pkgs/",
		BasePath = "./"
	});
});

Task ("Clean")
	.Does (() => {
		if (FileExists ("./PSPDFKit.Android.dll"))
			DeleteFile ("./PSPDFKit.Android.dll");

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
});

Task ("Clean-obj-bin")
	.Does (() => {
		var delDirSettings = new DeleteDirectorySettings { Recursive = true, Force = true };

		var dirs = new [] {
			"./PSPDFKit.Android",
			"./samples/AndroidSample/AndroidSample",
			"./samples/PSPDFCatalog",
			"./samples/XamarinForms/Droid",
			"./samples/XamarinForms/XFSample",
		};

		foreach (var dir in dirs) {
			if (DirectoryExists ($"{dir}/bin/"))
				DeleteDirectory ($"{dir}/bin", delDirSettings);

			if (DirectoryExists ($"{dir}/obj/"))
				DeleteDirectory ($"{dir}/obj", delDirSettings);
		}
});

RunTarget (target);