/*
 * Example: OutboundCall
 * Description: Initiate a new outbound call to 415-555-1212 using an HTTP POST
 * Author: Twilio, Inc. <help@twilio.com>
 */

using System;
using System.Collections;

using TwilioRest;

class OutboundCall
{
    // Twilio REST API version
    const string API_VERSION = "2008-08-01";
    
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
        
        try
        {
            h = new Hashtable();
            h.Add("Caller", CALLER_ID);
            h.Add("Called", "415-555-1212");
            h.Add("Url", "http://demo.twilio.com/welcome");
            h.Add("Method", "POST");
            Console.WriteLine(account.request(
                                              String.Format("/{0}/Accounts/{1}/Calls", 
                                                            API_VERSION, ACCOUNT_SID), "POST", h));
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
