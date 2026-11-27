# Content API - Text Content Example

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
            // Create a simple text content
            var textContent = new ContentResource.TwilioText.Builder()
                .WithBody("Hello! This is a simple text message from Twilio Content API.")
                .Build();

            // Create the content types object
            var contentTypes = new ContentResource.Types.Builder()
                .WithTwilioText(textContent)
                .Build();

            // Create the content request
            var contentRequest = new ContentResource.ContentCreateRequest.Builder()
                .WithFriendlyName("Simple Text Content")
                .WithLanguage("en")
                .WithTypes(contentTypes)
                .Build();

            // Create the content
            var content = ContentResource.Create(contentRequest);

            Console.WriteLine($"Content created successfully!");
            Console.WriteLine($"Content SID: {content.Sid}");
            Console.WriteLine($"Friendly Name: {content.FriendlyName}");
            Console.WriteLine($"Language: {content.Language}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating content: {ex.Message}");
        }
    }
}
```

This example demonstrates how to create a simple text content using the Twilio Content API. The key components are:

1. **TwilioText**: Contains the message body
2. **Types**: Wrapper for different content types (in this case, text)
3. **ContentCreateRequest**: The main request object containing metadata and content types
4. **ContentResource.Create()**: Method to send the request to Twilio

The Content API uses JSON payloads and the builder pattern for easy construction of complex content structures.