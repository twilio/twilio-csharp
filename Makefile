test:
	xbuild Twilio.sln
	nunit Twilio.Tests/bin/Debug/Twilio.Tests.dll
