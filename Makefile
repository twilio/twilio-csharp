
clean:
	dotnet clean

install:
	dotnet restore

test:
	dotnet restore
	dotnet build
	dotnet run --project test/Twilio.Tests/Twilio.Tests.csproj

release: test
	dotnet restore -c Release
	dotnet build -c Release
	dotnet pack src/Twilio/Twilio.csproj -c Release -o .
