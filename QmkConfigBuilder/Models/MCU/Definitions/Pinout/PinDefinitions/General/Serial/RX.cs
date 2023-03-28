namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial
{
    public class RX : SerialFunctionBase
    {
        public RX() : base(nameof(RX)) { }
        public RX(string label) : base(label) { }
        public RX(string label, string groupingTag) : base(label, groupingTag) { }
        public RX(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
