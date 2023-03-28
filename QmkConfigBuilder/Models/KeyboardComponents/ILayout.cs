using System.Collections;

namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public interface ILayout : IEnumerable<IRow>, IEnumerable
    {
        string Name { get; }
        int Count { get; }
        IEnumerable<IRow> Rows { get; }
        IEnumerable<IKey> AllKeys { get; }
        IEnumerable<IEncoder> AllEncoders { get; }

        int GetRowIndex(IKey? key);
        void AddKey(IKey key);
        void AddKey(IKey key, int row);
        void AddEncoder(IEncoder encoder);
        void AddEncoder(IEncoder encoder, int row);
        IKey GetKey(Guid id);
        IKey GetKey(int row, int col);
        IEncoder? GetEncoder(Guid id);
        void AddRow();
        void AddColumn();
        IEnumerable<IKey> GetPhysicalRow(int index);
        IEnumerable<IKey> GetPhysicalRow(Guid id);
        IEnumerable<IKey> GetPhysicalColumn(int index);
        IEnumerable<IKey> GetPhysicalColumn(Guid id);
        IEnumerable<IKey> GetMatrixRow(uint index);
        IEnumerable<IKey> GetMatrixColumn(uint index);
        void RemoveKey();
        void RemoveKey(Guid id);
        void RemoveRow(int index);
        void RemoveColumn(int index);
        void UpdateKey(Guid id, string propertyName, object? value);
        bool Validate(out IEnumerable<IKey> result);
    }
}
