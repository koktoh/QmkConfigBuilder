using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;

namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout
{
    public interface IPin
    {
        public string Label { get; }
        public IPinFunction MainPinFunction { get; }
        public IEnumerable<IPinFunction> AlternatePinFunctions { get; }

        IEnumerable<IPinFunction> GetAllPinfunctions();
        IEnumerable<IPinFunction> GetAlternatePinfunctions();
        IPin AddPinFunction(IPinFunction pinFunction);
    }
}
