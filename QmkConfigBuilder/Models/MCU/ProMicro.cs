using QmkConfigBuilder.Models.MCU.Definitions.Pinout;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.General;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.I2C;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI;

namespace QmkConfigBuilder.Models.MCU
{
    public class ProMicro : ControllerUnitBase
    {
        #region Pin Definitions

        private readonly IPin _raw = new Power("RAW");
        private readonly IPin _vcc = new Power("VCC");
        private readonly IPin _gnd = new GND();
        private readonly IPin _rst = new Sys("Reset");
        private readonly IPin _pin1 = new Pin("TX0", new PinFunction("D3"))
            .AddPinFunction(new TX());
        private readonly IPin _pin2 = new Pin("RX1", new PinFunction("D2"))
            .AddPinFunction(new RX());
        private readonly IPin _pin5 = new Pin("2", new PinFunction("D1"))
            .AddPinFunction(new SDA());
        private readonly IPin _pin6 = new Pin("3", new PinFunction("D0"))
            .AddPinFunction(new SCL())
            .AddPinFunction(new PWM());
        private readonly IPin _pin7 = new Pin("4", new PinFunction("D4"))
            .AddPinFunction(new Analog("A6"));
        private readonly IPin _pin8 = new Pin("5", new PinFunction("C6"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin9 = new Pin("6", new PinFunction("D7"))
            .AddPinFunction(new Analog("A7"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin10 = new Pin("7", new PinFunction("E6"));
        private readonly IPin _pin11 = new Pin("8", new PinFunction("B4"))
            .AddPinFunction(new Analog("A8"));
        private readonly IPin _pin12 = new Pin("9", new PinFunction("B5"))
            .AddPinFunction(new Analog("A9"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin13 = new Pin("10", new PinFunction("B6"))
            .AddPinFunction(new Analog("A10"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin14 = new Pin("16", new PinFunction("B2"))
            .AddPinFunction(new MOSI());
        private readonly IPin _pin15 = new Pin("14", new PinFunction("B3"))
            .AddPinFunction(new MISO());
        private readonly IPin _pin16 = new Pin("15", new PinFunction("B1"))
            .AddPinFunction(new SCLK());
        private readonly IPin _pin17 = new Pin("18", new PinFunction("F7"))
            .AddPinFunction(new Analog("A0"));
        private readonly IPin _pin18 = new Pin("19", new PinFunction("F6"))
            .AddPinFunction(new Analog("A1"));
        private readonly IPin _pin19 = new Pin("20", new PinFunction("F5"))
            .AddPinFunction(new Analog("A2"));
        private readonly IPin _pin20 = new Pin("21", new PinFunction("F4"))
            .AddPinFunction(new Analog("A3"));

        #endregion

        public override string Name => nameof(ProMicro);

        public override string ReferenceUrl => "https://github.com/sparkfun/Pro_Micro/blob/main/Documentation/ProMicro16MHzv2.pdf";

        public override IEnumerable<IPin> GetLeftPins()
        {
            yield return this._pin1;
            yield return this._pin2;
            yield return this._gnd;
            yield return this._gnd;
            yield return this._pin5;
            yield return this._pin6;
            yield return this._pin7;
            yield return this._pin8;
            yield return this._pin9;
            yield return this._pin10;
            yield return this._pin11;
            yield return this._pin12;
        }

        public override IEnumerable<IPin> GetRightPins()
        {
            yield return this._pin13;
            yield return this._pin14;
            yield return this._pin15;
            yield return this._pin16;
            yield return this._pin17;
            yield return this._pin18;
            yield return this._pin19;
            yield return this._pin20;
            yield return this._vcc;
            yield return this._rst;
            yield return this._gnd;
            yield return this._raw;
        }

    }
}
