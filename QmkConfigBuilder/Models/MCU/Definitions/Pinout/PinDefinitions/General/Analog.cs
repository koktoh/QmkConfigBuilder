namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General
{
    public class Analog : PinFunctionBase
    {
        public override PinType PinType => PinType.IO;

        public override PinFunctionType PinFunctionType => PinFunctionType.Analog;

        public Analog() : this(nameof(Analog)) { }
        public Analog(string label) : base(label) { }
    }
}
