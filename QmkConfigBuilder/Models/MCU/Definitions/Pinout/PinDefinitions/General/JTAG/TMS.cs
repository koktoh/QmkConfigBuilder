namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.JTAG
{
    public class TMS : JTAGFunctionBase
    {
        public TMS() : this(nameof(TMS)) { }
        public TMS(string label) : base(label) { }
        public TMS(string label, string groupingTag) : base(label, groupingTag) { }
        public TMS(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
