build:
	xbuild src/Twilio.sln

develop: install-mono
	echo "#!/bin/sh\nexec /Library/Frameworks/Mono.framework/Versions/Current/bin/mono --debug \$$MONO_OPTIONS /Library/Frameworks/Mono.framework/Versions/Current/lib/mono/4.5/nunit-console.exe \"\$$@\"" > /usr/local/bin/nunit

install-mono:
	brew install mono

test: build-tests
	for i in src/*Tests/bin/Debug/*.Tests*.dll; do nunit "$$i"; done

build-tests:
	for i in src/*Tests/*.Tests*.csproj; do xbuild "$$i"; done

