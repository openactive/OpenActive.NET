namespace OpenActive.NET.Tool.Models
{
    using System;
    using System.Collections.Generic;

    public class SchemaProperty : SchemaObject
    {
        public List<Uri> DomainIncludes { get; set; } = new List<Uri>();

        public List<Uri> RangeIncludes { get; set; } = new List<Uri>();
    }
}
