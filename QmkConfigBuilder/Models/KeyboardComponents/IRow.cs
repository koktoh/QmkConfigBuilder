using System.Collections;

namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public interface IRow : IEnumerable<IKey>, IEnumerable
    {
        int Count { get; }
        IEnumerable<IKey> Keys { get; }
        IEnumerable<IKey> KeysOrderByPos { get; }
        IEnumerable<IKey> KeysOrderByColumn { get; }
        IEnumerable<IEncoder> Encoders { get; }
        IKey this[int index] { get; }

        void AddKey(IKey key);
        void AddEncoder(IEncoder encoder);
        IKey GetKey(Guid id);
        IEncoder? GetEncoder(Guid id);
        void RemoveKey();
        void RemoveKey(Guid id);
        void UpdateKey(Guid id, string propertyName, object? value);
        bool ContainsKey(Guid id);
        bool Validate(out IEnumerable<IKey> result);
    }
}
