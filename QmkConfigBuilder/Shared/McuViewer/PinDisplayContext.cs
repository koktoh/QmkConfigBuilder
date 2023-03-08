using System.Drawing;
using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;
using QmkConfigBuilder.Models.MCU.Definitions.Pinout.PinDefinitions;

namespace QmkConfigBuilder.Shared.McuViewer
{
    public class PinDisplayContext
    {
        private readonly IReadOnlyDictionary<PinType, ColorDefinitions> _pinTypeColor = new Dictionary<PinType, ColorDefinitions>
        {
            { PinType.Power, new ColorDefinitions(Color.Red, Color.White) },
            { PinType.GND, new ColorDefinitions(Color.Black, Color.White) },
            { PinType.SystemControl, new ColorDefinitions(Color.Pink, Color.Black) },
        };

        private readonly IReadOnlyDictionary<PinFunctionType, ColorDefinitions> _pinFunctionTypeColor = new Dictionary<PinFunctionType, ColorDefinitions>
        {
            { PinFunctionType.Digital, new ColorDefinitions(Color.DarkTurquoise, Color.Black) },
            { PinFunctionType.Analog, new ColorDefinitions(Color.DarkSlateGray, Color.White) },
            { PinFunctionType.SPI, new ColorDefinitions(Color.Violet, Color.White) },
            { PinFunctionType.I2C, new ColorDefinitions(Color.DodgerBlue, Color.White) },
            { PinFunctionType.Serial, new ColorDefinitions(Color.MediumPurple, Color.White) },
            { PinFunctionType.PWM, new ColorDefinitions(Color.LightCoral, Color.Black) },
            { PinFunctionType.USB, new ColorDefinitions(Color.LightGreen, Color.Black) },
            { PinFunctionType.SWD, new ColorDefinitions(Color.DarkSalmon, Color.Black) },
        };

        private readonly IReadOnlyDictionary<MatrixType, ColorDefinitions> _matrixTypeColor = new Dictionary<MatrixType, ColorDefinitions>
        {
            { MatrixType.Row, new ColorDefinitions("var(--rz-success)", Color.White) },
            { MatrixType.Column, new ColorDefinitions("var(--rz-warning)", Color.White) },
        };

        private readonly PinOrientation _orientation = PinOrientation.Left;
        private readonly MatrixDefinitions? _matrixDefinitions = null;
        private readonly IPinFunction? _pinFunction = null;

        public PinOrientation Orientation => this._orientation;
        public string Text => this._matrixDefinitions?.ToString() ?? this._pinFunction?.Label ?? string.Empty;
        public string BackgroundColor => this.GetColor().BackgroundColor;
        public string TextColor => this.GetColor().TextColor;

        public PinDisplayContext(IPinFunction pinFunction, PinOrientation pinOrientation)
        {
            this._pinFunction = pinFunction;
            this._orientation = pinOrientation;
        }

        public PinDisplayContext(MatrixDefinitions matrixDefinitions, PinOrientation pinOrientation)
        {
            this._matrixDefinitions = matrixDefinitions;
            this._orientation = pinOrientation;
        }

        private bool TryGetColorByMatrixType(MatrixType? type, out ColorDefinitions result)
        {
            result = new ColorDefinitions();

            if (type is null)
            {
                return false;
            }

            if (this._matrixTypeColor.ContainsKey(type.Value))
            {
                result = this._matrixTypeColor[type.Value];
                return true;
            }

            return false;
        }

        private bool TryGetColorByPinType(PinType? type, out ColorDefinitions result)
        {
            result = new ColorDefinitions();

            if (type is null)
            {
                return false;
            }

            if (this._pinTypeColor.ContainsKey(type.Value))
            {
                result = this._pinTypeColor[type.Value];
                return true;
            }

            return false;
        }

        private bool TryGetColorByPinFunctionType(PinFunctionType? type, out ColorDefinitions result)
        {
            result = new ColorDefinitions();

            if (type is null)
            {
                return false;
            }

            if (this._pinFunctionTypeColor.ContainsKey(type.Value))
            {
                result = this._pinFunctionTypeColor[type.Value];
                return true;
            }

            return false;
        }

        private ColorDefinitions GetColor()
        {
            var result = new ColorDefinitions();

            if (this.TryGetColorByMatrixType(this._matrixDefinitions?.MatrixType, out result))
            {
                return result;
            }

            if (this.TryGetColorByPinType(this._pinFunction?.PinType, out result))
            {
                return result;
            }

            if (this.TryGetColorByPinFunctionType(this._pinFunction?.PinFunctionType, out result))
            {
                return result;
            }

            return result;
        }


        private class ColorDefinitions
        {
            public string BackgroundColor { get; }
            public string TextColor { get; }

            public ColorDefinitions() : this(Color.Transparent, Color.Black) { }

            public ColorDefinitions(Color backgroundColor, Color textColor) : this(backgroundColor.Name, textColor.Name) { }

            public ColorDefinitions(string backgroundColor, Color textColor) : this(backgroundColor, textColor.Name) { }

            public ColorDefinitions(Color backgroundColor, string textColor) : this(backgroundColor.Name, textColor) { }

            public ColorDefinitions(string backgroundColor, string textColor)
            {
                this.BackgroundColor = backgroundColor;
                this.TextColor = textColor;
            }
        }
    }
}
