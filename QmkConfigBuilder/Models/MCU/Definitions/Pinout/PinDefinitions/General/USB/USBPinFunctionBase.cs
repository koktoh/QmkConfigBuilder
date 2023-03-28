namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.USB
{
    public abstract class USBPinFunctionBase : PinFunctionBase
    {
        public override PinType PinType => PinType.IO;

        public override PinFunctionType PinFunctionType => PinFunctionType.USB;

        public USBPinFunctionBase(string label) : base(label) { }
        public USBPinFunctionBase(string label, string groupingTag) : base(label, groupingTag) { }
        public USBPinFunctionBase(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
