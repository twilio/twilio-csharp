/*
 * Example: SendSMS
 * Description: Sends an sms message, HTTP POST
 * Author: Twilio, Inc. <help@twilio.com>
 */

using System;
using System.Collections;

using TwilioRest;

class SendSMS
{
    // Twilio REST API version
    const string API_VERSION = "2010-04-01";
    
    // Twilio AccountSid and AuthToken
    const string ACCOUNT_SID = "ACXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
    const string ACCOUNT_TOKEN = "YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY";
    
    // Outgoing Caller ID previously validated with Twilio
    const string CALLER_ID = "NNNNNNNNNN";
    
    static void Main(string[] args)
    {
        TwilioRest.Account account;
        Hashtable h;
        
        // Create Twilio REST account object using Twilio account ID and token
        account = new TwilioRest.Account(ACCOUNT_SID, ACCOUNT_TOKEN);
        
        h = new Hashtable();
        h.Add("From", CALLER_ID);
        h.Add("To", "NNNNNNNNN");
        h.Add("Body", "The answer is 42");
        try
        {
            Console.WriteLine(account.request(String.Format(
                                                            "/{0}/Accounts/{1}/SMS/Messages",
                                                            API_VERSION, ACCOUNT_SID), "POST", h));
        }
        catch(TwilioRestException e)
        {
            Console.WriteLine("An error occurred: {0}", e.Message);
        }
        
    }
}
