namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class SCLK : SPIFunctionBase
    {
        public SCLK() : base(nameof(SCLK)) { }
        public SCLK(string label) : base(label) { }
        public SCLK(string label, string groupingTag) : base(label, groupingTag) { }
        public SCLK(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
