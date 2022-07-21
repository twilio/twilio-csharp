FROM ubuntu:16.04

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        apt-transport-https \
        curl \
        ca-certificates \
        dirmngr \
        gnupg \
        libc6 \
        libcurl3 \
        libgcc1 \
        libgssapi-krb5-2 \
        libicu55 \
        liblttng-ust0 \
        libssl1.0.2 \
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
        mono-complete \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /twilio

COPY src ./src
COPY test ./test
COPY Twilio.sln .
COPY Makefile .

RUN dotnet restore
