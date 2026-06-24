# Content API - Overview and Best Practices

The Twilio Content API allows you to create rich, interactive content templates that can be reused across different messaging channels. This overview demonstrates key concepts and best practices.

## Key Concepts

1. **JSON-based API**: Unlike traditional form-encoded APIs, Content API uses JSON payloads
2. **Builder Pattern**: All content types use builders for easy construction
3. **Template Variables**: Support for personalization using `{{variable}}` syntax
4. **Multiple Content Types**: Support for text, media, location, lists, cards, and more
5. **Channel Agnostic**: Content works across WhatsApp, SMS, and other channels

## Content Types Summary

| Content Type | Use Case | Key Features |
|-------------|----------|--------------|
| `TwilioText` | Simple messages | Text body only |
| `TwilioMedia` | Rich media | Text + images/videos |
| `TwilioLocation` | Location sharing | Coordinates + address |
| `TwilioQuickReply` | Interactive choices | Text + quick reply buttons |
| `TwilioListPicker` | Option selection | Text + detailed list items |
| `TwilioCallToAction` | Action buttons | Text + action buttons (URL, phone, etc.) |
| `TwilioCard` | Product showcase | Rich cards with media and actions |

## Complete Example - Multi-Type Content Creation

```csharp
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Content.V1;

class ContentApiDemo
{
    static void Main(string[] args)
    {
        TwilioClient.Init("TWILIO_ACCOUNT_SID", "TWILIO_AUTH_TOKEN");

        // Create different types of content
        CreateTextContent();
        CreateMediaContent();
        CreateInteractiveContent();
        CreateLocationContent();
        CreateRichCardContent();
        
        Console.WriteLine("All content examples created successfully!");
    }

    static void CreateTextContent()
    {
        Console.WriteLine("Creating simple text content...");
        
        var textContent = new ContentResource.TwilioText.Builder()
            .WithBody("Hello {{customer_name}}, welcome to our service!")
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioText(textContent)
            .Build();

        var variables = new Dictionary<string, string> 
        { 
            {"customer_name", "{{1}}"} 
        };

        var content = CreateContent("Welcome Text Template", contentTypes, variables);
        Console.WriteLine($"✓ Text content created: {content.Sid}");
    }

    static void CreateMediaContent()
    {
        Console.WriteLine("Creating media content...");
        
        var mediaUrls = new List<string> 
        { 
            "https://example.com/product.jpg" 
        };

        var mediaContent = new ContentResource.TwilioMedia.Builder()
            .WithBody("Check out our new {{product_name}}!")
            .WithMedia(mediaUrls)
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioMedia(mediaContent)
            .Build();

        var variables = new Dictionary<string, string> 
        { 
            {"product_name", "{{1}}"} 
        };

        var content = CreateContent("Product Media Template", contentTypes, variables);
        Console.WriteLine($"✓ Media content created: {content.Sid}");
    }

    static void CreateInteractiveContent()
    {
        Console.WriteLine("Creating interactive content...");
        
        var actions = new List<ContentResource.QuickReplyAction>
        {
            new ContentResource.QuickReplyAction.Builder()
                .WithType(ContentResource.QuickReplyActionType.QuickReply)
                .WithTitle("Excellent")
                .WithId("rating_5")
                .Build(),
            new ContentResource.QuickReplyAction.Builder()
                .WithType(ContentResource.QuickReplyActionType.QuickReply)
                .WithTitle("Good")
                .WithId("rating_4")
                .Build(),
            new ContentResource.QuickReplyAction.Builder()
                .WithType(ContentResource.QuickReplyActionType.QuickReply)
                .WithTitle("Poor")
                .WithId("rating_2")
                .Build()
        };

        var quickReplyContent = new ContentResource.TwilioQuickReply.Builder()
            .WithBody("How would you rate your experience with {{service_name}}?")
            .WithActions(actions)
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioQuickReply(quickReplyContent)
            .Build();

        var variables = new Dictionary<string, string> 
        { 
            {"service_name", "{{1}}"} 
        };

        var content = CreateContent("Feedback Survey Template", contentTypes, variables);
        Console.WriteLine($"✓ Interactive content created: {content.Sid}");
    }

    static void CreateLocationContent()
    {
        Console.WriteLine("Creating location content...");
        
        var locationContent = new ContentResource.TwilioLocation.Builder()
            .WithLatitude(37.7749m)
            .WithLongitude(-122.4194m)
            .WithLabel("{{location_name}}")
            .WithAddress("{{location_address}}")
            .WithId("business_location")
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioLocation(locationContent)
            .Build();

        var variables = new Dictionary<string, string> 
        { 
            {"location_name", "{{1}}"}, 
            {"location_address", "{{2}}"} 
        };

        var content = CreateContent("Business Location Template", contentTypes, variables);
        Console.WriteLine($"✓ Location content created: {content.Sid}");
    }

    static void CreateRichCardContent()
    {
        Console.WriteLine("Creating rich card content...");
        
        var actions = new List<ContentResource.CardAction>
        {
            new ContentResource.CardAction.Builder()
                .WithType(ContentResource.CardActionType.Url)
                .WithTitle("Shop Now")
                .WithUrl("{{product_url}}")
                .WithId("shop_action")
                .Build(),
            new ContentResource.CardAction.Builder()
                .WithType(ContentResource.CardActionType.QuickReply)
                .WithTitle("More Info")
                .WithId("info_action")
                .Build()
        };

        var mediaUrls = new List<string> { "{{product_image_url}}" };

        var cardContent = new ContentResource.TwilioCard.Builder()
            .WithTitle("{{product_name}}")
            .WithSubtitle("{{product_description}} - ${{product_price}}")
            .WithMedia(mediaUrls)
            .WithActions(actions)
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioCard(cardContent)
            .Build();

        var variables = new Dictionary<string, string> 
        { 
            {"product_name", "{{1}}"}, 
            {"product_description", "{{2}}"}, 
            {"product_price", "{{3}}"}, 
            {"product_url", "{{4}}"}, 
            {"product_image_url", "{{5}}"} 
        };

        var content = CreateContent("Product Card Template", contentTypes, variables);
        Console.WriteLine($"✓ Rich card content created: {content.Sid}");
    }

    static ContentResource CreateContent(string friendlyName, ContentResource.Types types, Dictionary<string, string> variables = null)
    {
        var requestBuilder = new ContentResource.ContentCreateRequest.Builder()
            .WithFriendlyName(friendlyName)
            .WithLanguage("en")
            .WithTypes(types);

        if (variables != null)
        {
            requestBuilder.WithVariables(variables);
        }

        var contentRequest = requestBuilder.Build();
        return ContentResource.Create(contentRequest);
    }
}
```

