
install:
	dotnet restore Twilio/Twilio.csproj

test:
	rm -rf Twilio.Tests/obj
	dotnet build Twilio/Twilio.csproj
	nunit Twilio.Tests/bin/Debug/Twilio.Tests.dll

release: test
	rm -rf Twilio.Tests/obj
	xbuild /p:Configuration=Release Twilio.sln
	nuget pack Twilio.nuspec
