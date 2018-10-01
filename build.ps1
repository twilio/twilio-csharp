function Header ($message) {
    Write-Host "`n== $message ==" -foregroundcolor yellow
}

try {
    msbuild /t:clean /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    # .NET Framework 3.5 Target & Tests
    
    Header "Building for .NET Framework 3.5"
    msbuild /t:restore /p:TargetFramework=net35 /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    msbuild /p:TargetFramework=net35 /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    Header "Testing on .NET Framework 3.5"
    .\test\Twilio.Test\bin\Release\net35\win7-x86\Twilio.Test.exe
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    # .NET Framework 4.5.1 Target & Tests

    Header "Building for .NET Framework 4.5.1"
    msbuild /t:restore /p:TargetFramework=net451 /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    msbuild /p:TargetFramework=net451 /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    Header "Testing on .NET Framework 4.5.1"
    .\test\Twilio.Test\bin\Release\net451\win7-x86\Twilio.Test.exe
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    # .NET Standard 1.4 Target & Tests

    Header "Building for .NET Standard 1.4"
    msbuild .\src\Twilio\Twilio.csproj /t:restore /p:TargetFramework=netstandard1.4 /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    msbuild .\test\Twilio.Test\Twilio.Test.csproj /t:restore /p:TargetFramework=netcoreapp2.0 /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    msbuild .\src\Twilio\Twilio.csproj /p:TargetFramework=netstandard1.4 /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    msbuild .\test\Twilio.Test\Twilio.Test.csproj /p:TargetFramework=netcoreapp2.0 /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    Header "Testing on .NET Standard 1.4"
    dotnet run --framework netcoreapp2.0 --project .\test\Twilio.Test\Twilio.Test.csproj
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    # Create the NuGet Package

    Header "Building NuGet Package"
    msbuild .\src\Twilio\Twilio.csproj /t:pack /p:Configuration=Release /verbosity:minimal
    if ($lastExitCode -ne 0) { exit $lastExitCode }

    Move-Item src\Twilio\bin\Release\Twilio.*.nupkg .\
    if ($lastExitCode -ne 0) { exit $lastExitCode }
} catch {
    Write-Host ""
    Write-Host "Caught an exception:" -ForegroundColor Red
    Write-Host "Exception Type: $($_.Exception.GetType().FullName)" -ForegroundColor Red
    Write-Host "Exception Message: $($_.Exception.Message)" -ForegroundColor Red
    exit 1
}
