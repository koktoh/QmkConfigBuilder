namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SWD
{
    public abstract class SWDFunctionBase : PinFunctionBase
    {
        public override PinType PinType => PinType.IO;

        public override PinFunctionType PinFunctionType => PinFunctionType.SWD;

        public SWDFunctionBase(string label) : base(label) { }
        public SWDFunctionBase(string label, string groupingTag) : base(label, groupingTag) { }
        public SWDFunctionBase(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
