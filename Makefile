
install:
	dotnet clean
	dotnet restore

test:
	dotnet clean
	dotnet restore 
	dotnet build
	dotnet run --project test/Twilio.Tests/Twilio.Tests.csproj

release: test
	dotnet clean
	dotnet restore -c Release
	dotnet build -c Release
	dotnet pack src/Twilio/Twilio.csproj -c Release -o .
