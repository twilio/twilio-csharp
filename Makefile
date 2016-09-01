test:
	rm -rf Twilio.Tests/obj
	xbuild Twilio.sln
	nunit Twilio.Tests/bin/Debug/Twilio.Tests.dll

release: test
	rm -rf Twilio.Tests/obj
	xbuild /p:Configuration=Release Twilio.sln
	nuget pack Twilio.nuspec
