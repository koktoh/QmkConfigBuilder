using Microsoft.AspNetCore.Components;
using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;
using QmkConfigBuilder.StateContainer;
using Radzen;

namespace QmkConfigBuilder.Shared.MatrixEditor
{
    public partial class MatrixEditorComponent : ComponentBase, IDisposable
    {
        [Inject]
        public IMatrixStateContainer MatrixStateContainer { get; set; } = default!;

        private readonly string _editIcon = "create";
        private readonly string _saveIcon = "done";

        private string _editButtonIcon = string.Empty;
        private ButtonStyle _buttonStyle = ButtonStyle.Primary;

        [Parameter]
        public MatrixType MatrixType { get; set; } = MatrixType.Row;

        [Parameter]
        public bool Disabled { get; set; } = false;

        [Parameter]
        public EventCallback<MatrixDefinitions> DropDownValueChanged { get; set; }

        [Parameter]
        public EventCallback AddButtonClicked { get; set; }

        [Parameter]
        public EventCallback RemoveButtonClicked { get; set; }

        [Parameter]
        public EventCallback EditButtonClicked { get; set; }

        private MatrixDefinitions? SelectedMatrixDefinitions
        {
            get => this.MatrixStateContainer.SelectedMatrix?.MatrixType == this.MatrixType ? this.MatrixStateContainer.SelectedMatrix : null;
            set
            {
                this.MatrixStateContainer.SelectedMatrix = value;

                if (this.DropDownValueChanged.HasDelegate)
                {
                    this.DropDownValueChanged.InvokeAsync(value);
                }
            }
        }

        private IEnumerable<MatrixDefinitions> MatrixDefinitionsList => this.MatrixStateContainer.GetMatrixDefinitions(this.MatrixType);

        private async Task OnClickEditButton()
        {
            if (this.MatrixStateContainer.SelectedMatrix is null)
            {
                return;
            }

            if (this.MatrixType == MatrixType.Row)
            {
                this.MatrixStateContainer.EditingMatrixRow = !this.MatrixStateContainer.EditingMatrixRow;
            }
            else
            {
                this.MatrixStateContainer.EditingMatrixColumn = !this.MatrixStateContainer!.EditingMatrixColumn;
            }

            if (this.MatrixStateContainer.EditingMatrix)
            {
                this._editButtonIcon = this._saveIcon;
            }
            else
            {
                this._editButtonIcon = this._editIcon;
            }

            if (this.EditButtonClicked.HasDelegate)
            {
                await this.EditButtonClicked.InvokeAsync();
            }
        }

        private async Task OnClickAddButton()
        {
            switch (this.MatrixType)
            {
                case MatrixType.Row:
                    this.MatrixStateContainer.AddMatrixRow();
                    break;
                case MatrixType.Column:
                    this.MatrixStateContainer.AddMatrixColumn();
                    break;
                default:
                    break;
            }

            if (this.AddButtonClicked.HasDelegate)
            {
                await this.AddButtonClicked.InvokeAsync();
            }
        }

        private async Task OnClickRemoveButton()
        {
            switch (this.MatrixType)
            {
                case MatrixType.Row:
                    this.MatrixStateContainer.RemoveMatrixRow();
                    break;
                case MatrixType.Column:
                    this.MatrixStateContainer.RemoveMatrixColumn();
                    break;
                default:
                    break;
            }

            this.MatrixStateContainer.SelectedMatrix = null;

            if (this.RemoveButtonClicked.HasDelegate)
            {
                await this.RemoveButtonClicked.InvokeAsync();
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.MatrixStateContainer.OnMatrixEditingStateChanged += this.StateHasChanged;
            this.MatrixStateContainer.OnSelectedMatrixChanged += this.StateHasChanged;
            this.MatrixStateContainer.OnMatrixChanged += this.StateHasChanged;

            this._editButtonIcon = _editIcon;

            if (this.MatrixType == MatrixType.Row)
            {
                this._buttonStyle = ButtonStyle.Success;
            }
            else
            {
                this._buttonStyle = ButtonStyle.Warning;
            }
        }

        public void Dispose()
        {
            this.MatrixStateContainer.OnMatrixEditingStateChanged -= this.StateHasChanged;
            this.MatrixStateContainer.OnSelectedMatrixChanged -= this.StateHasChanged;
            this.MatrixStateContainer.OnMatrixChanged -= this.StateHasChanged;
        }
    }
}
