namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.I2C
{
    public class SCL : I2CFunctionBase
    {
        public SCL() : base(nameof(SCL)) { }
        public SCL(string label) : base(label) { }
        public SCL(string label, string groupingTag) : base(label, groupingTag) { }
        public SCL(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
