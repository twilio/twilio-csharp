@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

REM Build
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Twilio.2013.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:true /p:BuildInParallel=true /p:RestorePackages=true /t:Rebuild
if not "%errorlevel%"=="0" goto failure

REM Unit tests
"%GallioEcho%" src\SimpleRestClient.Tests\bin\Release\SimpleRestClient.Tests.dll
"%GallioEcho%" src\Twilio.Api.Tests.Integration\bin\Release\Twilio.Api.Tests.Integration.dll
REM if not "%errorlevel%"=="0" goto failure

REM Package Folders Setup

rd download /s /q  REM delete the old stuff

if not exist download mkdir download
if not exist download\package mkdir download\package

if not exist download\package\twilio mkdir download\package\twilio
if not exist download\package\twilio\lib mkdir download\package\twilio\lib
if not exist download\package\twilio\lib\3.5 mkdir download\package\twilio\lib\3.5

REM Copy files into Nuget Package structure
copy LICENSE.txt download

copy src\Twilio.Api\bin\Release\Twilio.Api.* download\package\twilio\lib\3.5\

REM Create Packages
mkdir Build
cmd /c %nuget% pack "Twilio.nuspec" -BasePath download\package\twilio -o download
if not "%errorlevel%"=="0" goto failure

:success

REM use github status API to indicate commit compile success

exit 0

:failure

REM use github status API to indicate commit compile success

exit -1
