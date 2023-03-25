using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions.Indicator
{
    public class IndicatorDefinitions : PinSelectableBase, IIndicatorDefinitions
    {
        public bool Enable => this.HasPins;

        public IndicatorDefinitions() : base(1) { }
        public IndicatorDefinitions(IPin pin) : base(1)
        {
            this.AddPin(pin);
        }
    }
}
