using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;

namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout
{
    public abstract class PinBase : IPin
    {
        protected readonly string _label;
        protected readonly IPinFunction _pinFunction;
        protected IList<IPinFunction> _pins = new List<IPinFunction>();

        public string Label => this._label;
        public IPinFunction MainPinFunction => this._pinFunction;
        public virtual IEnumerable<IPinFunction> AlternatePinFunctions => this.GetAlternatePinfunctions();

        public PinBase(string label, IPinFunction pinFunction)
        {
            this._label = label;
            this._pinFunction = pinFunction;
        }
        public PinBase(int lable, IPinFunction pinFunction) : this(lable.ToString(), pinFunction) { }

        public virtual IEnumerable<IPinFunction> GetAllPinfunctions()
        {
            yield return this._pinFunction;

            foreach (var pin in this.AlternatePinFunctions)
            {
                yield return pin;
            }
        }

        public virtual IEnumerable<IPinFunction> GetAlternatePinfunctions()
        {
            yield break;
        }

        public virtual IPin AddPinFunction(IPinFunction pinFunction)
        {
            this._pins.Add(pinFunction);
            return this;
        }

        public override bool Equals(object? obj)
        {
            return obj is IPin other
                && this.Label == other.Label
                && this.GetAllPinfunctions().SequenceEqual(other.GetAllPinfunctions());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
