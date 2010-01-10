MCS=/usr/bin/mcs

all: build

build: twiliorest.dll example.exe

twiliorest.dll:
	$(MCS) twiliorest.cs -target:library -r:System.Web

example.exe:
	$(MCS) example.cs -r:TwilioRest 

clean: 
	rm twiliorest.dll
	rm example.exe