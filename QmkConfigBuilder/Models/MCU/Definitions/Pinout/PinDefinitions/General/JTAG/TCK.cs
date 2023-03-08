namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.JTAG
{
    public class TCK : JTAGFunctionBase
    {
        public TCK() : this(nameof(TCK)) { }
        public TCK(string label) : base(label) { }
    }
}
