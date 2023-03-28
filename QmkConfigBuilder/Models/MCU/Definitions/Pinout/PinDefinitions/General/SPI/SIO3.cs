namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class SIO3 : SPIFunctionBase
    {
        public SIO3() : this(nameof(SIO3)) { }
        public SIO3(string label) : base(label) { }
        public SIO3(string label, string groupingTag) : base(label, groupingTag) { }
        public SIO3(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
