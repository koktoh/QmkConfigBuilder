namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class SIO2 : SPIFunctionBase
    {
        public SIO2() : this(nameof(SIO2)) { }
        public SIO2(string label) : base(label) { }
        public SIO2(string label, string groupingTag) : base(label, groupingTag) { }
        public SIO2(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
