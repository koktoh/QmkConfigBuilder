namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.JTAG
{
    public class TDO : JTAGFunctionBase
    {
        public TDO() : this(nameof(TDO)) { }
        public TDO(string label) : base(label) { }
    }
}
