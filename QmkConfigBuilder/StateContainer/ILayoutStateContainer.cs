using QmkConfigBuilder.Models.KeyboardComponents;

namespace QmkConfigBuilder.StateContainer
{
    public interface ILayoutStateContainer : IMatrixStateContainer
    {

        int Index { get; set; }
        IEnumerable<ILayout> Layouts { get; }
        ILayout CurrentLayout { get; }
        ILayout FirstLayout { get; }
        IKey? LastSelectedKey { get; set; }
        IEnumerable<IKey> SelectedKeyList { get; }

        event Action? OnSelectedLayoutChanged;
        event Action? OnSelectedKeyChanged;
        event Action? OnLayoutChanged;

        void AddLayout();
        void AddLayout(ILayout layout);
        void RemoveLayout();
        void RemoveLayout(int index);
        void AddRow();
        void RemoveRow();
        void RemoveRow(int index);
        void AddColumn();
        void RemoveColumn();
        void RemoveColumn(int index);
        void AddKey(IKey key);
        void AddKey(IKey key, int row);
        void RemoveKey();
        void RemoveKey(Guid id);
        void UpdateSelectedKeyProperty(string propertyName, object? value);
    }
}
