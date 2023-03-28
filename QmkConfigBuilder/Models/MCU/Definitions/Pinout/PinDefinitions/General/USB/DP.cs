namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.USB
{
    public class DP : USBPinFunctionBase
    {
        public DP() : this("D+") { }
        public DP(string label) : base(label) { }
        public DP(string label, string groupingTag) : base(label, groupingTag) { }
        public DP(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
