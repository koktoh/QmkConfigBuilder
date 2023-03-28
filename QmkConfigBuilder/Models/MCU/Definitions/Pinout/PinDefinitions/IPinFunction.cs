namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions
{
    public interface IPinFunction
    {
        string Label { get; }
        string GroupingTag { get; }
        PinFunctionType PinFunctionType { get; }
        PinType PinType { get; }
    }
}