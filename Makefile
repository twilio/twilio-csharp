.PHONY: clean test install release

clean:
	dotnet clean

install:
	dotnet restore

test:
	dotnet restore
	dotnet build --framework netstandard1.5 src/Twilio/Twilio.csproj
	dotnet build --framework netcoreapp1.1 test/Twilio.Test/Twilio.Test.csproj
	dotnet run --project test/Twilio.Test/Twilio.Test.csproj

release: test
	dotnet restore -c Release
	dotnet build -c Release
	dotnet pack src/Twilio/Twilio.csproj -c Release -o .
