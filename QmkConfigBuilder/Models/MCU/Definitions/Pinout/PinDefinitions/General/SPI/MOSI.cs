namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class MOSI : SPIFunctionBase
    {
        public MOSI() : base(nameof(MOSI)) { }
        public MOSI(string label) : base(label) { }
        public MOSI(string label, string groupingTag) : base(label, groupingTag) { }
        public MOSI(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
