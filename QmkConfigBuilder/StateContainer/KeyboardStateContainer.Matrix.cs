using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;

namespace QmkConfigBuilder.StateContainer
{
    public partial class KeyboardStateContainer : IMatrixStateContainer
    {
        private bool _editingMatrixRow = false;
        private bool _editingMatrixColumn = false;

        private MatrixDefinitions? _selectedMatrix;

        public bool EditingMatrixRow
        {
            get => this._editingMatrixRow;
            set
            {
                this._editingMatrixRow = value;

                if (this._editingMatrixColumn)
                {
                    this._editingMatrixColumn = false;
                }

                this.NotifyMatrixEditingStateChanged();
            }
        }

        public bool EditingMatrixColumn
        {
            get => this._editingMatrixColumn;
            set
            {
                this._editingMatrixColumn = value;

                if (this._editingMatrixRow)
                {
                    this._editingMatrixRow = false;
                }

                this.NotifyMatrixEditingStateChanged();
            }
        }

        public bool EditingMatrix => this.EditingMatrixRow || this.EditingMatrixColumn;

        public MatrixDefinitions? SelectedMatrix
        {
            get => this._selectedMatrix;
            set
            {
                if (this._selectedMatrix != value)
                {
                    this._selectedMatrix = value;
                    this.NotifySelectedMatrixChanged();
                }
            }
        }

        public event Action? OnMatrixEditingStateChanged;
        public event Action? OnSelectedMatrixChanged;
        public event Action? OnMatrixChanged;

        private void NotifyMatrixEditingStateChanged()
        {
            this.OnMatrixEditingStateChanged?.Invoke();
        }

        private void NotifySelectedMatrixChanged()
        {
            this.OnSelectedMatrixChanged?.Invoke();
        }

        public void NotifyMatrixChanged()
        {
            this.OnMatrixChanged?.Invoke();
        }


        public IEnumerable<MatrixDefinitions> GetMatrixDefinitions(MatrixType matrixType)
        {
            switch (matrixType)
            {
                case MatrixType.Row:
                    return this.KeyboardDefinitions.RowMatrixDefinitions;
                case MatrixType.Column:
                    return this.KeyboardDefinitions.ColMatrixDefinitions;
                default:
                    return Enumerable.Empty<MatrixDefinitions>();
            }
        }

        public void AddMatrixRow()
        {
            MatrixDefinitions newDef;

            if (!this.KeyboardDefinitions.RowMatrixDefinitions.Any())
            {
                newDef = new MatrixDefinitions(MatrixType.Row, 0);
            }
            else
            {
                var lastDef = this.KeyboardDefinitions.RowMatrixDefinitions.Last();
                var index = (ushort)(lastDef.Index + 1);
                newDef = new MatrixDefinitions(MatrixType.Row, index);
            }

            this.AddMatrixRow(newDef);
        }

        public void AddMatrixRow(MatrixDefinitions matrixDefinitions)
        {
            if (this.KeyboardDefinitions.RowMatrixDefinitions.Contains(matrixDefinitions))
            {
                return;
            }

            this.KeyboardDefinitions.RowMatrixDefinitions.AddMatrix(matrixDefinitions);
            this.NotifyMatrixChanged();
        }

        public void AddMatrixColumn()
        {
            MatrixDefinitions newDef;

            if (!this.KeyboardDefinitions.ColMatrixDefinitions.Any())
            {
                newDef = new MatrixDefinitions(MatrixType.Column, 0);
            }
            else
            {
                var lastDef = this.KeyboardDefinitions.ColMatrixDefinitions.Last();
                var index = (ushort)(lastDef.Index + 1);
                newDef = new MatrixDefinitions(MatrixType.Column, index);
            }

            this.AddMatrixColumn(newDef);
        }

        public void AddMatrixColumn(MatrixDefinitions matrixDefinitions)
        {
            if (this.KeyboardDefinitions.ColMatrixDefinitions.Contains(matrixDefinitions))
            {
                return;
            }

            this.KeyboardDefinitions.ColMatrixDefinitions.AddMatrix(matrixDefinitions);
            this.NotifyMatrixChanged();
        }

        public void RemoveMatrixRow()
        {
            if (!this.KeyboardDefinitions.RowMatrixDefinitions.Any())
            {
                return;
            }

            var lastDef = this.KeyboardDefinitions.RowMatrixDefinitions.OrderBy(x => x.Index).Last();

            this.RemoveMatrixRow(lastDef);
        }

        public void RemoveMatrixRow(MatrixDefinitions matrixDefinitions)
        {
            if (!this.KeyboardDefinitions.RowMatrixDefinitions.Contains(matrixDefinitions))
            {
                return;
            }

            this.KeyboardDefinitions.RowMatrixDefinitions.RemoveMatrix(matrixDefinitions);
            this.NotifyMatrixChanged();
        }

        public void RemoveMatrixColumn()
        {
            if (!this.KeyboardDefinitions.ColMatrixDefinitions.Any())
            {
                return;
            }

            var lastDef = this.KeyboardDefinitions.ColMatrixDefinitions.OrderBy(x => x.Index).Last();

            this.RemoveMatrixColumn(lastDef);
        }

        public void RemoveMatrixColumn(MatrixDefinitions matrixDefinitions)
        {
            if (!this.KeyboardDefinitions.ColMatrixDefinitions.Contains(matrixDefinitions))
            {
                return;
            }

            this.KeyboardDefinitions.ColMatrixDefinitions.RemoveMatrix(matrixDefinitions);
            this.NotifyMatrixChanged();
        }
    }
}
