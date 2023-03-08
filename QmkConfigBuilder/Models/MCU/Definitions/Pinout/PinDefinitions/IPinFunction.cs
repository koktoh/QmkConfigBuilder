namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions
{
    public interface IPinFunction
    {
        string Label { get; }
        PinFunctionType PinFunctionType { get; }
        PinType PinType { get; }
    }
}