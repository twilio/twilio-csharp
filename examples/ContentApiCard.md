# Content API - Card Content Example

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
            // Create media URLs for the card
            var mediaUrls = new List<string>
            {
                "https://example.com/product-image.jpg"
            };

            // Create card actions
            var actions = new List<ContentResource.CardAction>();

            var buyAction = new ContentResource.CardAction.Builder()
                .WithType(ContentResource.CardActionType.Url)
                .WithTitle("Buy Now")
                .WithUrl("https://example.com/buy/product123")
                .WithId("buy_action")
                .Build();

            var callAction = new ContentResource.CardAction.Builder()
                .WithType(ContentResource.CardActionType.PhoneNumber)
                .WithTitle("Call for Info")
                .WithPhone("+1234567890")
                .WithId("call_action")
                .Build();

            var replyAction = new ContentResource.CardAction.Builder()
                .WithType(ContentResource.CardActionType.QuickReply)
                .WithTitle("More Details")
                .WithId("details_action")
                .Build();

            actions.Add(buyAction);
            actions.Add(callAction);
            actions.Add(replyAction);

            // Create card content
            var cardContent = new ContentResource.TwilioCard.Builder()
                .WithTitle("Premium Wireless Headphones")
                .WithSubtitle("High-quality sound with noise cancellation. $299.99")
                .WithMedia(mediaUrls)
                .WithActions(actions)
                .Build();

            // Create the content types object
            var contentTypes = new ContentResource.Types.Builder()
                .WithTwilioCard(cardContent)
                .Build();

            // Create the content request
            var contentRequest = new ContentResource.ContentCreateRequest.Builder()
                .WithFriendlyName("Product Card - Wireless Headphones")
                .WithLanguage("en")
                .WithTypes(contentTypes)
                .Build();

            // Create the content
            var content = ContentResource.Create(contentRequest);

            Console.WriteLine($"Card content created successfully!");
            Console.WriteLine($"Content SID: {content.Sid}");
            Console.WriteLine($"Friendly Name: {content.FriendlyName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating card content: {ex.Message}");
        }
    }
}
```

This example demonstrates how to create card content that includes:

1. **Title**: Main heading for the card
2. **Subtitle**: Additional information (price, description, etc.)
3. **Media**: List of image URLs to display
4. **Actions**: Interactive buttons with different action types:
   - `URL`: Links to external websites or deep links
   - `PHONE_NUMBER`: Initiates phone calls
   - `QUICK_REPLY`: Triggers quick reply responses
   - `COPY_CODE`: Copies text to clipboard

Cards are perfect for showcasing products, services, or rich content with a combination of images, text, and interactive buttons. They provide a visually appealing way to present information with clear calls to action.