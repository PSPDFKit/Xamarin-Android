#addin nuget:?package=Cake.Git

var target = Argument ("target", "Default");

var PSPDFKIT_VERSION = "3.3.1";
var RXANDROID_VERSION = "2.0.1";
var RXJAVA_VERSION = "2.1.1";
var YOUTUBE_VERSION = "1.2.2";
var REACTIVESTREAMS_VERSION = "1.0.0.final";

var RXANDROIDURL = string.Format ("http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava2/rxandroid/{0}/rxandroid-{0}.aar", RXANDROID_VERSION);
var RXJAVAURL = string.Format ("http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava2/rxjava/{0}/rxjava-{0}.jar", RXJAVA_VERSION);
var YOUTUBEURL = string.Format ("https://developers.google.com/youtube/android/player/downloads/YouTubeAndroidPlayerApi-{0}.zip", YOUTUBE_VERSION);
var REACTIVESTREAMSURL = string.Format ("http://search.maven.org/remotecontent?filepath=org/reactivestreams/reactive-streams/{0}/reactive-streams-{0}.jar", REACTIVESTREAMS_VERSION);

Task ("FetchDependencies")
	.Does (() => {
		Information ("Downloading all the dependencies...");
		DownloadFile (RXANDROIDURL, string.Format ("./PSPDFKit.Android/Jars/rxandroid-{0}.aar", RXANDROID_VERSION));
		DownloadFile (RXJAVAURL, string.Format ("./PSPDFKit.Android/Jars/rxjava-{0}.jar", RXJAVA_VERSION));
		DownloadFile (REACTIVESTREAMSURL, string.Format ("./PSPDFKit.Android/Jars/reactive-streams-{0}.jar", REACTIVESTREAMS_VERSION));
		DownloadFile (YOUTUBEURL, string.Format ("./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{0}.zip", YOUTUBE_VERSION));
});

Task ("ExtractAars")
	.IsDependentOn ("FetchDependencies")
	.Does (() => {
		Information ("Unzipping needed dependencies...");
		Unzip (string.Format ("./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{0}.zip", YOUTUBE_VERSION), string.Format ("./PSPDFKit.Android/Jars/YouTubeAndroidPlayerApi-{0}", YOUTUBE_VERSION));
		Unzip (string.Format ("./PSPDFKit.Android/Jars/rxandroid-{0}.aar", RXANDROID_VERSION), string.Format ("./PSPDFKit.Android/Jars/rxandroid-{0}", RXANDROID_VERSION));
		CopyFile (string.Format ("./PSPDFKit.Android/Jars/rxandroid-{0}/classes.jar", RXANDROID_VERSION), string.Format ("./PSPDFKit.Android/Jars/rxandroid-{0}.jar", RXANDROID_VERSION));
});

Task ("Default")
	.IsDependentOn ("ExtractAars")
	.Does (() => {
		Information ("Restoring NuGets...");
		NuGetRestore ("./PSPDFKit.Android.sln");
		if (FileExists (string.Format ("./PSPDFKit.Android/Jars/pspdfkit-{0}.aar", PSPDFKIT_VERSION))) {
			Information ("Building PSPDFKit.Android.dll");
			Information ("PLEASE WAIT, it might take a few minutes to build...");
			MSBuild ("./PSPDFKit.Android/PSPDFKit.Android.csproj", new MSBuildSettings ()
				.SetConfiguration ("Release")
			);
			if (FileExists ("./PSPDFKit.Android/bin/Release/PSPDFKit.Android.dll"))
				CopyFile ("./PSPDFKit.Android/bin/Release/PSPDFKit.Android.dll", "./PSPDFKit.Android.dll");
		}
		Information ("DONE!");
});

Task ("Clean")
	.Does (() => {
		if (FileExists ("./PSPDFKit.Android.dll"))
			DeleteFile ("./PSPDFKit.Android.dll");

		if (DirectoryExists ("./packages/"))
			DeleteDirectory ("./packages", true);

		if (DirectoryExists ("./PSPDFKit.Android/bin/"))
			DeleteDirectory ("./PSPDFKit.Android/bin", true);
		
		if (DirectoryExists ("./PSPDFKit.Android/obj/"))
			DeleteDirectory ("./PSPDFKit.Android/obj", true);
		
		if (DirectoryExists ("./PSPDFKit.Android/Jars/")) {
			DeleteDirectory ("./PSPDFKit.Android/Jars", true);
			GitCheckout ("./", new FilePath [] { "./PSPDFKit.Android/Jars" });
		}
});

RunTarget (target);