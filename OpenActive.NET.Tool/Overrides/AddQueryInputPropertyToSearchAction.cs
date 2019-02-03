﻿namespace OpenActive.NET.Tool.Overrides
{
    using System;
    using System.Collections.Generic;
    using OpenActive.NET.Tool.ViewModels;

    public class AddQueryInputPropertyToSearchAction : IClassOverride
    {
        public bool CanOverride(Class @class) =>
            string.Equals(@class.Name, "SearchAction", StringComparison.Ordinal);

        public void Override(Class @class)
        {
            var property = new Property()
            {
                Class = @class,
                Description = new List<string> { "Gets or sets the query input search parameter." },
                JsonName = "query-input",
                Name = "QueryInput",
                Types = new List<PropertyType>()
                {
                    new PropertyType()
                    {
                        CSharpTypeString = "string",
                        Name = "Text"
                    },
                    new PropertyType()
                    {
                        CSharpTypeString = "PropertyValueSpecification",
                        Name = "PropertyValueSpecification"
                    }
                }
            };
            @class.Properties.Add(property);
        }
    }
}
