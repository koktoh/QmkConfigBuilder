namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial
{
    public class CTS : SerialFunctionBase
    {
        public CTS() : this(nameof(CTS)) { }
        public CTS(string label) : base(label) { }
    }
}
