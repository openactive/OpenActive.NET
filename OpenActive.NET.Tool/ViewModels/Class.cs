﻿namespace OpenActive.NET.Tool.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    [DebuggerDisplay("{Name}")]
    public class Class : SchemaObject
    {
        public IEnumerable<Class> Ancestors => EnumerableExtensions
            .Traverse(this, x => x.Parents)
            .Where(x => x != this);

        public List<Class> Children { get; set; } = new List<Class>();

        public List<Class> CombinationOf { get; set; } = new List<Class>();

        public IEnumerable<Class> Descendants => EnumerableExtensions
            .Traverse(this, x => x.Children)
            .Where(x => x != this);

        public string Description { get; set; }

        public Uri Id { get; set; }

        public bool IsCombined { get; set; }

        public bool IsThingType => string.Equals(this.Name, "Thing", StringComparison.Ordinal);

        public List<Class> Parents { get; set; } = new List<Class>();

        public List<Property> Properties { get; set; } = new List<Property>();

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            // Namespace
            stringBuilder.AppendLine("namespace Schema.NET");
            stringBuilder.AppendLine("{");

            // Using statements
            stringBuilder.AppendIndentLine(4, "using System;");
            stringBuilder.AppendIndentLine(4, "using System.Runtime.Serialization;");
            stringBuilder.AppendIndentLine(4, "using Newtonsoft.Json;");
            stringBuilder.AppendLine();

            // Comment
            stringBuilder.AppendCommentSummary(4, this.Description);

            // Class
            stringBuilder.AppendIndentLine(4, "[DataContract]");
            if (this.IsCombined)
            {
                stringBuilder.AppendIndent(4, $"public abstract partial class {this.Name}");
            }
            else
            {
                stringBuilder.AppendIndent(4, $"public partial class {this.Name}");
            }

            if (this.Parents.Count == 0)
            {
                stringBuilder.AppendLine();
            }
            else if (this.Parents.Count == 1)
            {
                stringBuilder.Append($" : ");
                stringBuilder.AppendLine(this.Parents.First().Name);
            }
            else
            {
                throw new Exception("A class should only have one parent at this stage.");
            }

            stringBuilder.AppendIndentLine(4, "{");

            if (string.Equals(this.Name, "Thing", StringComparison.OrdinalIgnoreCase))
            {
                // Context Property
                stringBuilder.AppendIndentLine(8, "/// <summary>");
                stringBuilder.AppendIndentLine(8, "/// Gets the context for the object, specifying that it comes from schema.org.");
                stringBuilder.AppendIndentLine(8, "/// </summary>");
                stringBuilder.AppendIndentLine(8, "[DataMember(Name = \"@context\", Order = 0)]");
                stringBuilder.AppendIndentLine(8, $"public override string Context => \"http://schema.org\";");
                stringBuilder.AppendLine();
            }

            // Type Property
            stringBuilder.AppendIndentLine(8, "/// <summary>");
            stringBuilder.AppendIndentLine(8, "/// Gets the name of the type as specified by schema.org.");
            stringBuilder.AppendIndentLine(8, "/// </summary>");
            stringBuilder.AppendIndentLine(8, "[DataMember(Name = \"@type\", Order = 1)]");
            stringBuilder.AppendIndentLine(8, $"public override string Type => \"{this.Name}\";");

            // Properties
            var properties = this.Properties.OrderBy(x => x.Order).ToList();
            if (properties.Count > 0)
            {
                stringBuilder.AppendLine();
                var i = 0;
                foreach (var property in properties)
                {
                    var isLast = i == (properties.Count - 1);
                    property.AppendIndentLine(stringBuilder, 8);
                    if (!isLast)
                    {
                        stringBuilder.AppendLine();
                    }

                    ++i;
                }
            }

            stringBuilder.AppendIndentLine(4, "}");
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
    }
}
