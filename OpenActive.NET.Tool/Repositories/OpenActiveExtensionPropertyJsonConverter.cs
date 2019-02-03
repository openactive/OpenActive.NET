namespace OpenActive.NET.Tool.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenActive.NET.Tool.Constants;
    using OpenActive.NET.Tool.Models;

    public class OpenActiveExtensionPropertyJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(List<SchemaObject>);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var token = JToken.Load(reader);
                var graphArray = (JArray)token["@graph"];
                return graphArray.ToList();
            }

            return Enumerable.Empty<SchemaObject>();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
            throw new NotImplementedException();

        private static SchemaObject Read(JToken token)
        {
            var commentToken = token["comment"];
            if (commentToken == null)
            {
                return null;
            }

            var supercededByToken = token["supersededBy"];
            if (supercededByToken != null)
            {
                // Ignore deprecated properties.
                return null;
            }

            var id = new Uri(token["id"].Value<string>());
            var types = GetTokenValues(token["type"]).ToList();
            var comment = token["comment"].Value<string>();
            var label = GetLabel(token);
            var domainIncludes = GetTokenValues(token["domainIncludes"]).Select(x => ReplacePrefix(x)).ToList();
            var rangeIncludes = GetTokenValues(token["rangeIncludes"]).Select(x => ReplacePrefix(x)).ToList();
            var subClassOf = GetTokenValues(token["subClassOf"]).Select(x => ReplacePrefix(x)).ToList();
            var layer = LayerName.OpenActiveBeta;

            if (types.Any(type => string.Equals(type, "Class", StringComparison.OrdinalIgnoreCase)))
            {
                return new SchemaClass()
                {
                    Comment = comment,
                    Id = id,
                    Label = label,
                    Layer = layer,
                    SubClassOfIds = subClassOf,
                    Types = types
                };
            }
            else if (types.Any(type => string.Equals(type, "Property", StringComparison.OrdinalIgnoreCase)))
            {
                return new SchemaProperty()
                {
                    Comment = comment,
                    DomainIncludes = domainIncludes,
                    Id = id,
                    Label = label,
                    Layer = layer,
                    RangeIncludes = rangeIncludes,
                    Types = types
                };
            }
            else
            {
                return new SchemaEnumerationValue()
                {
                    Comment = comment,
                    Id = id,
                    Label = label,
                    Layer = layer,
                    Types = types
                };
            }
        }

        private static string GetLabel(JToken token)
        {
            var labelToken = token["rdfs:label"];

            if (labelToken.Type == JTokenType.String)
            {
                return labelToken.Value<string>();
            }

            return labelToken["@value"].Value<string>();
        }

        private static IEnumerable<string> GetTokenValues(JToken token)
        {
            if (token != null)
            {
                if (token.Type == JTokenType.String)
                {
                    yield return token.Value<string>();
                }
                else if (token.Type == JTokenType.Array)
                {
                    foreach (var subToken in (JArray)token)
                    {
                        yield return subToken.Value<string>();
                    }
                }
            }
        }

        private static IEnumerable<Uri> GetTokenValues(JToken token, string name)
        {
            if (token != null)
            {
                if (token.Type == JTokenType.Object)
                {
                    yield return new Uri(token[name].Value<string>());
                }
                else if (token.Type == JTokenType.Array)
                {
                    foreach (var subToken in (JArray)token)
                    {
                        yield return new Uri(subToken[name].Value<string>());
                    }
                }
            }
        }

        // TODO: Auto-generate from OA namespaces
        private static Uri ReplacePrefix(string uri)
        {
            return new Uri(uri
                .Replace("schema:", "http://schema.org/")
                .Replace("pending:", "http://pending.schema.org/")
                .Replace("skos:", "http://www.w3.org/2004/02/skos/core#")
                .Replace("oa:", "https://openactive.io/")
                .Replace("beta:", "https://openactive.io/ns-beta#"));
        }
    }
}
