namespace OpenActive.NET.Tool.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using OpenActive.NET.Tool.Models;

    public class OpenActiveModelRepository : ISchemaRepository
    {
        private readonly HttpClient httpClient;

        public async Task<(List<SchemaClass> classes, List<SchemaProperty> properties, List<SchemaEnumerationValue> enumerationValues)> GetObjects()
        {
            var schemaObjects = this.GetModelObjects();
            var enumObjects = this.GetEnumObjects();
            var enumerations = schemaObjects.OfType<SchemaClass>().ToList();
            var classes = schemaObjects.OfType<SchemaClass>().ToList();

            foreach (var enumeration in enumerations)
            {
                var schemaTreeClass = schemaTreeClasses.FirstOrDefault(x => new Uri("http://schema.org/" + x.Name) == enumeration.Id);
                if (schemaTreeClass != null)
                {
                    enumeration.Layer = schemaTreeClass.Layer;
                }
            }

            foreach (var @class in classes)
            {
                var schemaTreeClass = schemaTreeClasses.FirstOrDefault(x => new Uri("http://schema.org/" + x.Name) == @class.Id);
                if (schemaTreeClass != null)
                {
                    @class.Layer = schemaTreeClass.Layer;
                }

                @class.SubClassOf = classes.Where(x => @class.SubClassOfIds.Contains(x.Id)).ToList();
            }

            return (classes,
                schemaObjects.OfType<SchemaProperty>().ToList(),
                schemaObjects.OfType<SchemaEnumerationValue>().ToList());
        }

        public List<OpenActiveModel> GetModelObjects()
        {
            var json = System.IO.File.ReadAllLines(@".\data-model\models.json");
            return Deserialize<List<OpenActiveModel>>(json, new SchemaPropertyJsonConverter());
        }

        public List<OpenActiveEnum> GetEnumObjects()
        {
            var json = System.IO.File.ReadAllLines(@".\data-model\enums.json");
            return Deserialize<List<OpenActiveEnum>>(json, new SchemaPropertyJsonConverter());
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
