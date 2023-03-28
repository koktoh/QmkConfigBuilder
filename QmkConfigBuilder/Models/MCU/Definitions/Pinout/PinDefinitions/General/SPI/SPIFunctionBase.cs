namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public abstract class SPIFunctionBase : PinFunctionBase
    {
        public override PinType PinType => PinType.IO;

        public override PinFunctionType PinFunctionType => PinFunctionType.SPI;

        public SPIFunctionBase(string label) : base(label) { }
        public SPIFunctionBase(string label, string groupingTag) : base(label, groupingTag) { }
        public SPIFunctionBase(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
