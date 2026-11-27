FROM ubuntu:24.04

# Ubuntu 24.04 base with the .NET 8 SDK from the Ubuntu archive; ca-certificates kept current. net462/net35 targets build on
# Linux via NuGet reference assemblies (see src/Twilio/Twilio.csproj), so Mono is not needed.
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        ca-certificates \
        dotnet-sdk-8.0 \
        make \
    && apt-get install -y --only-upgrade ca-certificates \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /twilio

COPY src ./src
COPY test ./test
COPY Twilio.sln .
COPY Makefile .

RUN dotnet restore
