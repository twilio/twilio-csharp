
install:
	dotnet restore Twilio/Twilio.csproj

test:
	rm -rf Twilio.Tests/obj
	dotnet restore Twilio.Tests/Twilio.Tests.csproj
	dotnet build Twilio.Tests/Twilio.Tests.csproj
	dotnet run --project Twilio.Tests/Twilio.Tests.csproj

release: test
	rm -rf Twilio.Tests/obj
	xbuild /p:Configuration=Release Twilio.sln
	nuget pack Twilio.nuspec
