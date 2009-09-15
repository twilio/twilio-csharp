using System;
using System.Collections;

using TwilioRest;

class MainClass
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
        
        // 1. Initiate a new outbound call to 415-555-1212 using an HTTP POST
        h = new Hashtable();
        h.Add("Caller", CALLER_ID);
        h.Add("Called", "415-555-1212");
        h.Add("Url", "http://demo.twilio.com/welcome");
        h.Add("Method", "POST");
        Console.WriteLine(account.request(
            String.Format("/{0}/Accounts/{1}/Calls", 
            API_VERSION, ACCOUNT_SID), "POST", h));
        
        // 2. Get a list of recent completed calls (i.e. Status = 2) HTTP GET
        h = new Hashtable();
        h.Add("Status", 2);
        Console.WriteLine(account.request(
            String.Format("/{0}/Accounts/{1}/Calls", 
            API_VERSION, ACCOUNT_SID), "GET", h));
        
        // 3. Get a list of recent notification log entries, HTTP GET
        Console.WriteLine(account.request(
            String.Format("/{0}/Accounts/{1}/Notifications", 
            API_VERSION, ACCOUNT_SID), "GET"));
        
        // 4. Get a list of audio recordings for a certain call, HTTP GET
        h = new Hashtable();
        h.Add("CallSid", "CAb30903a698e2fcd5ea2ea776078686f4");
        Console.WriteLine(account.request(
            String.Format("/{0}/Accounts/{1}/Recordings", 
            API_VERSION, ACCOUNT_SID), "GET", h));
        
        // 5. Delete a specific recording, HTTP DELETE
        Console.WriteLine(account.request(String.Format(
            "/{0}/Accounts/{1}/Recordings/RE67147f4464d55f390577137b97fc3667", 
            API_VERSION, ACCOUNT_SID), "DELETE"));
    }
}
