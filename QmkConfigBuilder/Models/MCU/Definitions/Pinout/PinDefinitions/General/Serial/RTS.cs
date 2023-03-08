namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial
{
    public class RTS : SerialFunctionBase
    {
        public RTS() : this(nameof(RTS)) { }
        public RTS(string label) : base(label) { }
    }
}
