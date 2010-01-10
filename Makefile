MCS=/usr/bin/mcs

all:
	$(MCS) twiliorest.cs -target:library -r:System.Web
	$(MCS) example.cs -r:TwilioRest
