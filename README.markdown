### C# .NET Twilio REST SDK

### DESCRIPTION
The Twilio REST SDK simplifies the process of makes calls to the Twilio REST.
The Twilio REST API lets to you initiate outgoing calls, list previous call,
and much more.  See http://www.twilio.com/docs for more information.


### USAGE
Include the 'using TwilioRest' line at the top of your C# code and put the
TwilioRest.cs file in the same directory as your code.   As shown in
example.cs, you will need to specify the ACCOUNT_ID and
ACCOUNT_TOKEN given to you by Twilio before you can make REST requests. In
addition, you will need to choose a 'Caller' and 'Called' before making
outgoing calls. See http://www.twilio.com/docs for more information.

### FILES
 * **twiliorest.cs**: include this namespace in your code
 * **example.cs**: example usage of TwilioRest client
 * **make.bat**: imple makefile to build the example code (requires that Visual
            Studio .Net is installed and the 'csc' command is in your PATH)

### LICENSE
The Twilio SDK is distributed under the MIT License
