using QmkConfigBuilder.Models.MCU.Definitions.Pinout;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.General;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.I2C;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI;

namespace QmkConfigBuilder.Models.MCU
{
    public class RaspberryPiPico : ControllerUnitBase
    {
        #region Pin Definitions

        private readonly IPin _gnd = new GND();
        private readonly IPin _pin1 = new Pin(1, new PinFunction("GP0"))
            .AddPinFunction(new MISO("SPI0 RX", 0))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new TX("UART0 TX", 0));
        private readonly IPin _pin2 = new Pin(2, new PinFunction("GP1"))
            .AddPinFunction(new CS("SPI0 CS", 0))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new RX("UART0 RX", 0));
        private readonly IPin _pin4 = new Pin(4, new PinFunction("GP2"))
            .AddPinFunction(new SCLK("SPI0 SCK", 0))
            .AddPinFunction(new SDA("I2C1 SDA", 1));
        private readonly IPin _pin5 = new Pin(5, new PinFunction("GP3"))
            .AddPinFunction(new MOSI("SPI0 TX", 0))
            .AddPinFunction(new SCL("I2C1 SCL", 1));
        private readonly IPin _pin6 = new Pin(6, new PinFunction("GP4"))
            .AddPinFunction(new MISO("SPI0 RX", 0))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new TX("UART1 TX", 1));
        private readonly IPin _pin7 = new Pin(7, new PinFunction("GP5"))
            .AddPinFunction(new CS("SPI0 CS", 0))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new RX("UART1 RX", 1));
        private readonly IPin _pin9 = new Pin(9, new PinFunction("GP6"))
            .AddPinFunction(new SCLK("SPI0 SCK", 0))
            .AddPinFunction(new SDA("I2C1 SDA", 1));
        private readonly IPin _pin10 = new Pin(10, new PinFunction("GP7"))
            .AddPinFunction(new MOSI("SPI0 TX", 0))
            .AddPinFunction(new SCL("I2C1 SCL", 1));
        private readonly IPin _pin11 = new Pin(11, new PinFunction("GP8"))
            .AddPinFunction(new MISO("SPI1 RX", 1))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new TX("UART1 TX", 1));
        private readonly IPin _pin12 = new Pin(12, new PinFunction("GP9"))
            .AddPinFunction(new CS("SPI1 CS", 1))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new RX("UART1 RX", 1));
        private readonly IPin _pin14 = new Pin(14, new PinFunction("GP10"))
            .AddPinFunction(new SCLK("SPI1 SCK", 1))
            .AddPinFunction(new SDA("I2C1 SDA", 1));
        private readonly IPin _pin15 = new Pin(15, new PinFunction("GP11"))
            .AddPinFunction(new MOSI("SPI1 TX", 1))
            .AddPinFunction(new SCL("I2C1 SCL", 1));
        private readonly IPin _pin16 = new Pin(16, new PinFunction("GP12"))
            .AddPinFunction(new MISO("SPI1 RX", 1))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new TX("UART0 TX", 0));
        private readonly IPin _pin17 = new Pin(17, new PinFunction("GP13"))
            .AddPinFunction(new CS("SPI1 CS", 1))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new RX("UART0 RX", 0));
        private readonly IPin _pin19 = new Pin(19, new PinFunction("GP14"))
            .AddPinFunction(new SCLK("SPI1 SCK", 1))
            .AddPinFunction(new SDA("I2C1 SDA", 1));
        private readonly IPin _pin20 = new Pin(20, new PinFunction("GP15"))
            .AddPinFunction(new MOSI("SPI1 TX", 1))
            .AddPinFunction(new SCL("I2C1 SCL", 1));
        private readonly IPin _pin21 = new Pin(21, new PinFunction("GP16"))
            .AddPinFunction(new MISO("SPI0 RX", 0))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new TX("UART0 TX", 0));
        private readonly IPin _pin22 = new Pin(22, new PinFunction("GP17"))
            .AddPinFunction(new CS("SPI0 CS", 0))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new RX("UART0 RX", 0));
        private readonly IPin _pin24 = new Pin(24, new PinFunction("GP18"))
            .AddPinFunction(new SCLK("SPI0 SCK", 0))
            .AddPinFunction(new SDA("I2C1 SDA", 1));
        private readonly IPin _pin25 = new Pin(25, new PinFunction("GP19"))
            .AddPinFunction(new MOSI("SPI0 TX", 0))
            .AddPinFunction(new SCL("I2C1 SCL", 1));
        private readonly IPin _pin26 = new Pin(26, new PinFunction("GP20"))
            .AddPinFunction(new SDA("I2C0 SDA", 0));
        private readonly IPin _pin27 = new Pin(27, new PinFunction("GP21"))
            .AddPinFunction(new SCL("I2C0 SCL", 0));
        private readonly IPin _pin29 = new Pin(29, new PinFunction("GP22"));
        private readonly IPin _pin30 = new Sys("RUN");
        private readonly IPin _pin31 = new Pin(31, new PinFunction("GP26"))
            .AddPinFunction(new Analog("ADC0"))
            .AddPinFunction(new SDA("I2C1 SDA", 1));
        private readonly IPin _pin32 = new Pin(32, new PinFunction("GP27"))
            .AddPinFunction(new Analog("ADC1"))
            .AddPinFunction(new SCL("I2C1 SCL", 1));
        private readonly IPin _pin34 = new Pin(34, new PinFunction("GP28"))
            .AddPinFunction(new Analog("ADC2"));
        private readonly IPin _pin35 = new Pin(35, new Analog("ADC_VREF"));
        private readonly IPin _pin36 = new Power("3V3(OUT)");
        private readonly IPin _pin37 = new Sys("3V3_EN");
        private readonly IPin _pin39 = new Power("VSYS");
        private readonly IPin _pin40 = new Power("VBUS");

        #endregion

        public override string Name => nameof(RaspberryPiPico);

        public override string ReferenceUrl => "https://www.raspberrypi.com/documentation/microcontrollers/raspberry-pi-pico.html#raspberry-pi-pico-and-pico-h";

        public override IEnumerable<IPin> GetLeftPins()
        {
            yield return this._pin1;
            yield return this._pin2;
            yield return this._gnd;
            yield return this._pin4;
            yield return this._pin5;
            yield return this._pin6;
            yield return this._pin7;
            yield return this._gnd;
            yield return this._pin9;
            yield return this._pin10;
            yield return this._pin11;
            yield return this._pin12;
            yield return this._gnd;
            yield return this._pin14;
            yield return this._pin15;
            yield return this._pin16;
            yield return this._pin17;
            yield return this._gnd;
            yield return this._pin19;
            yield return this._pin20;
        }

        public override IEnumerable<IPin> GetRightPins()
        {
            yield return this._pin21;
            yield return this._pin22;
            yield return this._gnd;
            yield return this._pin24;
            yield return this._pin25;
            yield return this._pin26;
            yield return this._pin27;
            yield return this._gnd;
            yield return this._pin29;
            yield return this._pin30;
            yield return this._pin31;
            yield return this._pin32;
            yield return this._gnd;
            yield return this._pin34;
            yield return this._pin35;
            yield return this._pin36;
            yield return this._pin37;
            yield return this._gnd;
            yield return this._pin39;
            yield return this._pin40;
        }
    }
}
