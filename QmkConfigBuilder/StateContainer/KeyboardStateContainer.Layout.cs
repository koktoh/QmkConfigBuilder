using QmkConfigBuilder.Models.KeyboardComponents;
using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;

namespace QmkConfigBuilder.StateContainer
{
    public partial class KeyboardStateContainer : ILayoutStateContainer
    {

        private readonly IList<IKey> _selectedKeyList;

        private int _index = 0;

        private IKey? _lastSelectedKey;

        public int Index
        {
            get => this._index;
            set
            {
                if (this._index != value)
                {
                    this._lastSelectedKey = null;
                    this._selectedKeyList.Clear();

                    this._index = value;
                    this.NotifySelectedLayoutChanged();
                }
            }
        }

        public IEnumerable<ILayout> Layouts => this.KeyboardDefinitions.Layouts;

        public ILayout CurrentLayout => this.KeyboardDefinitions.Layouts[this._index];

        public ILayout FirstLayout => this.KeyboardDefinitions.Layouts[0];

        public IKey? LastSelectedKey
        {
            get => this._lastSelectedKey;
            set
            {
                if (this._lastSelectedKey != value)
                {
                    this._lastSelectedKey = value;
                    this.NotifySelectedKeyChanged();
                }

                if (value is null || !this.CurrentLayout.AllKeys.Contains(value))
                {
                    return;
                }

                if (this._selectedKeyList.Contains(value))
                {
                    this._selectedKeyList.Remove(value);
                }
                else
                {
                    this._selectedKeyList.Add(value);
                }
            }
        }

        public IEnumerable<IKey> SelectedKeyList
        {
            get
            {
                if (!this.EditingMatrix && this.LastSelectedKey is not null)
                {
                    return new[] { this.LastSelectedKey };
                }

                if (this.SelectedMatrix is null)
                {
                    return Enumerable.Empty<IKey>();
                }

                if (this.SelectedMatrix.MatrixType == MatrixType.Row)
                {
                    return this.CurrentLayout.GetMatrixRow(this.SelectedMatrix.Index);
                }
                else
                {
                    return this.CurrentLayout.GetMatrixColumn(this.SelectedMatrix.Index);
                }
            }
        }

        public event Action? OnSelectedLayoutChanged;
        public event Action? OnSelectedKeyChanged;
        public event Action? OnLayoutChanged;

        private void NotifySelectedLayoutChanged()
        {
            this.OnSelectedLayoutChanged?.Invoke();
        }

        private void NotifySelectedKeyChanged()
        {
            this.OnSelectedKeyChanged?.Invoke();
        }

        private void NotifyLayoutChanged()
        {
            this.OnLayoutChanged?.Invoke();
        }

        public void AddLayout()
        {
            if (!this.KeyboardDefinitions.Layouts.Any())
            {
                this.AddLayout(new Layout());
                return;
            }

            this.AddLayout(new Layout(string.Empty, this.KeyboardDefinitions.Layouts[0]));
        }

        public void AddLayout(ILayout layout)
        {
            this.KeyboardDefinitions.Layouts.Add(layout);
        }

        public void RemoveLayout()
        {
            if (!this.KeyboardDefinitions.Layouts.Any() || this.KeyboardDefinitions.Layouts.Count == 1)
            {
                return;
            }

            this.KeyboardDefinitions.Layouts.RemoveAt(this.KeyboardDefinitions.Layouts.Count - 1);
        }

        public void RemoveLayout(int index)
        {
            if (this.KeyboardDefinitions.Layouts.Any() || this.KeyboardDefinitions.Layouts.Count == 1)
            {
                return;
            }

            this.KeyboardDefinitions.Layouts.RemoveAt(index);
        }

        public void AddRow()
        {
            this.CurrentLayout.AddRow();
            this.AddMatrixRow();
        }

        public void RemoveRow()
        {
            if (this.CurrentLayout.Count == 0)
            {
                return;
            }

            var lastRowIndex = this.CurrentLayout.Rows.Count() - 1;

            this.RemoveRow(lastRowIndex);
        }

        public void RemoveRow(int index)
        {
            this.CurrentLayout.RemoveRow(index);
        }

        public void AddColumn()
        {
            this.CurrentLayout.AddColumn();
            this.AddMatrixColumn();
        }

        public void RemoveColumn()
        {
            if (this.CurrentLayout.Count == 0)
            {
                return;
            }

            var lastColumnIndex = this.CurrentLayout.AllKeys
                .Select(x => x.Column ?? 0)
                .Max();

            this.RemoveColumn(lastColumnIndex);
        }

        public void RemoveColumn(int index)
        {
            this.CurrentLayout.RemoveColumn(index);
        }

        public void AddKey(IKey key)
        {
            this.CurrentLayout.AddKey(key);

            var addedKey = this.CurrentLayout.GetKey(key.Id);

            this.AddMatrixRow(new MatrixDefinitions(MatrixType.Row, addedKey.Row ?? 0));
            this.AddMatrixColumn(new MatrixDefinitions(MatrixType.Column, addedKey.Column ?? 0));
        }

        public void AddKey(IKey key, int row)
        {
            this.CurrentLayout.AddKey(key, row);
        }

        public void RemoveKey()
        {
            this.CurrentLayout.RemoveKey();
            this.NotifyLayoutChanged();
        }

        public void RemoveKey(Guid id)
        {
            this.CurrentLayout.RemoveKey(id);
            this.NotifyLayoutChanged();
        }

        public void UpdateSelectedKeyProperty(string propertyName, object? value)
        {
            if (this._lastSelectedKey is null)
            {
                return;
            }

            this.CurrentLayout.UpdateKey(this._lastSelectedKey.Id, propertyName, value);
            this.NotifyLayoutChanged();
        }
    }
}
