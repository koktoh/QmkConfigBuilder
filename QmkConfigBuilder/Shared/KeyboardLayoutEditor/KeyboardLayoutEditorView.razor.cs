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
        public ILayoutStateContainer LayoutStateContainer { get; set; } = default!;

        private bool _matrixVisibility = false;

        private bool GetMatrixVisibility(MatrixDefinitions matrixDefinitions)
        {
            return (this._matrixVisibility || this.LayoutStateContainer.EditingMatrix) && (this.LayoutStateContainer.SelectedMatrix is null || this.LayoutStateContainer.SelectedMatrix == matrixDefinitions);
        }

        private void AddKey(IKey key)
        {
            this.LayoutStateContainer.AddKey(key);
        }

        private void AddIsoEnter()
        {
            this.AddKey(new Key(KeyType.ISOEnter));
        }

        private void AddEncoder(IEncoder encoder)
        {
            this.LayoutStateContainer.AddEncoder(encoder);
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

        private void OnClickAddEncoder(RadzenSplitButtonItem item)
        {
            if (item is null)
            {
                this.AddEncoder(new Encoder());
                return;
            }

            this.AddEncoder(new Encoder(false));
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
