namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SWD
{
    public class SWDIO : SWDFunctionBase
    {
        public SWDIO() : this(nameof(SWDIO)) { }
        public SWDIO(string label) : base(label) { }
        public SWDIO(string label, string groupingTag) : base(label, groupingTag) { }
        public SWDIO(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
