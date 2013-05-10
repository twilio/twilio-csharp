REM tools\nuget.exe update -self

C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe /nologo /maxcpucount /nr:true /verbosity:minimal /p:BuildInParallel=true /p:Configuration=Release /p:RestorePackages=true /t:Rebuild src/Twilio.2012.sln

rd download /s /q

if not exist download mkdir download
if not exist download\package mkdir download\package
if not exist download\package\twilio.winrt mkdir download\package\twilio.winrt

if not exist download\package\twilio.winrt\lib mkdir download\package\twilio.winrt\lib
if not exist download\package\twilio.winrt\lib\windows8 mkdir download\package\twilio.winrt\lib\windows8

copy LICENSE.txt download

copy src\Twilio.WinRT\bin\Release\Twilio.winmd download\package\twilio.winrt\lib\windows8\
copy src\Twilio.WinRT\bin\Release\Twilio.pri download\package\twilio.winrt\lib\windows8\


tools\nuget.exe pack Twilio.WinRT.nuspec -BasePath download\package\twilio.winrt -o download
