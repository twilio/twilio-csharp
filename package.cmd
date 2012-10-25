tools\nuget.exe update -self

rd download /s /q

if not exist download mkdir download
if not exist download\WindowsPhone mkdir download\WindowsPhone
if not exist download\Silverlight mkdir download\Silverlight
if not exist download\package mkdir download\package
if not exist download\package\twilio mkdir download\package\twilio
if not exist download\package\twiliomvc mkdir download\package\twiliomvc
if not exist download\package\twiliotwiml mkdir download\package\twiliotwiml
if not exist download\package\twiliowebmatrix mkdir download\package\twiliowebmatrix
if not exist download\package\twilioclient mkdir download\package\twilioclient

if not exist download\package\twilio\lib mkdir download\package\twilio\lib
if not exist download\package\twilio\lib\3.5 mkdir download\package\twilio\lib\3.5
REM if not exist download\package\twilio\lib\SL3-WP7 mkdir download\package\twilio\lib\SL3-WP7
if not exist download\package\twilio\lib\SL4-WINDOWSPHONE71 mkdir download\package\twilio\lib\SL4-WINDOWSPHONE71
if not exist download\package\twilio\lib\SL4 mkdir download\package\twilio\lib\SL4

if not exist download\package\twiliomvc\lib mkdir download\package\twiliomvc\lib
if not exist download\package\twiliomvc\lib\3.5 mkdir download\package\twiliomvc\lib\3.5

if not exist download\package\twiliotwiml\lib mkdir download\package\twiliotwiml\lib
if not exist download\package\twiliotwiml\lib\3.5 mkdir download\package\twiliotwiml\lib\3.5

if not exist download\package\twiliowebmatrix\lib mkdir download\package\twiliowebmatrix\lib
if not exist download\package\twiliowebmatrix\lib\3.5 mkdir download\package\twiliowebmatrix\lib\3.5

if not exist download\package\twilioclient\lib mkdir download\package\twilioclient\lib
if not exist download\package\twilioclient\lib\3.5 mkdir download\package\twilioclient\lib\3.5

tools\ilmerge.exe /lib:src\Twilio.Api\bin\Release /internalize /ndebug /v2 /out:download\Twilio.Api.dll Twilio.Api.dll RestSharp.dll
tools\ilmerge.exe /lib:src\Twilio.Api.Silverlight\bin\Release /internalize /ndebug /targetplatform:v4,"C:\Program Files (x86)\Microsoft Silverlight\4.1.10111.0" /out:download\Twilio.Api.Silverlight.dll RestSharp.Silverlight.dll

copy src\Twilio.Api\bin\Release\*.* download
copy src\Twilio.Api.Silverlight\bin\Release\*.* download\Silverlight\
copy src\Twilio.Api.WindowsPhone\bin\Release\*.* download\WindowsPhone\
copy src\Twilio.Mvc\bin\Release\*.* download
copy src\Twilio.Twiml\bin\Release\*.* download
copy src\Twilio.WebMatrix\bin\Release\*.* download
copy src\Twilio.Client.Capability\bin\Release\*.* download
copy LICENSE.txt download

copy src\Twilio.Api\bin\Release\Twilio.Api.* download\package\twilio\lib\3.5\
copy src\Twilio.Api.Silverlight\bin\Release\Twilio.Api.Silverlight.* download\package\twilio\lib\SL4\
REM copy src\Twilio.Api.WindowsPhone\bin\Release\Twilio.Api.WindowsPhone.* download\package\twilio\lib\SL3-WP7\
copy src\Twilio.Api.WindowsPhone\bin\Release\Twilio.Api.WindowsPhone.* download\package\twilio\lib\SL4-WINDOWSPHONE71\

copy src\Twilio.Mvc\bin\Release\Twilio.Mvc.* download\package\twiliomvc\lib\3.5\
copy src\Twilio.Twiml\bin\Release\Twilio.Twiml.* download\package\twiliotwiml\lib\3.5\
copy src\Twilio.WebMatrix\bin\Release\Twilio.WebMatrix.* download\package\twiliowebmatrix\lib\3.5\
copy src\Twilio.Client.Capability\bin\Release\Twilio.Client.Capability.* download\package\twilioclient\lib\3.5\

tools\nuget.exe pack Twilio.nuspec -BasePath download\package\twilio -o download
tools\nuget.exe pack Twilio.Mvc.nuspec -BasePath download\package\twiliomvc -o download
tools\nuget.exe pack Twilio.TwiML.nuspec -BasePath download\package\twiliotwiml -o download
tools\nuget.exe pack Twilio.WebMatrix.nuspec -BasePath download\package\twiliowebmatrix -o download
tools\nuget.exe pack Twilio.Client.nuspec -BasePath download\package\twilioclient -o download