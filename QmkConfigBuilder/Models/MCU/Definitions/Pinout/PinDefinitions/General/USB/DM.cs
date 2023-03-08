namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.USB
{
    public class DM : USBPinFunctionBase
    {
        public DM() : this("D-") { }
        public DM(string label) : base(label) { }
    }
}
