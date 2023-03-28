﻿namespace QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI
{
    public class SIO1 : SPIFunctionBase
    {
        public SIO1() : this(nameof(SIO1)) { }
        public SIO1(string label) : base(label) { }
        public SIO1(string label, string groupingTag) : base(label, groupingTag) { }
        public SIO1(string label, int groupingTag) : base(label, groupingTag) { }
    }
}
