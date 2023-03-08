namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.USB
{
    public class DP : USBPinFunctionBase
    {
        public DP() : this("D+") { }
        public DP(string label) : base(label) { }
    }
}
