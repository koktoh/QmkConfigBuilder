namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.JTAG
{
    public class TRST : JTAGFunctionBase
    {
        public TRST() : this(nameof(TRST)) { }
        public TRST(string label) : base(label) { }
    }
}
