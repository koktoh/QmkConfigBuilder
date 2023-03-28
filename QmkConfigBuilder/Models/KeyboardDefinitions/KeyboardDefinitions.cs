using QmkConfigBuilder.Models.KeyboardComponents;
using QmkConfigBuilder.Models.KeyboardDefinitions.Backlight;
using QmkConfigBuilder.Models.KeyboardDefinitions.Encoder;
using QmkConfigBuilder.Models.KeyboardDefinitions.Indicator;
using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;
using QmkConfigBuilder.Models.KeyboardDefinitions.RgbLighting;
using QmkConfigBuilder.Models.MCU;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.KeyboardDefinitions
{
    public class KeyboardDefinitions
    {
        public static readonly string DefaultVendorId = "0xFEED";
        public static readonly string DefaultProductId = "0x0001";

        public string VendorId { get; set; } = DefaultVendorId;
        public string ProductId { get; set; } = DefaultProductId;
        public string KeyboardName { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Maintainer { get; set; } = string.Empty;

        public IControllerUnit ControllerUnit { get; set; } = new ProMicro();

        public DiodeDirection DiodeDirection { get; set; } = DiodeDirection.COL2ROW;
        public bool IsDirectPin { get; set; } = false;
        public bool IsSplit { get; set; } = false;
        public IList<IPin> DirectPins { get; set; } = default!;
        public IMatrixDefinitionsCollection RowMatrixDefinitions { get; set; } = new MatrixDefinitionsCollection();
        public IMatrixDefinitionsCollection ColMatrixDefinitions { get; set; } = new MatrixDefinitionsCollection();

        public IIndicatorDefinitions NumLock { get; set; } = new IndicatorDefinitions();
        public IIndicatorDefinitions CapsLock { get; set; } = new IndicatorDefinitions();
        public IIndicatorDefinitions ScrollLock { get; set; } = new IndicatorDefinitions();
        public IIndicatorDefinitions Compose { get; set; } = new IndicatorDefinitions();
        public IIndicatorDefinitions Kana { get; set; } = new IndicatorDefinitions();

        public IBacklightDefinitions Backlight { get; set; } = new BacklightDefinitions();
        public IRgbLightingDefinitions RgbLighting { get; set; } = new RgbLightingDefinitions();

        public IEncoderPadDefinitions EncoderPadA { get; set; } = new EncoderPadDefinitions();
        public IEncoderPadDefinitions EncoderPadB { get; set; } = new EncoderPadDefinitions();

        public IList<ILayout> Layouts { get; set; } = new List<ILayout> { new Layout() };

        public IEnumerable<MatrixDefinitions> GetAllMatrixDefinitions() => this.RowMatrixDefinitions.Concat(this.ColMatrixDefinitions);
    }
}
