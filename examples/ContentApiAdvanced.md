# Content API - Advanced Content Types (Carousel & Catalog)

```csharp
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Content.V1;

class AdvancedContentExample
{
    static void Main(string[] args)
    {
        // Initialize Twilio client
        TwilioClient.Init("TWILIO_ACCOUNT_SID", "TWILIO_AUTH_TOKEN");

        try
        {
            // Create carousel content for multiple products
            CreateCarouselContent();
            
            // Create catalog content for product browsing
            CreateCatalogContent();
            
            Console.WriteLine("Advanced content examples created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void CreateCarouselContent()
    {
        Console.WriteLine("=== Creating Carousel Content ===");
        
        // Create carousel cards
        var cards = new List<ContentResource.CarouselCard>();

        // Card 1 - Premium Plan
        var premiumActions = new List<ContentResource.CarouselAction>
        {
            new ContentResource.CarouselAction.Builder()
                .WithType(ContentResource.CarouselActionType.Url)
                .WithTitle("Choose Premium")
                .WithUrl("https://example.com/premium")
                .WithId("premium_select")
                .Build(),
            new ContentResource.CarouselAction.Builder()
                .WithType(ContentResource.CarouselActionType.QuickReply)
                .WithTitle("Learn More")
                .WithId("premium_info")
                .Build()
        };

        var premiumCard = new ContentResource.CarouselCard.Builder()
            .WithTitle("Premium Plan")
            .WithBody("Full access with priority support - $99/month")
            .WithMedia("https://example.com/premium-plan.jpg")
            .WithActions(premiumActions)
            .Build();

        // Card 2 - Standard Plan
        var standardActions = new List<ContentResource.CarouselAction>
        {
            new ContentResource.CarouselAction.Builder()
                .WithType(ContentResource.CarouselActionType.Url)
                .WithTitle("Choose Standard")
                .WithUrl("https://example.com/standard")
                .WithId("standard_select")
                .Build(),
            new ContentResource.CarouselAction.Builder()
                .WithType(ContentResource.CarouselActionType.QuickReply)
                .WithTitle("Learn More")
                .WithId("standard_info")
                .Build()
        };

        var standardCard = new ContentResource.CarouselCard.Builder()
            .WithTitle("Standard Plan")
            .WithBody("Core features with email support - $49/month")
            .WithMedia("https://example.com/standard-plan.jpg")
            .WithActions(standardActions)
            .Build();

        // Card 3 - Basic Plan
        var basicActions = new List<ContentResource.CarouselAction>
        {
            new ContentResource.CarouselAction.Builder()
                .WithType(ContentResource.CarouselActionType.Url)
                .WithTitle("Choose Basic")
                .WithUrl("https://example.com/basic")
                .WithId("basic_select")
                .Build(),
            new ContentResource.CarouselAction.Builder()
                .WithType(ContentResource.CarouselActionType.QuickReply)
                .WithTitle("Learn More")
                .WithId("basic_info")
                .Build()
        };

        var basicCard = new ContentResource.CarouselCard.Builder()
            .WithTitle("Basic Plan")
            .WithBody("Essential features - $19/month")
            .WithMedia("https://example.com/basic-plan.jpg")
            .WithActions(basicActions)
            .Build();

        cards.Add(premiumCard);
        cards.Add(standardCard);
        cards.Add(basicCard);

        // Create carousel content
        var carouselContent = new ContentResource.TwilioCarousel.Builder()
            .WithBody("Choose the plan that best fits your needs:")
            .WithCards(cards)
            .Build();

        // Create content types object
        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioCarousel(carouselContent)
            .Build();

        // Create content request
        var contentRequest = new ContentResource.ContentCreateRequest.Builder()
            .WithFriendlyName("Subscription Plans Carousel")
            .WithLanguage("en")
            .WithTypes(contentTypes)
            .Build();

        // Create the content
        var content = ContentResource.Create(contentRequest);
        Console.WriteLine($"Carousel content created: {content.Sid}");
        Console.WriteLine($"Friendly Name: {content.FriendlyName}");
        Console.WriteLine();
    }

    static void CreateCatalogContent()
    {
        Console.WriteLine("=== Creating Catalog Content ===");
        
        // Create catalog items
        var catalogItems = new List<ContentResource.CatalogItem>();

        var item1 = new ContentResource.CatalogItem.Builder()
            .WithId("laptop_001")
            .WithSectionTitle("Electronics")
            .WithName("Premium Laptop")
            .WithMediaUrl("https://example.com/laptop.jpg")
            .WithPrice(1299.99m)
            .WithDescription("High-performance laptop with 16GB RAM - $1299.99 USD")
            .Build();

        var item2 = new ContentResource.CatalogItem.Builder()
            .WithId("phone_001")
            .WithSectionTitle("Electronics")
            .WithName("Smartphone Pro")
            .WithMediaUrl("https://example.com/phone.jpg")
            .WithPrice(899.99m)
            .WithDescription("Latest smartphone with advanced camera - $899.99 USD")
            .Build();

        var item3 = new ContentResource.CatalogItem.Builder()
            .WithId("headphones_001")
            .WithSectionTitle("Audio")
            .WithName("Wireless Headphones")
            .WithMediaUrl("https://example.com/headphones.jpg")
            .WithPrice(299.99m)
            .WithDescription("Premium noise-cancelling headphones - $299.99 USD (Sale: $249.99)")
            .Build();

        catalogItems.Add(item1);
        catalogItems.Add(item2);
        catalogItems.Add(item3);

        // Create catalog content
        var catalogContent = new ContentResource.TwilioCatalog.Builder()
            .WithTitle("Tech Store Catalog")
            .WithBody("Browse our latest technology products")
            .WithSubtitle("Free shipping on orders over $50")
            .WithId("tech_catalog_2024")
            .WithItems(catalogItems)
            .Build();

        // Create content types object
        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioCatalog(catalogContent)
            .Build();

        // Create content request
        var contentRequest = new ContentResource.ContentCreateRequest.Builder()
            .WithFriendlyName("Technology Product Catalog")
            .WithLanguage("en")
            .WithTypes(contentTypes)
            .Build();

        // Create the content
        var content = ContentResource.Create(contentRequest);
        Console.WriteLine($"Catalog content created: {content.Sid}");
        Console.WriteLine($"Friendly Name: {content.FriendlyName}");
        Console.WriteLine();
    }

    // Example of creating dynamic catalog content
    static void CreateDynamicCatalogContent()
    {
        Console.WriteLine("=== Creating Dynamic Catalog Content ===");
        
        // Dynamic catalog uses external data source
        var catalogContent = new ContentResource.TwilioCatalog.Builder()
            .WithTitle("{{catalog_title}}")
            .WithBody("{{catalog_description}}")
            .WithSubtitle("{{catalog_subtitle}}")
            .WithId("dynamic_catalog")
            .WithDynamicItems("catalog_endpoint_url")  // URL to fetch items dynamically
            .Build();

        var contentTypes = new ContentResource.Types.Builder()
            .WithTwilioCatalog(catalogContent)
            .Build();

        var variables = new Dictionary<string, string>
        {
            {"catalog_title", "{{1}}"},
            {"catalog_description", "{{2}}"},
            {"catalog_subtitle", "{{3}}"}
        };

        var contentRequest = new ContentResource.ContentCreateRequest.Builder()
            .WithFriendlyName("Dynamic Catalog Template")
            .WithLanguage("en")
            .WithVariables(variables)
            .WithTypes(contentTypes)
            .Build();

        var content = ContentResource.Create(contentRequest);
        Console.WriteLine($"Dynamic catalog created: {content.Sid}");
    }
}
```

