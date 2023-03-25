using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions.Backlight
{
    public interface IBacklightDefinitions : IPinSelectable
    {
        void SetLeftPin(IPin pin);
        void SetRightPin(IPin pin);
    }
}
