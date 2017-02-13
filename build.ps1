msbuild /t:clean /verbosity:minimal
if ($lastExitCode -ne 0) { exit $lastExitCode }

msbuild /t:restore /p:TargetFramework=net35 /verbosity:minimal
if ($lastExitCode -ne 0) { exit $lastExitCode }

msbuild /p:TargetFramework=net35 /p:Configuration=Release /verbosity:minimal
if ($lastExitCode -ne 0) { exit $lastExitCode }

.\test\Twilio.Test\bin\Release\net35\Twilio.Test.exe
if ($lastExitCode -ne 0) { exit $lastExitCode }

msbuild .\src\Twilio\Twilio.csproj /t:restore /p:TargetFramework=netstandard1.4 /verbosity:minimal
if ($lastExitCode -ne 0) { exit $lastExitCode }

msbuild .\test\Twilio.Test\Twilio.Test.csproj /t:restore /p:TargetFramework=netcoreapp1.1 /verbosity:minimal
if ($lastExitCode -ne 0) { exit $lastExitCode }

msbuild .\src\Twilio\Twilio.csproj /p:TargetFramework=netstandard1.4 /p:Configuration=Release /verbosity:minimal
if ($lastExitCode -ne 0) { exit $lastExitCode }

msbuild .\test\Twilio.Test\Twilio.Test.csproj /p:TargetFramework=netcoreapp1.1 /p:Configuration=Release /verbosity:minimal
if ($lastExitCode -ne 0) { exit $lastExitCode }

dotnet run --framework netcoreapp1.1 --project .\test\Twilio.Test\Twilio.Test.csproj
if ($lastExitCode -ne 0) { exit $lastExitCode }