## Key Features of Advanced Content Types

### Carousel Content
- **Multiple Cards**: Display several items in a scrollable format
- **Rich Media**: Each card can have images, titles, and descriptions
- **Interactive Actions**: Multiple action buttons per card
- **Perfect For**: Product showcases, service comparisons, feature highlights

### Catalog Content
- **Product Listings**: Structured product information with pricing
- **Categories**: Organize items by section titles
- **Sale Pricing**: Support for regular and sale prices
- **Dynamic Content**: Can fetch items from external APIs
- **Perfect For**: E-commerce, product browsing, inventory displays

### Best Practices for Advanced Content

1. **Optimize Card Count**: Keep carousel cards to 3-10 items for best UX
2. **Consistent Sizing**: Use similar image dimensions across cards
3. **Clear CTAs**: Make action buttons descriptive and actionable
4. **Price Formatting**: Always include currency codes for international support
5. **Fallback Content**: Provide alternative content for unsupported channels

### Error Handling for Complex Content

```csharp
try 
{
    var content = ContentResource.Create(contentRequest);
    Console.WriteLine($"Success: {content.Sid}");
}
catch (ApiException ex) when (ex.Code == 20001)
{
    Console.WriteLine("Invalid content structure");
}
catch (ApiException ex) when (ex.Code == 20429)
{
    Console.WriteLine("Rate limit exceeded");
    // Implement retry logic
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
```

These advanced content types enable rich, interactive experiences that can significantly improve customer engagement and conversion rates.