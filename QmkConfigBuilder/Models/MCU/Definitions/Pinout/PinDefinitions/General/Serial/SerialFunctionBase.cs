namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial
{
    public abstract class SerialFunctionBase : PinFunctionBase
    {
        public override PinType PinType => PinType.IO;

        public override PinFunctionType PinFunctionType => PinFunctionType.Serial;

        public SerialFunctionBase(string label) : base(label) { }
        public SerialFunctionBase(string label, string groupingTag) : base(label, groupingTag) { }
        public SerialFunctionBase(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
