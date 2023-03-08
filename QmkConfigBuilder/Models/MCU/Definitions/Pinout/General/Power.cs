using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;

namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.General
{
    public class Power : PinBase
    {
        public Power(string label) : base(label, new PinFunction(label, PinType.Power, PinFunctionType.Power)) { }

        public override IPin AddPinFunction(IPinFunction pinFunction)
        {
            // do nothing
            return this;
        }
    }
}
