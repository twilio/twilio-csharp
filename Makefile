
install:
	dotnet restore Twilio/Twilio.csproj

test:
	rm -rf Twilio.Tests/obj
	dotnet restore Twilio.Tests/Twilio.Tests.csproj
	dotnet build Twilio.Tests/Twilio.Tests.csproj
	dotnet run --project Twilio.Tests/Twilio.Tests.csproj

release: test
	rm -rf Twilio/obj
	dotnet restore /p:Configuration=Release Twilio/Twilio.csproj
	dotnet build /p:Configuration=Release Twilio/Twilio.csproj
	xbuild /p:Configuration=Release Twilio35/Twilio35.csproj
	nuget pack Twilio.nuspec
