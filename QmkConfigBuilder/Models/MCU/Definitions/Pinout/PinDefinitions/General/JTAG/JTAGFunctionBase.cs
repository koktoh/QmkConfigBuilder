namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.JTAG
{
    public abstract class JTAGFunctionBase : PinFunctionBase
    {
        public override PinType PinType => PinType.IO;

        public override PinFunctionType PinFunctionType => PinFunctionType.JTAG;

        protected JTAGFunctionBase(string label) : base(label) { }
        protected JTAGFunctionBase(string label, string groupingTag) : base(label,groupingTag) { }
        protected JTAGFunctionBase(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
