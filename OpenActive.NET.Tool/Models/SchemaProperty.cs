﻿namespace OpenActive.NET.Tool.Models
{
    using System;
    using System.Collections.Generic;
    using OpenActive.NET.Tool.Constants;

    public class SchemaProperty : SchemaObject
    {
        public List<Uri> DomainIncludes { get; set; } = new List<Uri>();

        public bool IsArchived => string.Equals(this.Layer, LayerName.Archived, StringComparison.OrdinalIgnoreCase);

        public bool IsMeta => string.Equals(this.Layer, LayerName.Meta, StringComparison.OrdinalIgnoreCase);

        public bool IsPending => string.Equals(this.Layer, LayerName.Pending, StringComparison.OrdinalIgnoreCase);

        public List<Uri> RangeIncludes { get; set; } = new List<Uri>();
    }
}
