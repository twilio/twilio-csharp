FROM ubuntu:20.04 as build

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        libssl1.1 \
        ca-certificates \
        wget \
        dirmngr \
        gnupg \
        apt-transport-https \
        software-properties-common \
        make \
    && rm -rf /var/lib/apt/lists/*

RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
RUN apt-add-repository 'deb https://download.mono-project.com/repo/ubuntu stable-focal main'
RUN apt -y install mono-complete

RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb && \
	dpkg -i packages-microsoft-prod.deb 

RUN apt-get update; apt-get update && apt-get install -y dotnet-sdk-3.1 && apt-get install -y dotnet-sdk-6.0

WORKDIR /twilio
