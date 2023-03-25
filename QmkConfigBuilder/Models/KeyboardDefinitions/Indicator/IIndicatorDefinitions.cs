namespace QmkConfigBuilder.Models.KeyboardDefinitions.Indicator
{
    public interface IIndicatorDefinitions : IPinSelectable
    {
        bool Enable { get; }
    }
}
