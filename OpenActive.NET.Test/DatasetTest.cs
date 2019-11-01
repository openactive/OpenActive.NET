using Newtonsoft.Json;
using OpenActive.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace OpenActive.NET.Test
{
    // https://developers.google.com/search/docs/data-types/events
    public class DatasetTest
    {
        private readonly ITestOutputHelper output;

        public DatasetTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        private static readonly string NullString = null;

        private readonly Dataset @dataset = new OpenActive.NET.Dataset
        {
            Id = new Uri("https://example.com/1"),
            Url = new Uri("https://example.com/1"),
            Name = "Acme Sessions and Facilities",
            Description = "Near real-time availability and rich descriptions relating to the sessions and facilities available from {settings.organisationName}, published using the OpenActive Modelling Specification 2.0.",
            Keywords = new List<string> {
                    "Sessions",
                    "Facilities",
                    "Activities",
                    "Sports",
                    "Physical Activity",
                    "OpenActive"
                },
            License = new Uri("https://creativecommons.org/licenses/by/4.0/"),
            InLanguage = new List<string> { "en-GB" },
            SchemaVersion = new Uri("https://www.openactive.io/modelling-opportunity-data/2.0/"),
            Publisher = new OpenActive.NET.Organization
            {
                Name = "Acme",
                LegalName = "Acme Ltd",
                Description = NullString,
                Logo = new OpenActive.NET.ImageObject
                {
                    Url = new Uri("https://example.com/logo.png")
                }
            },
            Distribution = new List<DataDownload>
            {
                new DataDownload
                {
                    Name = "SessionSeries",
                    AdditionalType = new Uri("https://openactive.io/SessionSeries"),
                    EncodingFormat = OpenActiveDiscovery.MediaTypes.Version1.RealtimePagedDataExchange.ToString(),
                    ContentUrl = ("feeds/session-series").ParseUrlOrNull()
                },
                new DataDownload
                {
                    Name = "ScheduledSession",
                    AdditionalType = new Uri("https://openactive.io/ScheduledSession"),
                    EncodingFormat = OpenActiveDiscovery.MediaTypes.Version1.RealtimePagedDataExchange.ToString(),
                    ContentUrl = ("feeds/scheduled-sessions").ParseUrlOrNull()
                },
                new DataDownload
                {
                    Name = "FacilityUse",
                    AdditionalType = new Uri("https://openactive.io/FacilityUse"),
                    EncodingFormat = OpenActiveDiscovery.MediaTypes.Version1.RealtimePagedDataExchange.ToString(),
                    ContentUrl = ("feeds/facility-uses").ParseUrlOrNull()
                },
                new DataDownload
                {
                    Name = "Slot",
                    AdditionalType = new Uri("https://openactive.io/Slot"),
                    EncodingFormat = OpenActiveDiscovery.MediaTypes.Version1.RealtimePagedDataExchange.ToString(),
                    ContentUrl = ("feeds/slots").ParseUrlOrNull()
                }
            }
        };

        private readonly string json =
        @"{""@context"":[""https://schema.org/"",""https://openactive.io/""],""@type"":""Dataset"",""@id"":""https://example.com/1"",""name"":""Acme Sessions and Facilities"",""description"":""Near real-time availability and rich descriptions relating to the sessions and facilities available from {settings.organisationName}, published using the OpenActive Modelling Specification 2.0."",""distribution"":[{""@type"":""DataDownload"",""name"":""SessionSeries"",""additionalType"":""https://openactive.io/SessionSeries"",""encodingFormat"":""application/vnd.openactive.rpde+json; version=1""},{""@type"":""DataDownload"",""name"":""ScheduledSession"",""additionalType"":""https://openactive.io/ScheduledSession"",""encodingFormat"":""application/vnd.openactive.rpde+json; version=1""},{""@type"":""DataDownload"",""name"":""FacilityUse"",""additionalType"":""https://openactive.io/FacilityUse"",""encodingFormat"":""application/vnd.openactive.rpde+json; version=1""},{""@type"":""DataDownload"",""name"":""Slot"",""additionalType"":""https://openactive.io/Slot"",""encodingFormat"":""application/vnd.openactive.rpde+json; version=1""}],""inLanguage"":[""en-GB""],""keywords"":[""Sessions"",""Facilities"",""Activities"",""Sports"",""Physical Activity"",""OpenActive""],""license"":""https://creativecommons.org/licenses/by/4.0/"",""publisher"":{""@type"":""Organization"",""name"":""Acme"",""legalName"":""Acme Ltd"",""logo"":{""@type"":""ImageObject"",""url"":""https://example.com/logo.png""}},""schemaVersion"":""https://www.openactive.io/modelling-opportunity-data/2.0/"",""url"":""https://example.com/1""}";

        [Fact]
        public void ToString_DatasetGoogleStructuredData_ReturnsExpectedJsonLd() {
            output.WriteLine(this.@dataset.ToOpenActiveHtmlEmbeddableString());
            Assert.Equal(this.json, this.@dataset.ToOpenActiveHtmlEmbeddableString());
        }

        [Fact]
        public void ToString_Dataset()
        {
            output.WriteLine(this.@dataset.ToOpenActiveHtmlEmbeddableString());
            Assert.Equal("Acme Ltd", this.@dataset.Publisher.LegalName);
        }
    }
}
