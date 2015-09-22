all:
	xbuild src/Twilio.sln

develop:
	brew install mono
	echo "#!/bin/sh\nexec /Library/Frameworks/Mono.framework/Versions/Current/bin/mono --debug \$$MONO_OPTIONS /Library/Frameworks/Mono.framework/Versions/Current/lib/mono/4.5/nunit-console.exe \"\$$@\"" > /usr/local/bin/nunit
	xbuild src/Twilio.sln

test:
	for i in src/*Tests/bin/Debug/*.Tests*.dll; do nunit "$$i"; done

