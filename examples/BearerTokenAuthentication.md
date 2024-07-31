using System;
using Twilio;
using Twilio.Base;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.PreviewIam.Organizations;

//Find client id, client secret and organisation sid from admin center of your organisation
//path account sid is the sid of the account withing the organisation
class Program
{
    static void Main(string[] args)
    {
        TwilioOrgsTokenAuthClient.Init(GRANT_TYPE, CLIENT_ID, CLIENT_SECRET);
        Twilio.Base.BearerToken.BearerTokenResourceSet<Twilio.Rest.PreviewIam.Organizations.AccountResource> accountList = null;
        accountList = Twilio.Rest.PreviewIam.Organizations.AccountResource.Read(pathOrganizationSid: ORGS_SID);
        Console.WriteLine(accountList.ElementAt(0).FriendlyName);
        var account = Twilio.Rest.PreviewIam.Organizations.AccountResource.Fetch(pathOrganizationSid: ORGS_SID, pathAccountSid: PATH_ACCOUNT_SID);
        Console.WriteLine(account.FriendlyName);
    }
}
