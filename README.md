# OpenActive.NET [![Nuget](https://img.shields.io/nuget/v/OpenActive.NET.svg)](https://www.nuget.org/packages/OpenActive.NET/) ![Tested and Published on NuGet](https://github.com/openactive/OpenActive.NET/workflows/Tested%20and%20Published%20on%20NuGet/badge.svg?branch=master)
.NET classes and resources supporting RPDE feed creation and Open Booking API implementation, to create something like the feeds available [here](https://opendata.fusion-lifestyle.com/OpenActive/) (or any of the other feeds available at the examples listed [here](http://status.openactive.io/)).

This package is intended to simplify the creation of [OpenActive RPDE Feeds](https://developer.openactive.io/publishing-data/data-feeds/how-a-data-feed-works) using templates.

Please find full documentation that covers creation and scaling of RPDE feeds at https://developer.openactive.io/publishing-data/data-feeds/.

OpenActive aims to provide strongly typed models for all classes defined in the [Modelling Specification](https://openactive.io/modelling-opportunity-data/) and [Open Booking API Specification](https://openactive.io/open-booking-api/) across the PHP, Ruby, and .NET languages. This library is specific to .NET; see also the [PHP](https://github.com/openactive/models-php/) and [Ruby](https://github.com/openactive/models-ruby/) implementations.

## Table of Contents
- [Requirements](#requirements)
- [Models](#models)
    - [OpenActive](#openactive)
    - [schema.org](#schemaorg)
    - [Full Models Example](#full-models-example)
- [RPDE Feed Publishing](#rpde-feed-publishing)
    - [Modified Timestamp and ID Ordering Strategy](#modified-timestamp-and-id-ordering-strategy)
    - [Incrementing Unique Change Number Ordering Strategy](#incrementing-unique-change-number-ordering-strategy)
    - [Full RPDE Example](#full-rpde-example)
- [Serialization Methods](#serialization-methods)
    - [Empty Lists](#empty-lists)
    - [`OpenActiveSerializer.Serialize<T>(T obj)`](#openactiveserializerserializett-obj)
    - [`OpenActiveSerializer.SerializeList<T>(List<T> obj)`](#openactiveserializerserializelisttlistt-obj)
    - [`OpenActiveSerializer.SerializeToHtmlEmbeddableString<T>(T obj)`](#openactiveserializerserializetohtmlembeddablestringtt-obj)
    - [`OpenActiveSerializer.SerializeRpdePage(RpdePage obj)`](#openactiveserializerserializerpdepagerpdepage-obj)
    - [`OpenActiveSerializer.Deserialize<T>(string str)`](#openactiveserializerdeserializetstring-str)
    - [`OpenActiveSerializer.DeserializeList<T>(string str)`](#openactiveserializerdeserializelisttstring-str)
    - [`OpenActiveSerializer.DeserializeRpdePage<T>(string str)`](#openactiveserializerdeserializerpdepagetstring-str)
- [Contributing](#contributing)

## Requirements
This library is compatible with .NET Standard 1.1 and later (.NET Framework 4.5 and .NET Core 1.0).

## Models

OpenActive.NET includes OpenActive.io objects as strongly typed C# POCO classes for use in .NET. All classes can be serialized into JSON-LD, to provide easy conformance with the [Modelling Specification](https://www.openactive.io/modelling-opportunity-data/) and [Open Booking API Specification](https://www.openactive.io/open-booking-api/).

Note that empty strings are automatically ignored during serialization, however empty lists need to be explicitly set to `null` in order to conform to the OpenActive serialization rules.

An extension method `.ToListOrNullIfEmpty()` is provided for this purpose, which should be used on any lists being set on the model.


### OpenActive

Classes for all OpenActive classes are available in the `OpenActive.NET` namespace, and can be easily serialized to JSON-LD, as follows. Enumerations are available as `enum`s for properties that require their use.

```C#
var event = new Event()
{
    Name = "Virtual BODYPUMP",
    EventStatus =  Schema.NET.EventStatusType.EventScheduled
};
var jsonLd = OpenActiveSerializer.Serialize(event);
```

Value of `jsonLd`:
```JSON
{
  "@context": "https://openactive.io/",
  "@type": "Event",
  "name": "Virtual BODYPUMP",
  "eventStatus": "https://schema.org/EventScheduled"
}
```

### schema.org

The OpenActive data model builds on top of Schema.org, which means that you are free to use additional schema.org properties within OpenActive published data.

To reflect this, OpenActive.NET uses inheritance to build on top of [Schema.NET](https://github.com/RehanSaeed/Schema.NET), and so makes it easy to use additional properties from schema.org on any given type.

To avoid naming conflicts between OpenActive.NET and Schema.NET, it is recommended that you import `using OpenActive.NET;` to reference OpenActive model types, and use **fully qualified references** for Schema.NET types (e.g. `Schema.NET.Thing`).

```C#
var event = new Event()
{
    Name = "Virtual BODYPUMP",
    Review = new Schema.NET.Review
    {
        ReviewBody = "So was I really there?"
    }
};
var jsonLd = OpenActiveSerializer.Serialize(event);
```

Value of `jsonLd`:
```JSON
{
  "@context": "https://openactive.io/",
  "@type": "Event",
  "name": "Virtual BODYPUMP",
  "review": {
      "@type": "Review",
      "reviewBody": "So was I really there?"
  }
}
```


### Full Models Example

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
    Offers = new List<Offer>() { 
        new Offer()
        {
            Url = new Uri("https://www.example.com/event_offer/12345_201803180430"), 
            Price = 30, 
            PriceCurrency = "USD", 
            ValidFrom = new DateTimeOffset(2017, 1, 20, 16, 20, 0, TimeSpan.FromHours(-8))
        } 
    }.ToListOrNullIfEmpty(),
    AttendeeInstructions = "Ensure you bring trainers and a bottle of water.",
    MeetingPoint = ""
};
var jsonLd = OpenActiveSerializer.Serialize(event);
```

The code above outputs the following JSON-LD:

```JSON
{
  "@context": "https://openactive.io/",
  "@type": "Event",
  "name": "Virtual BODYPUMP",
  "description": "This is the virtual version of the original barbell class, which will help you get lean, toned and fit - fast. Les Mills™ Virtual classes are designed for people who cannot get access to our live classes or who want to get a ‘taste’ of a Les Mills™ class before taking a live class with an instructor. The classes are played on a big video screen, with dimmed lighting and pumping surround sound, and are led onscreen by the people who actually choreograph the classes.",
  "attendeeInstructions": "Ensure you bring trainers and a bottle of water.",
  "duration": "P1D",
  "image": [
    {
      "@type": "ImageObject",
      "url": "http://www.example.com/event_image/12345"
    }
  ],
  "location": {
    "@type": "Place",
    "name": "Santa Clara City Library, Central Park Library",
    "address": {
      "@type": "PostalAddress",
      "addressCountry": "US",
      "addressLocality": "Santa Clara",
      "addressRegion": "CA",
      "postalCode": "95051",
      "streetAddress": "2635 Homestead Rd"
    }
  },
  "offers": [
    {
      "@type": "Offer",
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


## RPDE Feed Publishing 

To publish an OpenActive data feed (see this [video explainer](https://developer.openactive.io/publishing-data/data-feeds/how-a-data-feed-works)), OpenActive.NET provides a drop-in solution to render the feed pages. This also includes validation for the underlying feed query.

### Modified Timestamp and ID Ordering Strategy

`RpdePage(feedBaseUrl, afterTimestamp, afterId, items)`

Creates a new RPDE Page based on the RPDE Items provided using the [Modified Timestamp and ID Ordering Strategy](https://www.w3.org/2017/08/realtime-paged-data-exchange/#modified-timestamp-and-id), given the `afterTimestamp` and `afterId` parameters of the current query. Also validates that the items are in the correct order, throwing a `SerializationException` if this is not the case.

```C#
var items = new List<RpdeItem>
{
    new RpdeItem
    {
        Id = "1",
        Modified = 3,
        State = RpdeState.Updated,
        Kind = RpdeKind.SessionSeries,
        Data = @event
    },
    new RpdeItem
    {
        Id = "2",
        Modified = 4,
        State = RpdeState.Deleted,
        Kind = RpdeKind.SessionSeries,
        Data = null
    }
};

var jsonLd = new RpdePage(new Uri("https://www.example.com/feed"), 1, "1", items).ToString();
```


### Incrementing Unique Change Number Ordering Strategy

`RpdePage(feedBaseUrl, afterChangeNumber, items)`

Creates a new RPDE Page based on the RPDE Items provided using the [Incrementing Unique Change Number Ordering Strategy](https://www.w3.org/2017/08/realtime-paged-data-exchange/#incrementing-unique-change-number), given the `afterChangeNumber` parameter of the current query. Also validates that the items are in the correct order, throwing a `SerializationException` if this is not the case.

```C#
var items = new List<RpdeItem>
{
    new RpdeItem
    {
        Id = "1",
        Modified = 3,
        State = RpdeState.Updated,
        Kind = RpdeKind.SessionSeries,
        Data = @event
    },
    new RpdeItem
    {
        Id = "2",
        Modified = 4,
        State = RpdeState.Deleted,
        Kind = RpdeKind.SessionSeries,
        Data = null
    }
};

var jsonLd = new RpdePage(new Uri("https://www.example.com/feed"), 2, items).ToString();
```

### Full RPDE Example

Implementation requires implementing `ConvertToOpenActiveModel` to return an instance of e.g. `OpenActive.NET.ScheduledSession` or `OpenActive.NET.Event` as per the OpenActive.NET Model section below.

```C#
using OpenActive.NET.Rpde.Version1;

public abstract class RPDEBase<DatabaseType> where DatabaseType : RPDEBase<DatabaseType>, new()
{
    protected abstract RpdeKind RpdeKind { get; }
    
    protected abstract Schema.NET.Thing ConvertToOpenActiveModel(DatabaseType record, string baseUrl);

    private async Task<RpdePage<Schema.NET.Thing>> GetRPDEPage(long? afterChangeNumber, string feedUrl, string baseUrl, int limit)
    {
        var items = new List<RpdeItem>();

        DatabaseFactory.ColumnSerializer = new NPocoSerializer();
        using (Database db = new Database("DefaultConnection"))
        {
            // Get the table name manually as we are constructing the query by hand
            var tableName = db.PocoDataFactory.ForType(typeof(DatabaseType)).TableInfo.TableName;

            // Query for paging as shown in https://www.openactive.io/realtime-paged-data-exchange/#incrementing-unique-change-number
            // Note due to the issues with big endian vs little endian conversion when converting from rowversion in SQL Server to int64 in C#, it is best to do the
            // conversion in both directions in SQL Server, as below
            var whereClause = afterChangeNumber != null ? "WHERE Modified > Convert(ROWVERSION, @0)" : "";
            var results = await db.QueryAsync<DatabaseType>($"SELECT TOP {limit} Convert(BIGINT,Modified) as ChangeNumber, u.* from {tableName} u (nolock) {whereClause} ORDER BY Modified", afterChangeNumber);

            items = results.Select(row => new RpdeItem
            {
                Id = row.ID,
                Modified = row.modified,
                Data = row.Deleted ? null : ConvertToOpenActiveModel(row, baseUrl),
                State = row.Deleted ? RpdeState.Deleted : RpdeState.Updated,
                Kind = RpdeKind
            }).ToList();
        }

        return new RpdePage(feedUrl, afterChangeNumber, items);
    }
    
    public static async Task<HttpResponseMessage> ServeRPDEPage(HttpRequestMessage req, int limit)
    {
        // parse query parameter 'afterChangeNumber'
        long? afterChangeNumber = Convert.ToInt64(req.GetQueryNameValuePairs()
            .FirstOrDefault(q => string.Compare(q.Key, "afterChangeNumber", true) == 0)
            .Value);

        // Get base Urls
        var urlHelper = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);
        var baseUrl = req.RequestUri.RewriteHttps().GetLeftPart(UriPartial.Authority) + urlHelper.Content("~/");
        var feedUrl = req.RequestUri.RewriteHttps().GetLeftPart(UriPartial.Path);

        // Instantiate DatabaseType to make use of inheritance in GetRPDEPage
        var rpdePage = await (new DatabaseType()).GetRPDEPage(afterChangeNumber, feedUrl, baseUrl, limit);

        // If no page returned, return error
        if (rpdePage == null)
        {
            return req.CreateResponse(HttpStatusCode.BadRequest, "Invalid parameters");
        }

        // Render reponse as JSON
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Content = rpdePage.ToStringContent();

        // Always use MaxAge cache header for a full page
        if (rpdePage?.Items?.Count > 0)
        {
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = TimeSpan.FromHours(1),
                SharedMaxAge = TimeSpan.FromHours(1)
            };
        }
        else
        {
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = TimeSpan.FromSeconds(8),
                SharedMaxAge = TimeSpan.FromSeconds(8)
            };
        }
        return response;
    }    
}
```

## Serialization Methods

### Empty Lists

Empty strings are automatically ignored during serialization, however empty lists need to be explicitly set to `null` in order to conform to the OpenActive specification.

An extension method `.ToListOrNullIfEmpty()` is provided for this purpose, which should be used on any lists being set on the model.

```C#
var event = new Event()
{
    Name = "Virtual BODYPUMP"
    Offers = offers.ToListOrNullIfEmpty();
};
var jsonLd = OpenActiveSerializer.Serialize(event);
```


### `OpenActiveSerializer.Serialize<T>(T obj)`
Returns the JSON-LD representation of a `JsonLdObject`.

```C#
var event = new Event()
{
    Name = "Virtual BODYPUMP"
};
var jsonLd = OpenActiveSerializer.Serialize(event);
```

Value of `jsonLd`:
```JSON
{
  "@context": "https://openactive.io/",
  "@type": "Event",
  "name": "Virtual BODYPUMP"
}
```

### `OpenActiveSerializer.SerializeList<T>(List<T> obj)`
Returns the JSON-LD representation of a list of `JsonLdObject`.

```C#
var concepts = new List<Concept>
{
    new Concept
    {
        Id = new Uri("https://openactive.io/facility-types#37bbed12-270b-42b1-9af2-70f0273990dd"),
        PrefLabel = "Grass",
        InScheme = new Uri("https://openactive.io/facility-types")
    }
};
var jsonLd = OpenActiveSerializer.SerializeList(event);
```

Value of `jsonLd`:
```JSON
[
    {
        "@context":"https://openactive.io/",
        "@type":"Concept",
        "@id":"https://openactive.io/facility-types#37bbed12-270b-42b1-9af2-70f0273990dd",
        "inScheme":"https://openactive.io/facility-types",
        "prefLabel":"Grass"
    }
]
```


### `OpenActiveSerializer.SerializeToHtmlEmbeddableString<T>(T obj)`
Returns the JSON-LD representation of an `JsonLdObject`, including `"https://schema.org"` in the `"@context"` property,
to make the output compatible with search engines, for SEO.

This method should be used when you want to embed the output raw (as-is) into a web
page. It uses serializer settings with HTML escaping to avoid Cross-Site Scripting (XSS)
vulnerabilities if the object was constructed from an untrusted source.

```C#
var event = new Event()
{
    Name = "Virtual BODYPUMP"
};
var jsonLd = OpenActiveSerializer.SerializeToHtmlEmbeddableString(event);
```

Value of `jsonLd`:
```JSON
{
  "@context": ["https://schema.org", "https://openactive.io/"],
  "@type": "Event",
  "name": "Virtual BODYPUMP"
}
```


### `OpenActiveSerializer.SerializeRpdePage(RpdePage obj)`
Returns the serialized representation of an `RpdePage`. Note that `OpenActiveSerializer.Serialize<T>` cannot be used on an `RpdePage`, as RPDE itself is not a JSON-LD based format.


### `OpenActiveSerializer.Deserialize<T>(string str)`
Returns a strongly typed model of the JSON-LD representation provided.

Note this will return null if the deserialized JSON-LD class cannot be assigned to `T`.

Hence `OpenActiveSerializer.Deserialize<SessionSeries>(eventJson);` would return null where `eventJson` represented an `Event`.


### `OpenActiveSerializer.DeserializeList<T>(string str)`
Returns a strongly typed list of models of the given type of the JSON-LD representation provided.


### `OpenActiveSerializer.DeserializeRpdePage<T>(string str)`
Returns a strongly typed model of the RPDE page provided.


## Contributing

### Automatic model regeneration

Data model updates automatically trigger [model regeneration in CI](https://github.com/openactive/OpenActive.NET/actions/workflows/create-data-model-pr.yaml), which generates a new PR with the changes.

The `models-lib` code generator is used to generate the model classes in this repository. See [here](https://github.com/openactive/models-lib#specific-examples) for more information.

### Pull requests

Contributions are very welcome. Please raise an issue or pull request as appropriate.

Please note that updates to the data models themselves will not be accepted as pull requests, and must instead be made upstream in the [Data Models](https://github.com/openactive/data-models), [Test Interface](https://openactive.io/test-interface/) or [Beta Namespace](https://openactive.io/ns-beta/) repositories.

### Publishing to NuGet through CI

New commits to the `master` branch will trigger an automatic patch version bump and push to NuGet. To increment the major or version of the library, update [this file](https://github.com/openactive/OpenActive.NET/blob/master/version.json#L3) within your PR.

### Publishing to NuGet

1. Bump the version number of OpenActive.NET
2. Rebuild OpenActive.NET
3. Generate new API key from https://www.nuget.org/account/apikeys
4. `dotnet nuget push C:\repos\OpenActive.NET\OpenActive.NET\bin\Release\OpenActive.NET.8.6.3.nupkg -k qz2jga8pl3dvn2akksyquwcs9ygggg4exypy3bhxy6w6x6 -s https://api.nuget.org/v3/index.json`
