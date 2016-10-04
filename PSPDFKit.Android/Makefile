MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
PDFKITVERSION=2.6.0
RXANDROIDVERSION=1.2.1
RXJAVAVERSION=1.2.0
YOUTUBEVERSION=1.2.2
RXANDROIDURL=http://search.maven.org/remotecontent?filepath=io/reactivex/rxandroid/$(RXANDROIDVERSION)/rxandroid-$(RXANDROIDVERSION).aar
RXJAVAURL=http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava/$(RXJAVAVERSION)/rxjava-$(RXJAVAVERSION).jar
YOUTUBEURL=https://developers.google.com/youtube/android/player/downloads/YouTubeAndroidPlayerApi-$(YOUTUBEVERSION).zip

all: PSPDFKit.Android.dll

getallthethings:
	curl -L -o Jars/rxandroid-$(RXANDROIDVERSION).aar $(RXANDROIDURL)
	curl -L -o Jars/rxjava-$(RXJAVAVERSION).jar $(RXJAVAURL)
	curl -L -o Jars/YouTubeAndroidPlayerApi-$(YOUTUBEVERSION).zip $(YOUTUBEURL)

extractaars: getallthethings
	unzip Jars/YouTubeAndroidPlayerApi-$(YOUTUBEVERSION).zip -d Jars/YouTubeAndroidPlayerApi-$(YOUTUBEVERSION)/
	unzip Jars/rxandroid-$(RXANDROIDVERSION).aar -d Jars/rxandroid-$(RXANDROIDVERSION)/
	cp Jars/rxandroid-$(RXANDROIDVERSION)/classes.jar Jars/rxandroid-$(RXANDROIDVERSION).jar

nugetrestore:
	nuget restore ../PSPDFKit.Android.sln

PSPDFKit.Android.dll: extractaars nugetrestore

dll: Jars/pspdfkit-$(PDFKITVERSION).aar
	$(MONOXBUILD) /p:Configuration=Release PSPDFKit.Android.csproj
	mkdir -p ../Dll
	cp bin/Release/PSPDFKit.Android.dll ../Dll/PSPDFKit.Android.dll

clean:
	-rm -rf bin/ obj/ *.sln *.userprefs *.dll *.zip ../Dll ../*.userprefs ../packages/ Jars/*.aar Jars/*.zip Jars/*.jar Jars/YouTubeAndroidPlayerApi-$(YOUTUBEVERSION) Jars/rxandroid-$(RXANDROIDVERSION)