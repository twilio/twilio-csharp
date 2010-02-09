### C# .NET Twilio REST SDK

### Description
The Twilio REST SDK simplifies the process of makes calls to the Twilio REST.
The Twilio REST API lets to you initiate outgoing calls, list previous call,
and much more.  See http://www.twilio.com/docs for more information.


### Usage
Include the 'using TwilioRest' line at the top of your C# code and put the
TwilioRest.cs file in the same directory as your code.   As shown in
example.cs, you will need to specify the ACCOUNT_ID and
ACCOUNT_TOKEN given to you by Twilio before you can make REST requests. In
addition, you will need to choose a 'Caller' and 'Called' before making
outgoing calls. See http://www.twilio.com/docs for more information.

### FILES
 * **lib/TwilioRest.cs**: build and link this library in your code
 * **examples/**: examples of usage with TwilioRest client
 * **Makefile**: makefile to build the library and example code (requires Mono and the mcs command line tool)

### TESTING EXAMPLES
 * With mono or alternative runtime make sure to have the library in your path before running.
 * From command line: export MONO_PATH=$MONO_PATH:<path>/twilio-csharp/libs

### LINKING
 * Use -r:TwilioRest flag with msc to build.  

### License
The Twilio SDK is distributed under the MIT License
