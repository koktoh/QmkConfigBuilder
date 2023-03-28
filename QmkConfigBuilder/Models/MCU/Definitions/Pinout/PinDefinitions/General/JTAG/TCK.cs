namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.JTAG
{
    public class TCK : JTAGFunctionBase
    {
        public TCK() : this(nameof(TCK)) { }
        public TCK(string label) : base(label) { }
        public TCK(string label, string groupingTag) : base(label, groupingTag) { }
        public TCK(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
