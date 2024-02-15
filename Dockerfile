FROM ubuntu:22.04

# Below dependecies are added from Dependencies menetion at
# https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu-2204
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        apt-transport-https \
        curl \
        ca-certificates \
        dirmngr \
        gnupg \
        libc6 \
        libgcc-s1 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu70 \
        liblttng-ust1 \
        libssl3 \
        libstdc++6 \
        libunwind8 \
        libuuid1 \
        make \
        software-properties-common \
        wget \
        zlib1g \
    && apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF \
    && apt-add-repository 'deb https://download.mono-project.com/repo/ubuntu stable-xenial main' \
    && wget https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb  \
    && apt-get update \
    && apt-get install -y \
        dotnet-sdk-3.1 \
        dotnet-sdk-6.0 \
        dotnet-sdk-8.0 \
        mono-complete \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /twilio

COPY src ./src
COPY test ./test
COPY Twilio.sln .
COPY Makefile .

RUN dotnet restore
