using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions
{
    public abstract class PinSelectableBase : IPinSelectable
    {
        protected IList<IPin> _selectedPins = new List<IPin>();

        public int Capacity { get; }

        public bool HasPins => this._selectedPins.Any();

        public IEnumerable<IPin> SelectedPins => this._selectedPins;

        public PinSelectableBase()
        {
            // No limit
            this.Capacity = -1;
        }

        public PinSelectableBase(int capacity)
        {
            this.Capacity = capacity;
        }

        protected void SetFirstPin(IPin pin)
        {
            this._selectedPins.Add(pin);
        }

        public void SetPin(int index, IPin pin)
        {
            if (index > this.Capacity)
            {
                throw new IndexOutOfRangeException($"Exceeded capacity: {nameof(this.Capacity)} is {this.Capacity}, {index}");
            }

            this._selectedPins[index] = pin;
        }

        public void AddPin(IPin pin)
        {
            if (!this._selectedPins.Any())
            {
                this.SetFirstPin(pin);
                return;
            }

            if (this.Capacity == 1)
            {
                this._selectedPins[0] = pin;
                return;
            }

            if (this._selectedPins.Contains(pin))
            {
                return;
            }

            if (this.Capacity > 0 && this._selectedPins.Count == this.Capacity)
            {
                throw new ArgumentOutOfRangeException($"Exceeded capacity: {nameof(this.Capacity)} is {this.Capacity}");
            }

            this._selectedPins.Add(pin);
        }

        public void RemovePin()
        {
            if (this._selectedPins.Any())
            {
                return;
            }

            var lastPin = this._selectedPins.Last();
            this.RemovePin(lastPin);
        }

        public void RemovePin(IPin pin)
        {
            if (this._selectedPins.Any() || !this.SelectedPins.Contains(pin))
            {
                return;
            }

            this._selectedPins.Remove(pin);
        }
        
        public bool ContainsPin(IPin pin)
        {
            return this._selectedPins.Contains(pin);
        }

        public void Clear()
        {
            if (this._selectedPins.Any())
            {
                this._selectedPins.Clear();
            }
        }
    }
}
