﻿namespace OpenActive.NET.Tool.Services
{
    using System.Collections.Generic;

    public class PropertyNameComparer : IComparer<string>
    {
        public static readonly Dictionary<string, int> KnownPropertyNameOrders = new Dictionary<string, int>
        {
            { "context", 0 },
            { "type", 1 },
            { "id", 2 },
            { "title", 3 },
            { "name", 4 },
            { "description", 5 }
        };

        public int Compare(string x, string y)
        {
            x = x.ToLower();
            y = y.ToLower();

            if (x.Equals("enddate"))
            {
                x = "startdate1";
            }
            else if (y.Equals("enddate"))
            {
                y = "startdate1";
            }

            var isXKnown = KnownPropertyNameOrders.ContainsKey(x);
            var isYKnown = KnownPropertyNameOrders.ContainsKey(y);
            if (isXKnown && isYKnown)
            {
                var xIndex = KnownPropertyNameOrders[x];
                var yIndex = KnownPropertyNameOrders[y];
                return xIndex.CompareTo(yIndex);
            }
            else if (isXKnown)
            {
                return -1;
            }
            else if (isYKnown)
            {
                return 1;
            }

            return x.CompareTo(y);
        }
    }
}
