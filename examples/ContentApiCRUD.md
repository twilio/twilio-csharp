# Content API - Complete CRUD Operations Example

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
            // CREATE: Create new content
            Console.WriteLine("=== Creating Content ===");
            var content = CreateTextContent();
            Console.WriteLine($"Created Content SID: {content.Sid}");
            Console.WriteLine($"Friendly Name: {content.FriendlyName}");
            Console.WriteLine();

            // READ: Fetch the created content
            Console.WriteLine("=== Fetching Content ===");
            var fetchedContent = ContentResource.Fetch(content.Sid);
            Console.WriteLine($"Fetched Content SID: {fetchedContent.Sid}");
            Console.WriteLine($"Status: {fetchedContent.Status}");
            Console.WriteLine($"Language: {fetchedContent.Language}");
            Console.WriteLine();

            // READ: List all content
            Console.WriteLine("=== Listing All Content ===");
            var contentList = ContentResource.Read(limit: 10);
            Console.WriteLine($"Found {contentList.ToList().Count} content items:");
            foreach (var item in contentList)
            {
                Console.WriteLine($"- {item.FriendlyName} (SID: {item.Sid})");
            }
            Console.WriteLine();

            // DELETE: Delete the content
            Console.WriteLine("=== Deleting Content ===");
            var deleteResult = ContentResource.Delete(content.Sid);
            Console.WriteLine($"Content deleted: {deleteResult}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static ContentResource CreateTextContent()
    {
        // Create simple text content
        var textContent = new ContentResource.TwilioText.Builder()
            .WithBody("Welcome to our service! Thank you for signing up.")
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioText(textContent)
            .Build();

        var contentRequest = new ContentResource.ContentCreateRequest.Builder()
            .WithFriendlyName("Welcome Message")
            .WithLanguage("en")
            .WithTypes(contentTypes)
            .Build();

        return ContentResource.Create(contentRequest);
    }

    // Example of creating content with multiple types
    static ContentResource CreateRichContent()
    {
        // Create quick reply content
        var actions = new List<ContentResource.QuickReplyAction>();
        
        var yesAction = new ContentResource.QuickReplyAction.Builder()
            .WithType(ContentResource.QuickReplyActionType.QuickReply)
            .WithTitle("Yes")
            .WithId("yes")
            .Build();
            
        var noAction = new ContentResource.QuickReplyAction.Builder()
            .WithType(ContentResource.QuickReplyActionType.QuickReply)
            .WithTitle("No")
            .WithId("no")
            .Build();

        actions.Add(yesAction);
        actions.Add(noAction);

        var quickReplyContent = new ContentResource.TwilioQuickReply.Builder()
            .WithBody("Are you satisfied with our service?")
            .WithActions(actions)
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioQuickReply(quickReplyContent)
            .Build();

        var variables = new Dictionary<string, string>
        {
            {"customer_name", "{{1}}"},
            {"service_type", "{{2}}"}
        };

        var contentRequest = new ContentResource.ContentCreateRequest.Builder()
            .WithFriendlyName("Service Satisfaction Survey")
            .WithLanguage("en")
            .WithVariables(variables)
            .WithTypes(contentTypes)
            .Build();

        return ContentResource.Create(contentRequest);
    }
}
```

## Async Operations Example

```csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Content.V1;

class AsyncContentExample
{
    static async Task Main(string[] args)
    {
        // Initialize Twilio client
        TwilioClient.Init("TWILIO_ACCOUNT_SID", "TWILIO_AUTH_TOKEN");

        try
        {
            // CREATE: Create content asynchronously
            Console.WriteLine("Creating content asynchronously...");
            var content = await CreateContentAsync();
            Console.WriteLine($"Created Content SID: {content.Sid}");

            // READ: Fetch content asynchronously
            Console.WriteLine("Fetching content asynchronously...");
            var fetchedContent = await ContentResource.FetchAsync(content.Sid);
            Console.WriteLine($"Fetched Content: {fetchedContent.FriendlyName}");

            // READ: List content asynchronously
            Console.WriteLine("Listing content asynchronously...");
            var contentList = await ContentResource.ReadAsync(limit: 5);
            Console.WriteLine($"Found {contentList.ToList().Count} content items");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task<ContentResource> CreateContentAsync()
    {
        var mediaUrls = new List<string> { "https://example.com/image.jpg" };
        
        var mediaContent = new ContentResource.TwilioMedia.Builder()
            .WithBody("Check out our latest product!")
            .WithMedia(mediaUrls)
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioMedia(mediaContent)
            .Build();

        var contentRequest = new ContentResource.ContentCreateRequest.Builder()
            .WithFriendlyName("Product Announcement")
            .WithLanguage("en")
            .WithTypes(contentTypes)
            .Build();

        return await ContentResource.CreateAsync(contentRequest);
    }
}
```

This comprehensive example demonstrates:

1. **CREATE**: Creating new content with `ContentResource.Create()`
2. **READ**: 
   - Fetching specific content with `ContentResource.Fetch()`
   - Listing all content with `ContentResource.Read()`
3. **DELETE**: Removing content with `ContentResource.Delete()`
4. **Async Operations**: Using async/await for non-blocking operations

Key points:
- Content API uses JSON payloads for rich content types
- Builder pattern simplifies complex object construction
- All operations support both synchronous and asynchronous execution
- Variables enable content personalization using Twilio's template syntax
- Proper error handling is essential for production applications