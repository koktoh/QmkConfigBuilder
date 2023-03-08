namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions
{
    public abstract class PinFunctionBase : IPinFunction
    {
        protected readonly string _label = string.Empty;

        public string Label => this._label;

        public abstract PinFunctionType PinFunctionType { get; }

        public abstract PinType PinType { get; }

        public PinFunctionBase(string label)
        {
            this._label = label;
        }

        public override bool Equals(object? obj)
        {
            return obj is IPinFunction other
                && this.Label == other.Label
                && this.PinType == other.PinType
                && this.PinFunctionType == other.PinFunctionType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
