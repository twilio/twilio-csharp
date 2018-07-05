FROM ubuntu:16.04

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
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
        zlib1g \
        curl \
        ca-certificates \
    && rm -rf /var/lib/apt/lists/*

ENV DOTNET_SDK_VERSION 2.1.4
ENV DOTNET_SDK_DOWNLOAD_URL https://dotnetcli.blob.core.windows.net/dotnet/Sdk/$DOTNET_SDK_VERSION/dotnet-sdk-$DOTNET_SDK_VERSION-linux-x64.tar.gz
ENV DOTNET_SDK_DOWNLOAD_SHA 05FE90457A8B77AD5A5EB2F22348F53E962012A55077AC4AD144B279F6CAD69740E57F165820BFD6104E88B30E93684BDE3E858F781541D4F110F28CD52CE2B7

RUN curl -SL $DOTNET_SDK_DOWNLOAD_URL --output dotnet.tar.gz \
    && echo "$DOTNET_SDK_DOWNLOAD_SHA dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -zxf dotnet.tar.gz -C /usr/share/dotnet \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
    && rm dotnet.tar.gz

RUN mkdir /twilio
WORKDIR /twilio

COPY src ./src
COPY test ./test
COPY Twilio.sln .

RUN dotnet restore
