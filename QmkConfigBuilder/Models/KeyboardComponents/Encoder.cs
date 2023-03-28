namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public class Encoder : IEncoder
    {
        private readonly IKey _key;

        public bool HasSwitch { get; private set; } = true;

        public Guid Id => this._key.Id;

        public string Label { get => this._key.Label; set => this._key.Label = value; }
        public double PosX { get => this._key.PosX; set => this._key.PosX = value; }
        public double PosY { get => this._key.PosY; set => this._key.PosY = value; }
        public ushort? Row { get => this.HasSwitch ? this._key.Row : null; set => this._key.Row = value; }
        public ushort? Column { get => this.HasSwitch ? this._key.Column : null; set => this._key.Column = value; }
        public double Width { get => this._key.Width; set => this._key.Width = value; }
        public double Height { get => this._key.Height; set => this._key.Height = value; }
        public KeyType KeyType { get => this._key.KeyType; set => this._key.KeyType = value; }

        public string Legend => this._key.Legend;

        public string LegendTopLeft { get => this._key.LegendTopLeft; set => this._key.LegendTopLeft = value; }
        public string LegendTopCenter { get => this._key.LegendTopCenter; set => this._key.LegendTopCenter = value; }
        public string LegendTopRight { get => this._key.LegendTopRight; set => this._key.LegendTopRight = value; }
        public string LegendCenterLeft { get => this._key.LegendCenterLeft; set => this._key.LegendCenterLeft = value; }
        public string LegendCenter { get => this._key.LegendCenter; set => this._key.LegendCenter = value; }
        public string LegendCenterRight { get => this._key.LegendCenterRight; set => this._key.LegendCenterRight = value; }
        public string LegendBottomLeft { get => this._key.LegendBottomLeft; set => this._key.LegendBottomLeft = value; }
        public string LegendBottomCenter { get => this._key.LegendBottomCenter; set => this._key.LegendBottomCenter = value; }
        public string LegendBottomRight { get => this._key.LegendBottomRight; set => this._key.LegendBottomRight = value; }
        public string LegendFrontLeft { get => this._key.LegendFrontLeft; set => this._key.LegendFrontLeft = value; }
        public string LegendFrontCenter { get => this._key.LegendFrontCenter; set => this._key.LegendFrontCenter = value; }
        public string LegendFrontRight { get => this._key.LegendFrontRight; set => this._key.LegendFrontRight = value; }

        public Encoder() : this(new Key(), true) { }

        public Encoder(bool hasSwitch) : this(new Key(), hasSwitch) { }

        public Encoder(IKey key) : this(key, true) { }

        public Encoder(IKey key, bool hasSwitch)
        {
            this._key = key;
            this._key.KeyType = KeyType.Encoder;
            this.HasSwitch = hasSwitch;
        }

        public void Update(string propertyName, object? value)
        {
            if (propertyName == nameof(IEncoder.HasSwitch) && value is bool hasSwitch)
            {
                this.HasSwitch = hasSwitch;
                return;
            }

            this._key.Update(propertyName, value);
        }
    }
}
