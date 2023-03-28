namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.USB
{
    public class DM : USBPinFunctionBase
    {
        public DM() : this("D-") { }
        public DM(string label) : base(label) { }
        public DM(string label, string groupingTag) : base(label, groupingTag) { }
        public DM(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
