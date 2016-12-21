Push-Location $PSScriptRoot

Remove-Item -Recurse -Force .\_site\*
Remove-Item -Recurse -Force .\obj\api\*

If (Test-Path ..\Twilio\obj\xdoc) {
    Remove-Item -Recurse -Force ..\Twilio\obj\xdoc
}

Copy-Item ..\README.md .\index.md
..\tools\docfx\docfx.exe .\docfx.json

Pop-Location