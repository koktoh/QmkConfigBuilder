using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions
{
    public interface IPinSelectable
    {
        int Capacity { get; }
        bool HasPins { get; }
        IEnumerable<IPin> SelectedPins { get; }

        void SetPin(int index, IPin pin);
        void AddPin(IPin pin);
        void RemovePin();
        void RemovePin(IPin pin);
        bool ContainsPin(IPin pin);
        void Clear();
    }
}
