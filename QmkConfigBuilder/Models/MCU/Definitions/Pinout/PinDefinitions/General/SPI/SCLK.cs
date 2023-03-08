namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class SCLK : SPIFunctionBase
    {
        public SCLK() : base(nameof(SCLK)) { }
        public SCLK(string label) : base(label) { }
    }
}
