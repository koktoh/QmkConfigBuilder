using System.Collections;

namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public class Row : IRow
    {
        private readonly IDictionary<Guid, IKey> _keys;
        private readonly IDictionary<Guid, IEncoder> _encoders;

        public int Count => this._keys.Count;
        public IEnumerable<IKey> Keys => this._keys.Values;
        public IEnumerable<IKey> KeysOrderByPos => this._keys.Values.OrderBy(x => x.PosX);
        public IEnumerable<IKey> KeysOrderByColumn => this._keys.Values.OrderBy(x => x.Column);
        public IEnumerable<IEncoder> Encoders => this._encoders.Values;

        public IKey this[int index] => this.GetKeyByIndex(index);

        public Row()
        {
            this._keys = new Dictionary<Guid, IKey>();
            this._encoders = new Dictionary<Guid, IEncoder>();
        }

        public Row(IRow row) : this()
        {
            foreach (var key in row.Keys)
            {
                var newKey = new Key(key);
                this._keys.Add(newKey.Id, newKey);
            }
        }

        private IKey GetKeyByIndex(int index)
        {
            return this.Keys.ElementAt(index);
        }

        private void RegisterEncoder(IEncoder encoder)
        {
            if (this._encoders.ContainsKey(encoder.Id))
            {
                return;
            }

            this._encoders.Add(encoder.Id, encoder);
        }

        private void DeleteEncoder(Guid id)
        {
            if (!this._encoders.ContainsKey(id))
            {
                return;
            }

            this._encoders.Remove(id);
        }

        public void AddKey(IKey key)
        {
            if (this.Count == 0)
            {
                this._keys.Add(key.Id, key);
                return;
            }

            var lastKey = this.Keys.Last();

            if (key.Column == 0)
            {
                key.Column = (ushort?)(lastKey.Column + 1);
            }

            if (key.PosX == 0)
            {
                key.PosX = lastKey.PosX + lastKey.Width;
            }

            this._keys.Add(key.Id, key);
        }

        public void AddEncoder(IEncoder encoder)
        {
            this.RegisterEncoder(encoder);
            this.AddKey(encoder);
        }

        public IKey GetKey(Guid id)
        {
            if (this._encoders.TryGetValue(id, out var value))
            {
                return value;
            }

            return this._keys[id];
        }

        public IEncoder? GetEncoder(Guid id)
        {
            if (!this._encoders.ContainsKey(id))
            {
                return null;
            }

            return this._encoders[id];
        }

        public void RemoveKey()
        {
            this.RemoveKey(this._keys.Last().Key);
        }

        public void RemoveKey(Guid id)
        {
            this._keys.Remove(id);
            this.DeleteEncoder(id);
        }

        public void UpdateKey(Guid id, string propertyName, object? value)
        {
            this._keys[id].Update(propertyName, value);

            if (propertyName != nameof(IKey.KeyType) || value is null)
            {
                return;
            }

            if (value is KeyType.Encoder)
            {
                this.RegisterEncoder(new Encoder(this.GetKey(id)));
            }
            else
            {
                this.DeleteEncoder(id);
            }
        }

        public bool ContainsKey(Guid id)
        {
            return this._keys.ContainsKey(id);
        }

        public IEnumerator<IKey> GetEnumerator()
        {
            return this._keys.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Validate(out IEnumerable<IKey> result)
        {
            result = Enumerable.Empty<IKey>();

            var list = new List<IKey>();

            foreach (var key in this._keys.Values)
            {
                if (key.Row is null || key.Column is null)
                {
                    list.Add(key);
                }
            }

            if (!list.Any())
            {
                return true;
            }

            result = list;

            return false;
        }
    }
}
