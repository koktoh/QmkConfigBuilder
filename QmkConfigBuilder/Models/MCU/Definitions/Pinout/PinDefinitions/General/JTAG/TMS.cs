namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.JTAG
{
    public class TMS : JTAGFunctionBase
    {
        public TMS() : this(nameof(TMS)) { }
        public TMS(string label) : base(label) { }
    }
}
