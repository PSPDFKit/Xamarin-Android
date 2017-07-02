MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild
PDFKITVERSION=3.2.1
RXANDROIDVERSION=2.0.1
RXJAVAVERSION=2.1.1
YOUTUBEVERSION=1.2.2
REACTIVESTREAMSVERSION=1.0.0.final
RXANDROIDURL=http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava2/rxandroid/$(RXANDROIDVERSION)/rxandroid-$(RXANDROIDVERSION).aar
RXJAVAURL=http://search.maven.org/remotecontent?filepath=io/reactivex/rxjava2/rxjava/$(RXJAVAVERSION)/rxjava-$(RXJAVAVERSION).jar
YOUTUBEURL=https://developers.google.com/youtube/android/player/downloads/YouTubeAndroidPlayerApi-$(YOUTUBEVERSION).zip
REACTIVESTREAMSURL=http://search.maven.org/remotecontent?filepath=org/reactivestreams/reactive-streams/$(REACTIVESTREAMSVERSION)/reactive-streams-$(REACTIVESTREAMSVERSION).jar

all: PSPDFKit.Android.dll

getallthethings:
	curl -L -o Jars/rxandroid-$(RXANDROIDVERSION).aar $(RXANDROIDURL)
	curl -L -o Jars/rxjava-$(RXJAVAVERSION).jar $(RXJAVAURL)
	curl -L -o Jars/reactive-streams-$(REACTIVESTREAMSVERSION).jar $(REACTIVESTREAMSURL)
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