namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General
{
    public class PWM : PinFunctionBase
    {
        public override PinType PinType => PinType.IO;

        public override PinFunctionType PinFunctionType => PinFunctionType.PWM;

        public PWM() : this(nameof(PWM)) { }
        public PWM(string label) : base(label) { }
    }
}
