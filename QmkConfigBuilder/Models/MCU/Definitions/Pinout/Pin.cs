using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;

namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout
{
    public class Pin : PinBase
    {
        public Pin(string label, IPinFunction mainPinFunction) : base(label, mainPinFunction) { }
        public Pin(int label, IPinFunction mainPinFunction):base(label, mainPinFunction) { }

        public override IEnumerable<IPinFunction> GetAlternatePinfunctions()
        {
            return this._pins;
        }
    }
}
