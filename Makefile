MCS=/usr/bin/mcs

LIBS=TwilioRest.dll
EXAMPLES=CompletedCalls.exe \
	DeleteRecording.exe \
	ListRecordings.exe \
	ListSMS.exe \
	Notifications.exe \
	OutboundCall.exe \
	SendSMS.exe

all: build

build: $(LIBS) $(EXAMPLES)

%.dll:
	$(MCS) libs/$*.cs -target:library -r:System.Web

%.exe: 
	$(MCS) examples/$*.cs -r:TwilioRest -lib:libs/

clean: 
	$(rm libs/*.dll)
	$(rm examples/*.exe)
