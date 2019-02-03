namespace OpenActive.NET.Tool.Overrides
{
    using System;
    using OpenActive.NET.Tool.ViewModels;

    public class WarnEmptyEnumerations : IEnumerationOverride
    {
        public bool CanOverride(Enumeration enumeration) => enumeration.Values.Count == 0;

        public void Override(Enumeration enumeration)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Enumeration {enumeration.Layer}.{enumeration.Name} has no values");
            Console.ResetColor();
        }
    }
}
