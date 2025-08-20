# Content API - Media Content Example

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
            // Create media content with text and image
            var mediaUrls = new List<string>
            {
                "https://example.com/image1.jpg",
                "https://example.com/image2.png"
            };

            var mediaContent = new ContentResource.TwilioMedia.Builder()
                .WithBody("Check out these amazing images!")
                .WithMedia(mediaUrls)
                .Build();

            // Create the content types object
            var contentTypes = new ContentResource.Types.Builder()
                .WithTwilioMedia(mediaContent)
                .Build();

            // Create the content request with variables for personalization
            var variables = new Dictionary<string, string>
            {
                {"customer_name", "{{1}}"},
                {"product_name", "{{2}}"}
            };

            var contentRequest = new ContentResource.ContentCreateRequest.Builder()
                .WithFriendlyName("Media Content with Images")
                .WithLanguage("en")
                .WithVariables(variables)
                .WithTypes(contentTypes)
                .Build();

            // Create the content
            var content = ContentResource.Create(contentRequest);

            Console.WriteLine($"Media content created successfully!");
            Console.WriteLine($"Content SID: {content.Sid}");
            Console.WriteLine($"Friendly Name: {content.FriendlyName}");
            Console.WriteLine($"Language: {content.Language}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating media content: {ex.Message}");
        }
    }
}
```

This example shows how to create media content that includes:

1. **Text body**: A descriptive message accompanying the media
2. **Media URLs**: List of image or video URLs to include
3. **Variables**: Template variables for personalization (using Twilio's variable syntax)

Media content is perfect for sharing images, videos, or documents alongside explanatory text. The media URLs should point to publicly accessible resources.