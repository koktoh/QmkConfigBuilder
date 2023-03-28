namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public interface IEncoder : IKey
    {
        bool HasSwitch { get; }
    }
}
