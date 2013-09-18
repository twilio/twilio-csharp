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
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild src\Twilio.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:true /p:BuildInParallel=true /p:RestorePackages=true /t:Rebuild
REM if not "%errorlevel%"=="0" goto failure

REM Unit tests
REM "%GallioEcho%" src\Twilio.Api.Tests.Integration\bin\Release\Twilio.Api.Tests.Integration.dll
REM if not "%errorlevel%"=="0" goto failure

REM Package Folders Setup

rd download /s /q  REM delete the old stuff

if not exist download mkdir download
if not exist download\package mkdir download\package

if not exist download\package\twilio mkdir download\package\twilio
if not exist download\package\twilio\lib mkdir download\package\twilio\lib
if not exist download\package\twilio\lib\3.5 mkdir download\package\twilio\lib\3.5
if not exist download\package\twilio\lib\SL4-WINDOWSPHONE71 mkdir download\package\twilio\lib\SL4-WINDOWSPHONE71
if not exist download\package\twilio\lib\SL4 mkdir download\package\twilio\lib\SL4

if not exist download\package\twiliomvc mkdir download\package\twiliomvc
if not exist download\package\twiliomvc\lib mkdir download\package\twiliomvc\lib
if not exist download\package\twiliomvc\lib\3.5 mkdir download\package\twiliomvc\lib\3.5

if not exist download\package\twiliotwiml mkdir download\package\twiliotwiml
if not exist download\package\twiliotwiml\lib mkdir download\package\twiliotwiml\lib
if not exist download\package\twiliotwiml\lib\3.5 mkdir download\package\twiliotwiml\lib\3.5

if not exist download\package\twiliowebmatrix mkdir download\package\twiliowebmatrix
if not exist download\package\twiliowebmatrix\lib mkdir download\package\twiliowebmatrix\lib
if not exist download\package\twiliowebmatrix\lib\3.5 mkdir download\package\twiliowebmatrix\lib\3.5

if not exist download\package\twilioclient mkdir download\package\twilioclient
if not exist download\package\twilioclient\lib mkdir download\package\twilioclient\lib
if not exist download\package\twilioclient\lib\3.5 mkdir download\package\twilioclient\lib\3.5

REM Copy files into Nuget Package structure
copy LICENSE.txt download

copy src\Twilio.Api\bin\Release\Twilio.Api.* download\package\twilio\lib\3.5\
copy src\Twilio.Api.Silverlight\bin\Release\Twilio.Api.Silverlight.* download\package\twilio\lib\SL4\
copy src\Twilio.Api.WindowsPhone\bin\Release\Twilio.Api.WindowsPhone.* download\package\twilio\lib\SL4-WINDOWSPHONE71\

copy src\Twilio.Mvc\bin\Release\Twilio.Mvc.* download\package\twiliomvc\lib\3.5\
copy src\Twilio.Twiml\bin\Release\Twilio.Twiml.* download\package\twiliotwiml\lib\3.5\
copy src\Twilio.WebMatrix\bin\Release\Twilio.WebMatrix.* download\package\twiliowebmatrix\lib\3.5\
copy src\Twilio.Client.Capability\bin\Release\Twilio.Client.Capability.* download\package\twilioclient\lib\3.5\

REM Create Packages
mkdir Build
cmd /c %nuget% pack "Twilio.nuspec" -BasePath download\package\twilio -o download
cmd /c %nuget% pack "Twilio.Mvc.nuspec" -BasePath download\package\twiliomvc -o download
cmd /c %nuget% pack "Twilio.TwiML.nuspec" -BasePath download\package\twiliotwiml -o download
cmd /c %nuget% pack "Twilio.WebMatrix.nuspec" -BasePath download\package\twiliowebmatrix -o download
cmd /c %nuget% pack "Twilio.Client.nuspec" -BasePath download\package\twilioclient -o download
if not "%errorlevel%"=="0" goto failure

:success

REM use github status API to indicate commit compile success

exit 0

:failure

REM use github status API to indicate commit compile success

exit -1
