.PHONY: clean test install release docs

clean:
	dotnet clean

install:
	dotnet restore

test:
	dotnet restore
	dotnet build --framework netstandard1.4 src/Twilio/Twilio.csproj
	dotnet build --framework netcoreapp1.1 test/Twilio.Test/Twilio.Test.csproj
	dotnet run --framework netcoreapp1.1 --project test/Twilio.Test/Twilio.Test.csproj

release: test
	dotnet build -c Release
	dotnet pack src/Twilio/Twilio.csproj -c Release -o .

docs:
	doxygen Doxyfile