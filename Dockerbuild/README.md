# Building Twilio project through Docker

## Build your image

In the root of the repository:

Powershell/cmd:
```pwsh
docker build -t twiliobuild .\Dockerbuild\
```
bash:
```bash
docker build -t twiliobuild ./Dockerbuild/
```

## Restore/Compile/Test

In the repository root:

### Start the container:

powershell:
```pwsh
docker run -it --rm -v ${PWD}:/twilio twiliobuild
```
bash:
```bash
docker run -it --rm -v $(pwd):/twilio twiliobuild
```

### Test
In the shell:

1) `dotnet restore`
2) `dotnet build -c Release --no-restore`
3) `dotnet test -c Release --no-build`

Or just in one command `make test` 
