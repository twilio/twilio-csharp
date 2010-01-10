#!/bin/sh
mcs twiliorest.cs -target:library -r:System.Web
mcs example.cs -r:TwilioRest
