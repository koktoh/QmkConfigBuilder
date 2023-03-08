using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;

namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.General
{
    public class GND : PinBase
    {
        public GND() : this("GND") { }
        public GND(string label) : base(label, new PinFunction(label, PinType.GND, PinFunctionType.GND)) { }

        public override IPin AddPinFunction(IPinFunction pinFunction)
        {
            // do nothing
            return this;
        }
    }
}
