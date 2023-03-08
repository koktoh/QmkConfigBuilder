using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.MCU
{
    public interface IControllerUnit
    {
        string Name { get; }
        string ReferenceUrl { get; }

        IEnumerable<IPin> GetAllPins();
        IEnumerable<IPin> GetTopPins();
        IEnumerable<IPin> GetBottomPins();
        IEnumerable<IPin> GetLeftPins();
        IEnumerable<IPin> GetRightPins();
    }
}
