namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.JTAG
{
    public class TDI : JTAGFunctionBase
    {
        public TDI() : this(nameof(TDI)) { }
        public TDI(string label) : base(label) { }
        public TDI(string label, string groupingTag) : base(label, groupingTag) { }
        public TDI(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
