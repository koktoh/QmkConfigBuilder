using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;

namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.General
{
    public class Sys : PinBase
    {
        public Sys(string label) : base(label, new PinFunction(label, PinType.SystemControl, PinFunctionType.Digital)) { }

        public override IPin AddPinFunction(IPinFunction pinFunction)
        {
            // do nothing
            return this;
        }
    }
}
