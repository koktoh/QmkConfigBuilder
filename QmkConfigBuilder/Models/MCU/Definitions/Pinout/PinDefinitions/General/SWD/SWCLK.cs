namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SWD
{
    public class SWCLK : SWDFunctionBase
    {
        public SWCLK() : this(nameof(SWCLK)) { }
        public SWCLK(string label) : base(label) { }
    }
}
