using QmkConfigBuilder.Models.Json.Serializer;
using QmkConfigBuilder.Models.KeyboardComponents;
using QmkConfigBuilder.Models.KeyboardDefinitions;

namespace QmkConfigBuilder.StateContainer
{
    public partial class KeyboardStateContainer : IKeyboardStateContainer
    {
        private KeyboardDefinitions _keyboardDefinitions = new();
        private readonly IJsonSerializer _serializer;

        public event Action? OnDefinitionsLoaded;
        public event Action? OnKeyboardPropertyChanged;

        public KeyboardDefinitions KeyboardDefinitions => this._keyboardDefinitions;

        public KeyboardStateContainer(IJsonSerializer serializer)
        {
            this._serializer = serializer;
            this._selectedKeyList = new List<IKey>();
        }

        private void NotifyLoadDefinitions()
        {
            this.OnDefinitionsLoaded?.Invoke();
        }

        private void NotifyKeyboardPropertyChanged()
        {
            this.OnKeyboardPropertyChanged?.Invoke();
        }

        public void LoadDefinitions(string json)
        {
            this._keyboardDefinitions = this._serializer.Deserialize<KeyboardDefinitions>(json);

            this.NotifyLoadDefinitions();
        }

        public void UpdateProperty(string propertyName, object value)
        {
            this.NotifyKeyboardPropertyChanged();
        }
    }
}
