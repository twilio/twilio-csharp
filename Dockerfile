FROM mcr.microsoft.com/dotnet/sdk:8.0

# Ubuntu-based image; keep ca-certificates current. net462/net35 targets build on
# Linux via NuGet reference assemblies (see src/Twilio/Twilio.csproj), so Mono is not needed.
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        ca-certificates \
        make \
    && apt-get upgrade -y ca-certificates \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /twilio

COPY src ./src
COPY test ./test
COPY Twilio.sln .
COPY Makefile .

RUN dotnet restore
