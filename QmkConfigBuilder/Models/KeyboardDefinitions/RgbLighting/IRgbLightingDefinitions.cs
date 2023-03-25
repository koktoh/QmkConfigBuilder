using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions.RgbLighting
{
    public interface IRgbLightingDefinitions : IPinSelectable
    {
        int Count { get; set; }
        bool IsSplit { get; set; }

        void SetLeftPin(IPin pin);
        void SetRightPin(IPin pin);
    }
}
