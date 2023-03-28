using QmkConfigBuilder.Models.MCU.Definitions.Pinout;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.General;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.I2C;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.Serial;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SPI;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.SWD;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions.General.USB;
using Radzen.Blazor.Rendering;

namespace QmkConfigBuilder.Models.MCU
{
    public class RP2040 : ControllerUnitBase
    {
        #region Pin Definitions

        private readonly IPin _iovdd = new Power("IOVDD");
        private readonly IPin _dvdd = new Power("DVDD");
        private readonly IPin _testen = new Sys("TESTEN");
        private readonly IPin _xin = new Sys("XIN");
        private readonly IPin _xout = new Sys("XOUT");
        private readonly IPin _run = new Sys("RUN");
        private readonly IPin _adc_avdd = new Power("ADC_AVDD");
        private readonly IPin _usb_vdd = new Power("USB_VDD");
        private readonly IPin _qspi_sd0 = new Pin(53, new SIO0("QSPI_SD0"));
        private readonly IPin _qspi_sd1 = new Pin(55, new SIO1("QSPI_SD1"));
        private readonly IPin _qspi_sd2 = new Pin(54, new SIO2("QSPI_SD2"));
        private readonly IPin _qspi_sd3 = new Pin(51, new SIO3("QSPI_SD3"));
        private readonly IPin _qspi_sclk = new Pin(52, new SCLK("QSPI_SCLK"));
        private readonly IPin _qspi_ss_n = new Pin(56, new CS("QSPI_SS_N"));
        private readonly IPin _vreg_vin = new Power("VREG_VIN");
        private readonly IPin _vreg_vout = new Power("VREG_VOUT");
        private readonly IPin _swclk = new Pin(24, new SWCLK());
        private readonly IPin _swdio = new Pin(25, new SWDIO());
        private readonly IPin _usb_dm = new Pin(46, new DM("USB_DM"));
        private readonly IPin _usb_dp = new Pin(47, new DP("USB_DP"));

