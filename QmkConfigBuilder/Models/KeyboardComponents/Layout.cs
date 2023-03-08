using System.Collections;

namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public class Layout : ILayout
    {
        private readonly IList<IRow> _rows;

        public string Name { get; }
        public int Count => this._rows.Count;
        public IEnumerable<IRow> Rows => this._rows;
        public IEnumerable<IKey> AllKeys => this.GetAllKeys();

        public Layout() : this("BASE") { }

        public Layout(string name)
        {
            this._rows = new List<IRow>();
            this.Name = name;
        }

        public Layout(string name, ILayout layout) : this(name)
        {
            foreach (var row in layout.Rows)
            {
                this._rows.Add(new Row(row));
            }
        }

        public void AddKey(IKey key)
        {
            if (this._rows.Count == 0)
            {
                var row = new Row();
                row.AddKey(key);

                this._rows.Add(row);
                return;
            }

            if (this._rows.Count == 1)
            {
                this._rows[0].AddKey(key);
                return;
            }

            var upperRow = this._rows[this.Count - 2];
            var currentRow = this._rows.Last();

            if (currentRow.Count >= upperRow.Count)
            {
                var lastKey = currentRow.Last();
                key.Row = lastKey.Row;
                key.PosY = lastKey.PosY;
            }
            else
            {
                var upperKey = upperRow[currentRow.Count];
                key.Row = (ushort?)(upperKey.Row + 1);
                key.PosX = upperKey.PosX;
                key.PosY = upperKey.PosY + upperKey.Height;
            }

            this._rows.Last().AddKey(key);
        }

        public void AddKey(IKey key, int row)
        {
            var preKey = this._rows[row].Last();

            key.Row = preKey.Row;
            key.PosY = preKey.PosY;
            this._rows[row].AddKey(key);
        }

        public IKey GetKey(Guid id)
        {
            return this._rows.First(x => x.ContainsKey(id)).GetKey(id);
        }

        public IKey GetKey(int row, int col)
        {
            return this._rows[row][col];
        }

        public void AddRow()
        {
            if (this._rows.Count == 0)
            {
                return;
            }

            var upperRow = this._rows.Last();

            this._rows.Add(new Row());

            for (int i = 0; i < upperRow.Count; i++)
            {
                this.AddKey(new Key());
            }
        }

        public void AddColumn()
        {
            if (this._rows.Count == 0)
            {
                return;
            }

            for (int i = 0; i < this._rows.Count; i++)
            {
                this.AddKey(new Key(), i);
            }
        }

        public IEnumerable<IKey> GetPhysicalRow(int index)
        {
            return this._rows[index];
        }

        public IEnumerable<IKey> GetPhysicalRow(Guid id)
        {
            var row = this._rows.First(x => x.ContainsKey(id));

            return this.GetPhysicalRow(this._rows.IndexOf(row));
        }

        public IEnumerable<IKey> GetPhysicalColumn(int index)
        {
            foreach (var row in this._rows)
            {
                if (index < row.Count)
                {
                    yield return row.KeysOrderByPos.ElementAt(index);
                }
            }
        }

        public IEnumerable<IKey> GetPhysicalColumn(Guid id)
        {
            var index = this._rows
                .First(x => x.ContainsKey(id))
                .KeysOrderByPos
                .Select((x, i) => new { Index = i, Value = x })
                .First(x => x.Value.Id == id)
                .Index;

            return this.GetPhysicalColumn(index);
        }

        public IEnumerable<IKey> GetMatrixRow(uint index)
        {
            return this.GetAllKeys().Where(x => x.Row == index);
        }

        public IEnumerable<IKey> GetMatrixColumn(uint index)
        {
            return this.GetAllKeys().Where(x => x.Column == index);
        }

        public void RemoveColumn(int index)
        {
            for (int i = 0; i < this.Count; i++)
            {
                var row = this._rows[i];
                this._rows[i].RemoveKey(row[index].Id);
            }
        }

        public void RemoveKey()
        {
            this._rows.Last().RemoveKey();
        }

        public void RemoveKey(Guid id)
        {
            if (!this._rows.Any(x => x.ContainsKey(id)))
            {
                return;
            }

            var targetRow = this._rows
                .Select((x, i) => new { Index = i, Value = x })
                .First(x => x.Value.ContainsKey(id));

            this._rows[targetRow.Index].RemoveKey(id);

            if (this._rows[targetRow.Index].Count == 0)
            {
                this.RemoveRow(targetRow.Index);
            }
        }

        public void RemoveRow(int index)
        {
            this._rows.RemoveAt(index);
        }

        public void UpdateKey(Guid id, string propertyName, object? value)
        {
            var targetRow = this._rows
                .Select((x, i) => new { Index = i, Value = x })
                .First(x => x.Value.ContainsKey(id));
            this._rows[targetRow.Index].UpdateKey(id, propertyName, value);
        }

        public bool Validate(out IEnumerable<IKey> result)
        {
            result = Enumerable.Empty<IKey>();

            var list = new List<IKey>();

            var success = true;

            foreach (var row in this._rows)
            {
                if (!row.Validate(out var errors))
                {
                    list.AddRange(errors);
                    success = false;
                }
            }

            if (success)
            {
                return true;
            }

            result = list;

            return false;
        }

        public IEnumerator<IRow> GetEnumerator()
        {
            return this._rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<IKey> GetAllKeys()
        {
            if (this._rows.Count == 0)
            {
                return Enumerable.Empty<IKey>();
            }

            return this._rows.SelectMany(x => x.Keys);
        }
    }
}
