namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class CS : SPIFunctionBase
    {
        public CS() : base(nameof(CS)) { }
        public CS(string label) : base(label) { }
        public CS(string label, string groupingTag) : base(label, groupingTag) { }
        public CS(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
