namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial
{
    public class TX : SerialFunctionBase
    {
        public TX() : base(nameof(TX)) { }
        public TX(string label) : base(label) { }
        public TX(string label, string groupingTag) : base(label, groupingTag) { }
        public TX(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
