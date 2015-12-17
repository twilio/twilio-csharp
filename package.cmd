tools\nuget.exe update -self

rd download /s /q

if not exist download mkdir download
if not exist download\WindowsPhone mkdir download\WindowsPhone
if not exist download\Silverlight mkdir download\Silverlight
if not exist download\package mkdir download\package
if not exist download\package\twilio mkdir download\package\twilio
if not exist download\package\twilioauth mkdir download\package\twilioauth
if not exist download\package\twiliomvc mkdir download\package\twiliomvc
if not exist download\package\twiliotwiml mkdir download\package\twiliotwiml
if not exist download\package\twiliowebmatrix mkdir download\package\twiliowebmatrix
if not exist download\package\twilioclient mkdir download\package\twilioclient
if not exist download\package\twiliotaskrouter mkdir download\package\twiliotaskrouter
if not exist download\package\twiliolookups mkdir download\package\twiliolookups
if not exist download\package\twiliopricing mkdir download\package\twiliopricing
if not exist download\package\twiliomonitor mkdir download\package\twiliomonitor
if not exist download\package\twiliotrunking mkdir download\package\twiliotrunking

if not exist download\package\twilio\lib mkdir download\package\twilio\lib
if not exist download\package\twilio\lib\3.5 mkdir download\package\twilio\lib\3.5
if not exist download\package\twilio\lib\WINDOWSPHONE8 mkdir download\package\twilio\lib\WINDOWSPHONE8
if not exist download\package\twilio\lib\SL5 mkdir download\package\twilio\lib\SL5

if not exist download\package\twilioauth\lib mkdir download\package\twilioauth\lib
if not exist download\package\twilioauth\lib\3.5 mkdir download\package\twilioauth\lib\3.5

if not exist download\package\twiliomvc\lib mkdir download\package\twiliomvc\lib
if not exist download\package\twiliomvc\lib\3.5 mkdir download\package\twiliomvc\lib\3.5

if not exist download\package\twiliotwiml\lib mkdir download\package\twiliotwiml\lib
if not exist download\package\twiliotwiml\lib\3.5 mkdir download\package\twiliotwiml\lib\3.5

if not exist download\package\twiliowebmatrix\lib mkdir download\package\twiliowebmatrix\lib
if not exist download\package\twiliowebmatrix\lib\3.5 mkdir download\package\twiliowebmatrix\lib\3.5

if not exist download\package\twilioclient\lib mkdir download\package\twilioclient\lib
if not exist download\package\twilioclient\lib\3.5 mkdir download\package\twilioclient\lib\3.5

if not exist download\package\twiliotaskrouter\lib mkdir download\package\twiliotaskrouter\lib
if not exist download\package\twiliotaskrouter\lib\3.5 mkdir download\package\twiliotaskrouter\lib\3.5

if not exist download\package\twiliolookups\lib mkdir download\package\twiliolookups\lib
if not exist download\package\twiliolookups\lib\3.5 mkdir download\package\twiliolookups\lib\3.5

if not exist download\package\twiliopricing\lib mkdir download\package\twiliopricing\lib
if not exist download\package\twiliopricing\lib\3.5 mkdir download\package\twiliopricing\lib\3.5

if not exist download\package\twiliomonitor\lib mkdir download\package\twiliomonitor\lib
if not exist download\package\twiliomonitor\lib\3.5 mkdir download\package\twiliomonitor\lib\3.5

if not exist download\package\twiliotrunking\lib mkdir download\package\twiliotrunking\lib
if not exist download\package\twiliotrunking\lib\3.5 mkdir download\package\twiliotrunking\lib\3.5

if not exist download\package\twilioipmessaging\lib mkdir download\package\twilioipmessaging\lib
if not exist download\package\twilioipmessaging\lib\3.5 mkdir download\package\twilioipmessaging\lib\3.5

REM tools\ilmerge.exe /lib:src\Twilio.Api\bin\Release /internalize /ndebug /v2 /out:download\Twilio.Api.dll Twilio.Api.dll RestSharp.dll
REM tools\ilmerge.exe /lib:src\Twilio.Api.Silverlight\bin\Release /internalize /ndebug /targetplatform:v4,"C:\Program Files (x86)\Microsoft Silverlight\4.1.10111.0" /out:download\Twilio.Api.Silverlight.dll RestSharp.Silverlight.dll