        private readonly IPin _pin2 = new Pin(2, new PinFunction("GP0"))
            .AddPinFunction(new MISO("SPI0 RX", 0))
            .AddPinFunction(new TX("UART0 TX", 0))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin3 = new Pin(3, new PinFunction("GP1"))
            .AddPinFunction(new CS("SPI0 CSn", 0))
            .AddPinFunction(new RX("UART0 RX", 0))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin4 = new Pin(4, new PinFunction("GP2"))
            .AddPinFunction(new SCLK("SPI0 SCK", 0))
            .AddPinFunction(new CTS("UART0 CTS", 0))
            .AddPinFunction(new SDA("I2C1 SDA", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin5 = new Pin(5, new PinFunction("GP3"))
            .AddPinFunction(new MOSI("SPI0 TX", 0))
            .AddPinFunction(new RTS("UART0 RTS", 0))
            .AddPinFunction(new SCL("I2C1 SCL", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin6 = new Pin(6, new PinFunction("GP4"))
            .AddPinFunction(new MISO("SPI0 RX", 0))
            .AddPinFunction(new TX("UART1 TX", 1))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin7 = new Pin(7, new PinFunction("GP5"))
            .AddPinFunction(new CS("SPI0 CSn", 0))
            .AddPinFunction(new RX("UART1 RX", 1))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin8 = new Pin(8, new PinFunction("GP6"))
            .AddPinFunction(new SCLK("SPI0 SCK", 0))
            .AddPinFunction(new CTS("UART1 CTS", 1))
            .AddPinFunction(new SDA("I2C1 SDA", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin9 = new Pin(9, new PinFunction("GP7"))
            .AddPinFunction(new MOSI("SPI0 TX", 0))
            .AddPinFunction(new RTS("UART1 RTS", 1))
            .AddPinFunction(new SCL("I2C1 SCL", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin11 = new Pin(11, new PinFunction("GP8"))
            .AddPinFunction(new MISO("SPI1 RX", 1))
            .AddPinFunction(new TX("UART1 TX", 1))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin12 = new Pin(12, new PinFunction("GP9"))
            .AddPinFunction(new CS("SPI1 CSn", 1))
            .AddPinFunction(new RX("UART1 RX", 1))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin13 = new Pin(13, new PinFunction("GP10"))
            .AddPinFunction(new SCLK("SPI1 SCK", 1))
            .AddPinFunction(new CTS("UART1 CTS", 1))
            .AddPinFunction(new SDA("I2C1 SDA", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin14 = new Pin(14, new PinFunction("GP11"))
            .AddPinFunction(new MOSI("SPI1 TX", 1))
            .AddPinFunction(new RTS("UART1 RTS", 1))
            .AddPinFunction(new SCL("I2C1 SCL", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin15 = new Pin(15, new PinFunction("GP12"))
            .AddPinFunction(new MISO("SPI1 RX", 1))
            .AddPinFunction(new TX("UART0 TX", 0))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin16 = new Pin(16, new PinFunction("GP13"))
            .AddPinFunction(new CS("SPI1 CSn", 1))
            .AddPinFunction(new RX("UART0 RX", 0))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin17 = new Pin(17, new PinFunction("GP14"))
            .AddPinFunction(new SCLK("SPI1 SCK", 1))
            .AddPinFunction(new CTS("UART0 CTS", 0))
            .AddPinFunction(new SDA("I2C1 SDA", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin18 = new Pin(18, new PinFunction("GP15"))
            .AddPinFunction(new MOSI("SPI1 TX", 1))
            .AddPinFunction(new RTS("UART0 RTS", 0))
            .AddPinFunction(new SCL("I2C1 SCL", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin27 = new Pin(27, new PinFunction("GP16"))
            .AddPinFunction(new MISO("SPI0 RX", 0))
            .AddPinFunction(new TX("UART0 TX", 0))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin28 = new Pin(28, new PinFunction("GP17"))
            .AddPinFunction(new CS("SPI0 CSn", 0))
            .AddPinFunction(new RX("UART0 RX", 0))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin29 = new Pin(29, new PinFunction("GP18"))
            .AddPinFunction(new SCLK("SPI0 SCK", 0))
            .AddPinFunction(new CTS("UART0 CTS", 0))
            .AddPinFunction(new SDA("I2C1 SDA", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin30 = new Pin(30, new PinFunction("GP19"))
            .AddPinFunction(new MOSI("SPI0 TX", 0))
            .AddPinFunction(new RTS("UART0 RTS", 0))
            .AddPinFunction(new SCL("I2C1 SCL", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin31 = new Pin(31, new PinFunction("GP20"))
            .AddPinFunction(new MISO("SPI0 RX", 0))
            .AddPinFunction(new TX("UART1 TX", 1))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin32 = new Pin(32, new PinFunction("GP21"))
            .AddPinFunction(new CS("SPI0 CSn", 0))
            .AddPinFunction(new RX("UART1 RX", 1))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin34 = new Pin(34, new PinFunction("GP22"))
            .AddPinFunction(new SCLK("SPI0 SCK", 0))
            .AddPinFunction(new CTS("UART1 CTS", 1))
            .AddPinFunction(new SDA("I2C1 SDA", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin35 = new Pin(35, new PinFunction("GP23"))
            .AddPinFunction(new MOSI("SPI0 TX", 0))
            .AddPinFunction(new RTS("UART1 RTS", 1))
            .AddPinFunction(new SCL("I2C1 SCL", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin36 = new Pin(36, new PinFunction("GP24"))
            .AddPinFunction(new MISO("SPI1 RX", 1))
            .AddPinFunction(new TX("UART1 TX", 1))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin37 = new Pin(37, new PinFunction("GP25"))
            .AddPinFunction(new CS("SPI1 CSn", 1))
            .AddPinFunction(new RX("UART1 RX", 1))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin38 = new Pin(38, new PinFunction("GP26"))
            .AddPinFunction(new Analog("ADC0"))
            .AddPinFunction(new SCLK("SPI1 SCK", 1))
            .AddPinFunction(new CTS("UART1 CTS", 1))
            .AddPinFunction(new SDA("I2C1 SDA", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin39 = new Pin(39, new PinFunction("GP27"))
            .AddPinFunction(new Analog("ADC1"))
            .AddPinFunction(new MOSI("SPI1 TX", 1))
            .AddPinFunction(new RTS("UART1 RTS", 1))
            .AddPinFunction(new SCL("I2C1 SCL", 1))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin40 = new Pin(40, new PinFunction("GP28"))
            .AddPinFunction(new Analog("ADC2"))
            .AddPinFunction(new MISO("SPI1 RX", 1))
            .AddPinFunction(new TX("UART0 TX", 0))
            .AddPinFunction(new SDA("I2C0 SDA", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());
        private readonly IPin _pin41 = new Pin(41, new PinFunction("GP29"))
            .AddPinFunction(new Analog("ADC3"))
            .AddPinFunction(new CS("SPI1 CSn", 1))
            .AddPinFunction(new RX("UART0 RX", 0))
            .AddPinFunction(new SCL("I2C0 SCL", 0))
            .AddPinFunction(new PinFunction("SIO"))
            .AddPinFunction(new PinFunction("PIO0", 0))
            .AddPinFunction(new PinFunction("PIO1", 1))
            .AddPinFunction(new PWM());

        #endregion

        public override string Name => nameof(RP2040);

        public override string ReferenceUrl => "https://datasheets.raspberrypi.com/rp2040/rp2040-datasheet.pdf";

        public override IEnumerable<IPin> GetLeftPins()
        {
            yield return this._iovdd;
            yield return this._pin2;
            yield return this._pin3;
            yield return this._pin4;
            yield return this._pin5;
            yield return this._pin6;
            yield return this._pin7;
            yield return this._pin8;
            yield return this._pin9;
            yield return this._iovdd;
            yield return this._pin11;
            yield return this._pin12;
            yield return this._pin13;
            yield return this._pin14;
        }

        public override IEnumerable<IPin> GetBottomPins()
        {
            yield return this._pin15;
            yield return this._pin16;
            yield return this._pin17;
            yield return this._pin18;
            yield return this._testen;
            yield return this._xin;
            yield return this._xout;
            yield return this._iovdd;
            yield return this._dvdd;
            yield return this._swclk;
            yield return this._swdio;
            yield return this._run;
            yield return this._pin27;
            yield return this._pin28;
        }

        public override IEnumerable<IPin> GetRightPins()
        {
            yield return this._pin29;
            yield return this._pin30;
            yield return this._pin31;
            yield return this._pin32;
            yield return this._iovdd;
            yield return this._pin34;
            yield return this._pin35;
            yield return this._pin36;
            yield return this._pin37;
            yield return this._pin38;
            yield return this._pin39;
            yield return this._pin40;
            yield return this._pin41;
            yield return this._iovdd;
        }

        public override IEnumerable<IPin> GetTopPins()
        {
            yield return this._adc_avdd;
            yield return this._vreg_vin;
            yield return this._vreg_vout;
            yield return this._usb_dm;
            yield return this._usb_dp;
            yield return this._usb_vdd;
            yield return this._iovdd;
            yield return this._dvdd;
            yield return this._qspi_sd3;
            yield return this._qspi_sclk;
            yield return this._qspi_sd0;
            yield return this._qspi_sd2;
            yield return this._qspi_sd1;
            yield return this._qspi_ss_n;
        }
    }
}
