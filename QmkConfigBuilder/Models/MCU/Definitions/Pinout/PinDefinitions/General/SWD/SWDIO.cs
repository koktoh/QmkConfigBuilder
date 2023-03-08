namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SWD
{
    public class SWDIO : SWDFunctionBase
    {
        public SWDIO() : this(nameof(SWDIO)) { }
        public SWDIO(string label) : base(label) { }
    }
}
