namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.I2C
{
    public class SDA : I2CFunctionBase
    {
        public SDA() : base(nameof(SDA)) { }
        public SDA(string label) : base(label) { }
    }
}
