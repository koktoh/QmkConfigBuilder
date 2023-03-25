using QmkConfigBuilder.Models.KeyboardDefinitions;

namespace QmkConfigBuilder.StateContainer
{
    public interface IKeyboardStateContainer : ILayoutStateContainer, IMatrixStateContainer
    {
        KeyboardDefinitions KeyboardDefinitions { get; }

        event Action? OnDefinitionsLoaded;
        event Action? OnKeyboardPropertyChanged;

        void LoadDefinitions(string json);
        void UpdateProperty(string propertyName, object value);
    }
}