## Best Practices

### 1. Use Template Variables for Personalization
```csharp
// Good: Use variables for dynamic content
var variables = new Dictionary<string, string> 
{ 
    {"customer_name", "{{1}}"}, 
    {"order_id", "{{2}}"} 
};
```

### 2. Handle Errors Gracefully
```csharp
try 
{
    var content = ContentResource.Create(contentRequest);
    Console.WriteLine($"Success: {content.Sid}");
}
catch (ApiException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
    Console.WriteLine($"Error Code: {ex.Code}");
}
```

### 3. Use Async Operations for Better Performance
```csharp
var content = await ContentResource.CreateAsync(contentRequest);
```

### 4. Organize Content with Meaningful Names
```csharp
// Good: Descriptive naming
.WithFriendlyName("Welcome Message - New Customer Onboarding")

// Poor: Generic naming  
.WithFriendlyName("Content 1")
```

### 5. Validate Template Variables
Always ensure your template variables match what you'll send when using the content:
- `{{1}}` maps to the first variable in your message
- `{{2}}` maps to the second variable, etc.

## Error Handling

Common errors and solutions:

- **400 Bad Request**: Check JSON structure and required fields
- **401 Unauthorized**: Verify Account SID and Auth Token
- **422 Unprocessable Entity**: Validate content type requirements
- **429 Rate Limited**: Implement retry logic with backoff

## Next Steps

1. Create content templates for your use cases
2. Test with different variable combinations
3. Integrate with your messaging workflows
4. Monitor usage and performance
5. Optimize based on user engagement