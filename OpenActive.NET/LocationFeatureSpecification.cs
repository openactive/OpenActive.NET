using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OpenActive.NET
{
    public partial class LocationFeatureSpecification : Schema.NET.LocationFeatureSpecification
    {
        public LocationFeatureSpecification CloneWithValue(bool value)
        {
            LocationFeatureSpecification copy = MemberwiseClone() as LocationFeatureSpecification;
            copy.Value = value;
            return copy;
        }
    }
}