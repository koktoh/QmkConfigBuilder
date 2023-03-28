namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class SIO0 : SPIFunctionBase
    {
        public SIO0() : this(nameof(SIO0)) { }
        public SIO0(string label) : base(label) { }
        public SIO0(string label, string groupingTag) : base(label, groupingTag) { }
        public SIO0(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
