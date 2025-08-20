# Content API - Location Content Example

```csharp
using System;
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
            // Create location content
            var locationContent = new ContentResource.TwilioLocation.Builder()
                .WithLatitude(37.7749m)  // San Francisco latitude
                .WithLongitude(-122.4194m)  // San Francisco longitude
                .WithLabel("Twilio HQ")
                .WithId("twilio_hq_location")
                .WithAddress("375 Beale St, San Francisco, CA 94105, USA")
                .Build();

            // Create the content types object
            var contentTypes = new ContentResource.Types.Builder()
                .WithTwilioLocation(locationContent)
                .Build();

            // Create the content request
            var contentRequest = new ContentResource.ContentCreateRequest.Builder()
                .WithFriendlyName("Twilio Headquarters Location")
                .WithLanguage("en")
                .WithTypes(contentTypes)
                .Build();

            // Create the content
            var content = ContentResource.Create(contentRequest);

            Console.WriteLine($"Location content created successfully!");
            Console.WriteLine($"Content SID: {content.Sid}");
            Console.WriteLine($"Friendly Name: {content.FriendlyName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating location content: {ex.Message}");
        }
    }
}
```

## Alternative Example - Store Location with Variables

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
            // Create location content for a store
            var locationContent = new ContentResource.TwilioLocation.Builder()
                .WithLatitude(40.7589m)  // New York latitude
                .WithLongitude(-73.9851m)  // New York longitude
                .WithLabel("{{store_name}}")  // Template variable for store name
                .WithId("store_location")
                .WithAddress("{{store_address}}")  // Template variable for address
                .Build();

            // Create the content types object
            var contentTypes = new ContentResource.Types.Builder()
                .WithTwilioLocation(locationContent)
                .Build();

            // Create variables for personalization
            var variables = new Dictionary<string, string>
            {
                {"store_name", "{{1}}"},
                {"store_address", "{{2}}"}
            };

            // Create the content request
            var contentRequest = new ContentResource.ContentCreateRequest.Builder()
                .WithFriendlyName("Store Location Template")
                .WithLanguage("en")
                .WithVariables(variables)
                .WithTypes(contentTypes)
                .Build();

            // Create the content
            var content = ContentResource.Create(contentRequest);

            Console.WriteLine($"Location template created successfully!");
            Console.WriteLine($"Content SID: {content.Sid}");
            Console.WriteLine($"This template can be personalized with specific store details when sending.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating location template: {ex.Message}");
        }
    }
}
```

These examples show how to create location content that includes:

1. **Coordinates**: Latitude and longitude for precise positioning
2. **Label**: Display name for the location
3. **Address**: Human-readable address
4. **ID**: Unique identifier for the location

Location content is perfect for:
- Sharing business locations with customers
- Providing directions to events or meetings
- Creating location-based templates for multiple stores or offices
- Emergency location sharing scenarios

The second example shows how to use template variables to create reusable location content that can be personalized for different locations.