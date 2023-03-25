using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions.RgbLighting
{
    public class RgbLightingDefinitions : PinSelectableBase, IRgbLightingDefinitions
    {
        public int Count { get; set; } = 0;
        public bool IsSplit { get; set; } = false;

        public RgbLightingDefinitions() : base(2) { }

        public void SetLeftPin(IPin pin)
        {
            if (this._selectedPins.Any())
            {
                this.SetFirstPin(pin);
                return;
            }

            this.SetPin(0, pin);
        }

        public void SetRightPin(IPin pin)
        {
            if (this._selectedPins.Count < 2)
            {
                this.AddPin(pin);
                return;
            }

            this.SetPin(1, pin);
        }
    }
}
