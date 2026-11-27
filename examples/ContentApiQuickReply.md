# Content API - Quick Reply Content Example

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
            // Create quick reply actions
            var actions = new List<ContentResource.QuickReplyAction>();

            var yesAction = new ContentResource.QuickReplyAction.Builder()
                .WithType(ContentResource.QuickReplyActionType.QuickReply)
                .WithTitle("Yes")
                .WithId("yes_option")
                .Build();

            var noAction = new ContentResource.QuickReplyAction.Builder()
                .WithType(ContentResource.QuickReplyActionType.QuickReply)
                .WithTitle("No")
                .WithId("no_option")
                .Build();

            var moreInfoAction = new ContentResource.QuickReplyAction.Builder()
                .WithType(ContentResource.QuickReplyActionType.QuickReply)
                .WithTitle("More Info")
                .WithId("more_info")
                .Build();

            actions.Add(yesAction);
            actions.Add(noAction);
            actions.Add(moreInfoAction);

            // Create quick reply content
            var quickReplyContent = new ContentResource.TwilioQuickReply.Builder()
                .WithBody("Would you like to receive updates about our new products?")
                .WithActions(actions)
                .Build();

            // Create the content types object
            var contentTypes = new ContentResource.Types.Builder()
                .WithTwilioQuickReply(quickReplyContent)
                .Build();

            // Create the content request
            var contentRequest = new ContentResource.ContentCreateRequest.Builder()
                .WithFriendlyName("Product Update Quick Reply")
                .WithLanguage("en")
                .WithTypes(contentTypes)
                .Build();

            // Create the content
            var content = ContentResource.Create(contentRequest);

            Console.WriteLine($"Quick reply content created successfully!");
            Console.WriteLine($"Content SID: {content.Sid}");
            Console.WriteLine($"Friendly Name: {content.FriendlyName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating quick reply content: {ex.Message}");
        }
    }
}
```

This example demonstrates how to create interactive quick reply content with:

1. **Message body**: The main question or prompt
2. **Quick reply actions**: Predefined response options for users
3. **Action properties**:
   - `Type`: Always `QUICK_REPLY` for quick reply buttons
   - `Title`: The text displayed on the button
   - `Id`: Unique identifier for tracking which option was selected

Quick replies are ideal for surveys, feedback collection, and simple decision trees where you want to provide users with predefined response options.