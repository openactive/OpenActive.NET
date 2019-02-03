﻿namespace OpenActive.NET.Tool.Overrides
{
    using System;
    using System.Linq;
    using OpenActive.NET.Tool.ViewModels;

    // See https://schema.org/docs/actions.html#part-3
    public class AddTextTypeToActionTarget : IClassOverride
    {
        public bool CanOverride(Class @class) =>
            string.Equals(@class.Name, "Action", StringComparison.OrdinalIgnoreCase);

        public void Override(Class @class)
        {
            var property = @class.Properties.First(x => string.Equals(x.Name, "target", StringComparison.OrdinalIgnoreCase));
            property.Types.Add(
                new PropertyType()
                {
                    CSharpTypeString = "Uri",
                    Name = "URL"
                });
        }
    }
}
