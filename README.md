# OpenActive.NET
OpenActive.io objects turned into strongly typed C# POCO classes for use in .NET. All classes can be serialized into JSON/JSON-LD, to provide easy conformance with the [OpenActive Modelling Specification](https://www.openactive.io/modelling-opportunity-data/).

## Simple Example

```C#
var event = new Event()
{
    Name = "Virtual BODYPUMP",
    Description = "This is the virtual version of the original barbell class, which will help you get lean, toned and fit - fast. Les Mills™ Virtual classes are designed for people who cannot get access to our live classes or who want to get a ‘taste’ of a Les Mills™ class before taking a live class with an instructor. The classes are played on a big video screen, with dimmed lighting and pumping surround sound, and are led onscreen by the people who actually choreograph the classes.",
    Duration = TimeSpan.FromDays(1),
    StartDate = new DateTimeOffset(2017, 4, 24, 19, 30, 0, TimeSpan.FromHours(-8)),
    Location = new Place()
    {
        Name = "Santa Clara City Library, Central Park Library",
        Address = new PostalAddress()
        {
            StreetAddress = "2635 Homestead Rd",
            AddressLocality = "Santa Clara",
            PostalCode = "95051",
            AddressRegion = "CA",
            AddressCountry = "US"
        }
    },
    Image = new List<ImageObject>() { new ImageObject { Url = new Uri("http://www.example.com/event_image/12345") } },
    EndDate = new DateTimeOffset(2017, 4, 24, 23, 0, 0, TimeSpan.FromHours(-8)),
    Offers = new List<Offer>() { new Offer()
    {
        Url = new Uri("https://www.example.com/event_offer/12345_201803180430"), 
        Price = 30, 
        PriceCurrency = "USD", 
        ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(-8))
    } },
    AttendeeInstructions = "Ensure you bring trainers and a bottle of water.",
    MeetingPoint = ""
};
var jsonLd = event.ToOpenActiveString();
```

The code above outputs the following JSON-LD:

```JSON
{
  "@context": "https://openactive.io/",
  "type": "Event",
  "name": "Virtual BODYPUMP",
  "description": "This is the virtual version of the original barbell class, which will help you get lean, toned and fit - fast. Les Mills™ Virtual classes are designed for people who cannot get access to our live classes or who want to get a ‘taste’ of a Les Mills™ class before taking a live class with an instructor. The classes are played on a big video screen, with dimmed lighting and pumping surround sound, and are led onscreen by the people who actually choreograph the classes.",
  "attendeeInstructions": "Ensure you bring trainers and a bottle of water.",
  "duration": "P1D",
  "image": [
    {
      "type": "ImageObject",
      "url": "http://www.example.com/event_image/12345"
    }
  ],
  "location": {
    "type": "Place",
    "name": "Santa Clara City Library, Central Park Library",
    "address": {
      "type": "PostalAddress",
      "addressCountry": "US",
      "addressLocality": "Santa Clara",
      "addressRegion": "CA",
      "postalCode": "95051",
      "streetAddress": "2635 Homestead Rd"
    }
  },
  "offers": [
    {
      "type": "Offer",
      "price": 30.0,
      "priceCurrency": "USD",
      "url": "https://www.example.com/event_offer/12345_201803180430",
      "validFrom": "2017-01-20T16:20:00-08:00"
    }
  ],
  "startDate": "2017-04-24T19:30:00-08:00",
  "endDate": "2017-04-24T23:00:00-08:00"
}
```

## Referencing Schema.org properties and types

The OpenActive data model builds on top of Schema.org, which means that you are free to use additional Schema.org properties within OpenActive published data.

To reflect this, OpenActive.NET uses inheritance to build on top of [Schema.NET](https://github.com/RehanSaeed/Schema.NET), and so makes it easy to use additional properties from Schema.org on any given type.

To avoid naming conflicts between OpenActive.NET and Schema.NET, it is recommended that you import `using OpenActive.NET;` to reference OpenActive model types, and use fully qualified references for Schema.NET types (e.g. `Schema.NET.Thing`).