copy src\Twilio.Api\bin\Release\*.* download
copy src\Twilio.Api.Silverlight\bin\Release\*.* download\Silverlight\
copy src\Twilio.Api.WindowsPhone\bin\Release\*.* download\WindowsPhone\
copy src\Twilio.Auth\bin\Release\*.* download
copy src\Twilio.Mvc\bin\Release\*.* download
copy src\Twilio.Twiml\bin\Release\*.* download
copy src\Twilio.WebMatrix\bin\Release\*.* download
copy src\Twilio.Client.Capability\bin\Release\*.* download
copy src\Twilio.TaskRouter\bin\Release\*.* download
copy src\Twilio.Lookups\bin\Release\*.* download
copy src\Twilio.Pricing\bin\Release\*.* download
copy src\Twilio.Monitor\bin\Release\*.* download
copy src\Twilio.Trunking\bin\Release\*.* download
copy LICENSE.txt download

copy src\Twilio.Api\bin\Release\Twilio.Api.* download\package\twilio\lib\3.5\
copy src\Twilio.Api.Silverlight\bin\Release\Twilio.Api.Silverlight.* download\package\twilio\lib\SL5\
copy src\Twilio.Api.WindowsPhone\bin\Release\Twilio.Api.WindowsPhone.* download\package\twilio\lib\\WINDOWSPHONE8\
copy src\Twilio.Auth\bin\Release\Twilio.Auth.* download\package\twilioauth\lib\3.5\
copy src\Twilio.Mvc\bin\Release\Twilio.Mvc.* download\package\twiliomvc\lib\3.5\
copy src\Twilio.Twiml\bin\Release\Twilio.Twiml.* download\package\twiliotwiml\lib\3.5\
copy src\Twilio.WebMatrix\bin\Release\Twilio.WebMatrix.* download\package\twiliowebmatrix\lib\3.5\
copy src\Twilio.Client.Capability\bin\Release\Twilio.Client.Capability.* download\package\twilioclient\lib\3.5\
copy src\Twilio.TaskRouter\bin\Release\Twilio.TaskRouter.* download\package\twiliotaskrouter\lib\3.5\
copy src\Twilio.Lookups\bin\Release\Twilio.Lookups.* download\package\twiliolookups\lib\3.5\
copy src\Twilio.Pricing\bin\Release\Twilio.Pricing.* download\package\twiliopricing\lib\3.5\
copy src\Twilio.Monitor\bin\Release\Twilio.Monitor.* download\package\twiliomonitor\lib\3.5\
copy src\Twilio.Trunking\bin\Release\Twilio.Trunking.* download\package\twiliotrunking\lib\3.5\
copy src\Twilio.IpMessaging\bin\Release\Twilio.IpMessaging.* download\package\twilioipmessaging\lib\3.5\

tools\nuget.exe pack Twilio.nuspec -BasePath download\package\twilio -o download
tools\nuget.exe pack Twilio.Auth.nuspec -BasePath download\package\twilioauth -o download
tools\nuget.exe pack Twilio.Mvc.nuspec -BasePath download\package\twiliomvc -o download
tools\nuget.exe pack Twilio.TwiML.nuspec -BasePath download\package\twiliotwiml -o download
tools\nuget.exe pack Twilio.WebMatrix.nuspec -BasePath download\package\twiliowebmatrix -o download
tools\nuget.exe pack Twilio.Client.nuspec -BasePath download\package\twilioclient -o download
tools\nuget.exe pack Twilio.TaskRouter.nuspec -BasePath download\package\twiliotaskrouter -o download
tools\nuget.exe pack Twilio.Lookups.nuspec -BasePath download\package\twiliolookups -o download
tools\nuget.exe pack Twilio.Pricing.nuspec -BasePath download\package\twiliopricing -o download
tools\nuget.exe pack Twilio.Monitor.nuspec -BasePath download\package\twiliomonitor -o download
tools\nuget.exe pack Twilio.Trunking.nuspec -BasePath download\package\twiliotrunking -o download
tools\nuget.exe pack Twilio.IpMessaging.nuspec -BasePath download\package\twilioipmessaging -o download