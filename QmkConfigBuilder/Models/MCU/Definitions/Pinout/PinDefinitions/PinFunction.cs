namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions
{
    public class PinFunction : PinFunctionBase
    {
        public override PinType PinType { get; }
        public override PinFunctionType PinFunctionType { get; }

        public PinFunction(string label) : base(label)
        {
            this.PinType = PinType.IO;
            this.PinFunctionType = PinFunctionType.Digital;
        }

        public PinFunction(string label, string groupingTag) : base(label, groupingTag)
        {
            this.PinType = PinType.IO;
            this.PinFunctionType = PinFunctionType.Digital;
        }


        public PinFunction(string label, int groupingTag) : base(label, groupingTag)
        {
            this.PinType = PinType.IO;
            this.PinFunctionType = PinFunctionType.Digital;
        }

        public PinFunction(string label, PinType pinType, PinFunctionType pinFunction) : base(label)
        {
            this.PinType = pinType;
            this.PinFunctionType = pinFunction;
        }

        public PinFunction(string label, string groupingTag, PinType pinType, PinFunctionType pinFunction) : base(label, groupingTag)
        {
            this.PinType = pinType;
            this.PinFunctionType = pinFunction;
        }

        public PinFunction(string label, int groupingTag, PinType pinType, PinFunctionType pinFunction) : base(label, groupingTag)
        {
            this.PinType = pinType;
            this.PinFunctionType = pinFunction;
        }
    }
}
