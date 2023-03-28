namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SWD
{
    public class SWCLK : SWDFunctionBase
    {
        public SWCLK() : this(nameof(SWCLK)) { }
        public SWCLK(string label) : base(label) { }
        public SWCLK(string label, string groupingTag) : base(label, groupingTag) { }
        public SWCLK(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
