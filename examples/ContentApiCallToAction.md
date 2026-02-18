# Content API - Call To Action Content Example

```csharp
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Content.V1;

class Program
{
    static void Main(string[] args)
    {
        // Initialize Twilio client
        TwilioClient.Init("TWILIO_ACCOUNT_SID", "TWILIO_AUTH_TOKEN");

        try
        {
            // Create call to action buttons
            var actions = new List<ContentResource.CallToActionAction>();

            // URL action - link to website
            var urlAction = new ContentResource.CallToActionAction.Builder()
                .WithType(ContentResource.CallToActionActionType.Url)
                .WithTitle("Visit Website")
                .WithUrl("https://www.example.com")
                .WithId("website_action")
                .Build();

            // Phone number action - call business
            var phoneAction = new ContentResource.CallToActionAction.Builder()
                .WithType(ContentResource.CallToActionActionType.PhoneNumber)
                .WithTitle("Call Us")
                .WithPhone("+1234567890")
                .WithId("phone_action")
                .Build();

            // Copy code action - promotional code
            var codeAction = new ContentResource.CallToActionAction.Builder()
                .WithType(ContentResource.CallToActionActionType.CopyCode)
                .WithTitle("Copy Promo Code")
                .WithCode("SAVE20")
                .WithId("promo_action")
                .Build();

            actions.Add(urlAction);
            actions.Add(phoneAction);
            actions.Add(codeAction);

            // Create call to action content
            var callToActionContent = new ContentResource.TwilioCallToAction.Builder()
                .WithBody("Get 20% off your next purchase! Click below to visit our website, call for support, or copy your discount code.")
                .WithActions(actions)
                .Build();

            // Create the content types object
            var contentTypes = new ContentResource.Types.Builder()
                .WithTwilioCallToAction(callToActionContent)
                .Build();

            // Create the content request
            var contentRequest = new ContentResource.ContentCreateRequest.Builder()
                .WithFriendlyName("Promotional Call to Action")
                .WithLanguage("en")
                .WithTypes(contentTypes)
                .Build();

            // Create the content
            var content = ContentResource.Create(contentRequest);

            Console.WriteLine($"Call to action content created successfully!");
            Console.WriteLine($"Content SID: {content.Sid}");
            Console.WriteLine($"Friendly Name: {content.FriendlyName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating call to action content: {ex.Message}");
        }
    }
}
```

This example demonstrates how to create call-to-action content with multiple action types:

1. **URL Action**: Opens a website or deep link
   - `Type`: `URL`
   - `Title`: Button text
   - `Url`: Destination URL

2. **Phone Action**: Initiates a phone call
   - `Type`: `PHONE_NUMBER`
   - `Title`: Button text
   - `Phone`: Phone number to call

3. **Copy Code Action**: Copies text to clipboard
   - `Type`: `COPY_CODE`
   - `Title`: Button text
   - `Code`: Text to copy

Call-to-action content is ideal for driving user engagement with specific actions like visiting websites, making calls, or copying promotional codes. Each action type serves different purposes and can be combined in a single message.