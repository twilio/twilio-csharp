# Content API - List Picker Content Example

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
            // Create list items
            var items = new List<ContentResource.ListItem>();

            var item1 = new ContentResource.ListItem.Builder()
                .WithId("product_a")
                .WithItem("Premium Plan")
                .WithDescription("Full access to all features with priority support")
                .Build();

            var item2 = new ContentResource.ListItem.Builder()
                .WithId("product_b")
                .WithItem("Standard Plan")
                .WithDescription("Access to core features with email support")
                .Build();

            var item3 = new ContentResource.ListItem.Builder()
                .WithId("product_c")
                .WithItem("Basic Plan")
                .WithDescription("Limited features with community support")
                .Build();

            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            // Create list picker content
            var listPickerContent = new ContentResource.TwilioListPicker.Builder()
                .WithBody("Choose the plan that best fits your needs:")
                .WithButton("Select Plan")
                .WithItems(items)
                .Build();

            // Create the content types object
            var contentTypes = new ContentResource.Types.Builder()
                .WithTwilioListPicker(listPickerContent)
                .Build();

            // Create the content request
            var contentRequest = new ContentResource.ContentCreateRequest.Builder()
                .WithFriendlyName("Subscription Plans List")
                .WithLanguage("en")
                .WithTypes(contentTypes)
                .Build();

            // Create the content
            var content = ContentResource.Create(contentRequest);

            Console.WriteLine($"List picker content created successfully!");
            Console.WriteLine($"Content SID: {content.Sid}");
            Console.WriteLine($"Friendly Name: {content.FriendlyName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating list picker content: {ex.Message}");
        }
    }
}
```

This example shows how to create a list picker content that includes:

1. **Message body**: Introduction text explaining the list
2. **Button text**: The text shown on the button that opens the list
3. **List items**: Each item contains:
   - `Id`: Unique identifier for the option
   - `Item`: The main title/name of the option
   - `Description`: Additional details about the option

List pickers are perfect for presenting multiple options with descriptions, such as product catalogs, service plans, or menu items where users need more context to make informed decisions.