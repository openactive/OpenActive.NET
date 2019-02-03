namespace OpenActive.NET.Tool.Overrides
{
    using OpenActive.NET.Tool.ViewModels;

    public interface IEnumerationOverride
    {
        bool CanOverride(Enumeration enumeration);

        void Override(Enumeration enumeration);
    }
}
