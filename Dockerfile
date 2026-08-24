FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        make \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /twilio

COPY src ./src
COPY test ./test
COPY Twilio.sln .
COPY Makefile .
COPY global.json .
COPY Directory.Build.props .

RUN dotnet restore
