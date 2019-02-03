namespace OpenActive.NET.Tool.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SchemaClass : SchemaObject
    {
        public bool IsEnum => EnumerableExtensions
            .Traverse(this, x => x.SubClassOf)
            .Any(x => x.Id == new Uri("http://schema.org/Enumeration"));

        public bool IsPrimitive => new string[]
        {
            "QualitativeValue",
            "Enumeration",
            "Boolean",
            "Date",
            "DateTime",
            "Number",
            "Integer",
            "Float",
            "Text",
            "XPathType",
            "CssSelectorType",
            "Quantity",
            "Mass",
            "Energy",
            "Distance",
            "Duration",
            "Time",
            "URL",
            "DataType"
        }.Contains(this.Label);

        public List<SchemaClass> SubClassOf { get; set; } = new List<SchemaClass>();

        public List<Uri> SubClassOfIds { get; set; } = new List<Uri>();
    }
}
