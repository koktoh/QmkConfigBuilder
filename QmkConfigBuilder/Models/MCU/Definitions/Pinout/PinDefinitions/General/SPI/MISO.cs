namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class MISO : SPIFunctionBase
    {
        public MISO() : base(nameof(MISO)) { }
        public MISO(string label) : base(label) { }
        public MISO(string label, string groupingTag) : base(label, groupingTag) { }
        public MISO(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
