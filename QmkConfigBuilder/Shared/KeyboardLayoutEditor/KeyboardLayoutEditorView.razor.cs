using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QmkConfigBuilder.Models.KeyboardComponents;
using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;
using QmkConfigBuilder.StateContainer;
using Radzen.Blazor;

namespace QmkConfigBuilder.Shared.KeyboardLayoutEditor
{
    public partial class KeyboardLayoutEditorView : IDisposable
    {
        [Inject]
        public IJSRuntime JS { get; set; } = default!;
        [Inject]
        public ILayoutStateContainer LayoutStateContainer { get; set; } = default!;

        private bool _matrixVisiblity = false;
        
        private void AddKey(IKey key)
        {
            if (this.LayoutStateContainer.LastSelectedKey is null)
            {
                this.LayoutStateContainer.AddKey(key);
                return;
            }

            if (this.LayoutStateContainer.LastSelectedKey.Row is null)
            {
                this.LayoutStateContainer.AddKey(key);
                return;
            }

            var index = (int)this.LayoutStateContainer.LastSelectedKey.Row.Value;

            this.LayoutStateContainer.AddKey(key, index);
            this.LayoutStateContainer.LastSelectedKey = this.LayoutStateContainer.CurrentLayout.GetKey(key.Id);
        }

        private void AddIsoEnter()
        {
            var key = new Key()
            {
                Width = 1.5,
                Height = 2,
                KeyType = KeyType.ISOEnter,
            };

            this.AddKey(key);
        }

        private void OnClickAddKey(RadzenSplitButtonItem item)
        {
            if (item is null)
            {
                this.AddKey(new Key());
                return;
            }

            if (Enum.TryParse<KeyType>(item.Value, out var type))
            {
                switch (type)
                {
                    case KeyType.ISOEnter:
                        this.AddIsoEnter();
                        break;
                    default:
                        break;
                }
            }
        }

        private void OnClickAddRow()
        {
            this.LayoutStateContainer.AddRow();
        }

        private void OnClickAddColumn()
        {
            this.LayoutStateContainer.AddColumn();
        }

        private void OnClickDeleteKey()
        {
            if (this.LayoutStateContainer.LastSelectedKey is null)
            {
                return;
            }

            this.LayoutStateContainer.RemoveKey(this.LayoutStateContainer.LastSelectedKey.Id);
            this.LayoutStateContainer.LastSelectedKey = null;
        }

        private void OnSelectedKeyChanged(IKey key)
        {
            this.LayoutStateContainer.LastSelectedKey = key;

            if (this.LayoutStateContainer.SelectedMatrix is null)
            {
                return;
            }

            if (!this.LayoutStateContainer.SelectedKeyList.Any())
            {
                return;
            }

            var targetProperty = this.LayoutStateContainer.SelectedMatrix.MatrixType == MatrixType.Row ? nameof(IKey.Row) : nameof(IKey.Column);

            if (this.LayoutStateContainer.SelectedKeyList.Contains(key))
            {
                this.LayoutStateContainer.UpdateSelectedKeyProperty(targetProperty, null);
            }
            else
            {
                this.LayoutStateContainer.UpdateSelectedKeyProperty(targetProperty, this.LayoutStateContainer.SelectedMatrix.Index);
            }
        }

        private async Task OnVisiblityChanged(bool visible)
        {
            var utility = new JSUtility(this.JS);

            this._matrixVisiblity = visible;

            if (this._matrixVisiblity)
            {
                await utility.ShowAsync(".matrix-canvas");
            }
            else
            {
                await utility.HideAsync(".matrix-canvas");
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.LayoutStateContainer.OnMatrixEditingStateChanged += this.StateHasChanged;
            this.LayoutStateContainer.OnSelectedMatrixChanged += this.StateHasChanged;

            this.LayoutStateContainer.OnLayoutChanged += this.StateHasChanged;
            this.LayoutStateContainer.OnSelectedLayoutChanged += this.StateHasChanged;
            this.LayoutStateContainer.OnSelectedKeyChanged += this.StateHasChanged;
        }

        public void Dispose()
        {
            this.LayoutStateContainer.OnMatrixEditingStateChanged -= this.StateHasChanged;
            this.LayoutStateContainer.OnSelectedMatrixChanged -= this.StateHasChanged;

            this.LayoutStateContainer.OnLayoutChanged -= this.StateHasChanged;
            this.LayoutStateContainer.OnSelectedLayoutChanged -= this.StateHasChanged;
            this.LayoutStateContainer.OnSelectedKeyChanged -= this.StateHasChanged;
        }
    }
}
