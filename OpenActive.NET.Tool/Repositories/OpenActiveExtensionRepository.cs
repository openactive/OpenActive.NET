namespace OpenActive.NET.Tool.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using OpenActive.NET.Tool.Constants;
    using OpenActive.NET.Tool.Models;

    public class OpenActiveExtensionRepository : ISchemaRepository
    {
        private readonly HttpClient httpClient;

        public OpenActiveExtensionRepository() =>
            this.httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://www.openactive.io")
            };

        public async Task<(List<SchemaClass> classes, List<SchemaProperty> properties, List<SchemaEnumerationValue> enumerationValues)> GetObjects()
        {
            var schemaObjects = await this.GetSchemaObjects();
            var enumerations = schemaObjects.OfType<SchemaEnumerationValue>().ToList();
            var classes = schemaObjects.OfType<SchemaClass>().ToList();

            foreach (var enumeration in enumerations)
            {
                enumeration.Layer = LayerName.OpenActiveBeta;
            }

            foreach (var @class in classes)
            {
                @class.Layer = LayerName.OpenActiveBeta;
                @class.SubClassOf = classes.Where(x => @class.SubClassOfIds.Contains(x.Id)).ToList();
            }

            return (classes,
                schemaObjects.OfType<SchemaProperty>().ToList(),
                schemaObjects.OfType<SchemaEnumerationValue>().ToList());
        }

        public async Task<List<SchemaObject>> GetSchemaObjects()
        {
            var response = await this.httpClient.GetAsync("/ns-beta/beta.jsonld");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<List<SchemaObject>>(json, new OpenActiveExtensionPropertyJsonConverter());
        }

        private static T Deserialize<T>(string json, JsonConverter converter) =>
            JsonConvert.DeserializeObject<T>(
                json,
                converter);

        private static T Deserialize<T>(string json) =>
            JsonConvert.DeserializeObject<T>(
                json,
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
    }
}
