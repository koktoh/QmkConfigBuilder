using QmkConfigBuilder.Models.MCU.Definitions.Pinout;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.General;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.I2C;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.USB;

namespace QmkConfigBuilder.Models.MCU
{
    public class ATmega32U4 : ControllerUnitBase
    {
        #region Pin Definitions

        private readonly IPin _vcc = new Power("VCC");
        private readonly IPin _avcc = new Power("AVCC");
        private readonly IPin _gnd = new GND();
        private readonly IPin _uvcc = new Power("UVCC");
        private readonly IPin _ugnd = new GND("UGND");
        private readonly IPin _ucap = new Power("UCAP");
        private readonly IPin _vbus = new Power("VBUS");
        private readonly IPin _reset = new Sys("Reset");
        private readonly IPin _xtal1 = new Sys("XTAL1");
        private readonly IPin _xtal2 = new Sys("XTAL2");

        private readonly IPin _aref = new Pin(42, new Analog("AREF"));
        private readonly IPin _pin1 = new Pin(1, new PinFunction("PE6"));
        private readonly IPin _pin3 = new Pin(3, new DP());
        private readonly IPin _pin4 = new Pin(4, new DM());
        private readonly IPin _pin8 = new Pin(8, new PinFunction("PB0"))
            .AddPinFunction(new CS("SS"));
        private readonly IPin _pin9 = new Pin(9, new PinFunction("PB1"))
            .AddPinFunction(new SCLK("SCK"));
        private readonly IPin _pin10 = new Pin(10, new PinFunction("PB2"))
            .AddPinFunction(new MOSI());
        private readonly IPin _pin11 = new Pin(11, new PinFunction("PB3"))
            .AddPinFunction(new MISO());
        private readonly IPin _pin12 = new Pin(12, new PinFunction("PB7"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin18 = new Pin(18, new PinFunction("PD0"))
            .AddPinFunction(new SCL());
        private readonly IPin _pin19 = new Pin(19, new PinFunction("PD1"))
            .AddPinFunction(new SDA());
        private readonly IPin _pin20 = new Pin(20, new PinFunction("PD2"))
            .AddPinFunction(new RX("RXD1"));
        private readonly IPin _pin21 = new Pin(21, new PinFunction("PD3"))
            .AddPinFunction(new TX("TXD1"));
        private readonly IPin _pin22 = new Pin(22, new PinFunction("PD5"));
        private readonly IPin _pin25 = new Pin(25, new PinFunction("PD4"))
            .AddPinFunction(new Analog("ADC8"));
        private readonly IPin _pin26 = new Pin(26, new PinFunction("PD6"))
            .AddPinFunction(new Analog("ADC9"));
        private readonly IPin _pin27 = new Pin(27, new PinFunction("PD7"))
            .AddPinFunction(new Analog("ADC10"));
        private readonly IPin _pin28 = new Pin(28, new PinFunction("PB4"))
            .AddPinFunction(new Analog("ADC11"));
        private readonly IPin _pin29 = new Pin(29, new PinFunction("PB5"))
            .AddPinFunction(new Analog("ADC12"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin30 = new Pin(30, new PinFunction("PB6"))
            .AddPinFunction(new Analog("ADC13"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin31 = new Pin(31, new PinFunction("PC6"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin32 = new Pin(32, new PinFunction("PC7"))
            .AddPinFunction(new PWM());
        private readonly IPin _pin33 = new Pin(33, new PinFunction("PE2"));
        private readonly IPin _pin36 = new Pin(36, new PinFunction("PF7"))
            .AddPinFunction(new Analog("ADC7"));
        private readonly IPin _pin37 = new Pin(37, new PinFunction("PF6"))
            .AddPinFunction(new Analog("ADC6"));
        private readonly IPin _pin38 = new Pin(38, new PinFunction("PF5"))
            .AddPinFunction(new Analog("ADC5"));
        private readonly IPin _pin39 = new Pin(39, new PinFunction("PF4"))
            .AddPinFunction(new Analog("ADC4"));
        private readonly IPin _pin40 = new Pin(40, new PinFunction("PF1"))
            .AddPinFunction(new Analog("ADC1"));
        private readonly IPin _pin41 = new Pin(41, new PinFunction("PF0"))
            .AddPinFunction(new Analog("ADC0"));

        #endregion

        public override string Name => nameof(ATmega32U4);

        public override string ReferenceUrl => "https://ww1.microchip.com/downloads/en/devicedoc/atmel-7766-8-bit-avr-atmega16u4-32u4_datasheet.pdf";

        public override IEnumerable<IPin> GetLeftPins()
        {
            yield return this._pin1;
            yield return this._uvcc;
            yield return this._pin3;
            yield return this._pin4;
            yield return this._ugnd;
            yield return this._ucap;
            yield return this._vbus;
            yield return this._pin8;
            yield return this._pin9;
            yield return this._pin10;
            yield return this._pin11;
        }

        public override IEnumerable<IPin> GetBottomPins()
        {
            yield return this._pin12;
            yield return this._reset;
            yield return this._vcc;
            yield return this._gnd;
            yield return this._xtal2;
            yield return this._xtal1;
            yield return this._pin18;
            yield return this._pin19;
            yield return this._pin20;
            yield return this._pin21;
            yield return this._pin22;
        }

        public override IEnumerable<IPin> GetRightPins()
        {
            yield return this._gnd;
            yield return this._avcc;
            yield return this._pin25;
            yield return this._pin26;
            yield return this._pin27;
            yield return this._pin28;
            yield return this._pin29;
            yield return this._pin30;
            yield return this._pin31;
            yield return this._pin32;
            yield return this._pin33;
        }

        public override IEnumerable<IPin> GetTopPins()
        {
            yield return this._vcc;
            yield return this._gnd;
            yield return this._pin36;
            yield return this._pin37;
            yield return this._pin38;
            yield return this._pin39;
            yield return this._pin40;
            yield return this._pin41;
            yield return this._aref;
            yield return this._gnd;
            yield return this._avcc;
        }
    }
}
