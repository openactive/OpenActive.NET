namespace OpenActive.NET.Tool.Overrides
{
    using OpenActive.NET.Tool.ViewModels;

    public interface IClassOverride
    {
        bool CanOverride(Class @class);

        void Override(Class @class);
    }
}
