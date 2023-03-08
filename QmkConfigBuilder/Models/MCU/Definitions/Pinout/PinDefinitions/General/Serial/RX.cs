namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial
{
    public class RX : SerialFunctionBase
    {
        public RX() : base(nameof(RX)) { }
        public RX(string label) : base(label) { }
    }
}
