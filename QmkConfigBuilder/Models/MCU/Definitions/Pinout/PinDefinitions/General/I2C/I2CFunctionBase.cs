namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.I2C
{
    public abstract class I2CFunctionBase : PinFunctionBase
    {
        public override PinType PinType => PinType.IO;

        public override PinFunctionType PinFunctionType => PinFunctionType.I2C;

        public I2CFunctionBase(string label) : base(label) { }
        public I2CFunctionBase(string label, string groupingTag) : base(label, groupingTag) { }
        public I2CFunctionBase(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
