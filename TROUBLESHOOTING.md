For non-library Twilio issues, please check the [Twilio Support Help Center](https://support.twilio.com) first, and [file a support ticket](https://twilio.com/help/contact) if you don't find an answer to your question.

If you can't find a solution below, please open an [issue](https://github.com/twilio/twilio-csharp/issues).

## Table of Contents

* [Json.NET / Newtonsoft.Json Version Issues](#newtonsoft)

<a name="newtonsoft"></a>
## Json.NET / Newtonsoft.Json Version Issues

If you require a different version of Json.NET than what this helper library specifies, you can [enable binding redirection (automatic or manual)](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/how-to-enable-and-disable-automatic-binding-redirection#enabling-automatic-binding-redirects-manually) or utilize this [quick fix](https://github.com/twilio/twilio-csharp/issues/422#issuecomment-416372586) for existing projects: 

In Visual Studio, open the Package Manager Console (Tools... NuGet Package Manager... Package Manager Console) and run the following command: `Get-Project –All | Add-BindingRedirect`