namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions
{
    public abstract class PinFunctionBase : IPinFunction
    {
        public string Label { get; }
        public string GroupingTag { get; } = string.Empty;
        public abstract PinFunctionType PinFunctionType { get; }

        public abstract PinType PinType { get; }

        public PinFunctionBase(string label)
        {
            this.Label = label;
        }

        public PinFunctionBase(string label, string groupingTag)
        {
            this.Label = label;
            this.GroupingTag = groupingTag;
        }

        public PinFunctionBase(string label, int groupingTag)
        {
            this.Label = label;
            this.GroupingTag = groupingTag.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is IPinFunction other
                && this.Label == other.Label
                && this.GroupingTag == other.GroupingTag
                && this.PinType == other.PinType
                && this.PinFunctionType == other.PinFunctionType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
