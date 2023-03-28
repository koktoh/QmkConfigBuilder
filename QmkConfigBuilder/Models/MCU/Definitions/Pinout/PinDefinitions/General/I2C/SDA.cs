namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.I2C
{
    public class SDA : I2CFunctionBase
    {
        public SDA() : base(nameof(SDA)) { }
        public SDA(string label) : base(label) { }
        public SDA(string label, string groupingTag) : base(label, groupingTag) { }
        public SDA(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
