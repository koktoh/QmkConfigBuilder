using System.Text.RegularExpressions;
using QmkConfigBuilder.Extensions;

namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public partial class Key : IKey
    {
        private readonly Guid _id;

        public Guid Id => this._id;
        public string Label { get; set; } = string.Empty;
        public double PosX { get; set; } = 0;
        public double PosY { get; set; } = 0;
        public ushort? Row { get; set; } = 0;
        public ushort? Column { get; set; } = 0;
        public double Width { get; set; } = 1;
        public double Height { get; set; } = 1;
        public KeyType KeyType { get; set; } = KeyType.Normal;

        public string Legend => this.BuildLegend();

        public string LegendTopLeft { get; set; } = string.Empty;
        public string LegendTopCenter { get; set; } = string.Empty;
        public string LegendTopRight { get; set; } = string.Empty;
        public string LegendCenterLeft { get; set; } = string.Empty;
        public string LegendCenter { get; set; } = string.Empty;
        public string LegendCenterRight { get; set; } = string.Empty;
        public string LegendBottomLeft { get; set; } = string.Empty;
        public string LegendBottomCenter { get; set; } = string.Empty;
        public string LegendBottomRight { get; set; } = string.Empty;
        public string LegendFrontLeft { get; set; } = string.Empty;
        public string LegendFrontCenter { get; set; } = string.Empty;
        public string LegendFrontRight { get; set; } = string.Empty;

        public Key() : this(string.Empty, KeyType.Normal) { }

        public Key(string legend) : this(legend, KeyType.Normal) { }

        public Key(KeyType keyType) : this(string.Empty, keyType) { }

        public Key(string legend, KeyType keyType)
        {
            this._id = Guid.NewGuid();

            this.LegendTopLeft = legend;
            var keySize = KeySize.GetKeySize(keyType);

            this.Width = keySize.Width;
            this.Height = keySize.Height;
        }

        public Key(IKey key) : this()
        {
            this.Label = key.Label;
            this.PosX = key.PosX;
            this.PosY = key.PosY;
            this.Row = key.Row;
            this.Column = key.Column;
            this.Width = key.Width;
            this.Height = key.Height;
            this.KeyType = key.KeyType;
            this.LegendTopLeft = key.LegendTopLeft;
            this.LegendTopCenter = key.LegendTopCenter;
            this.LegendTopRight = key.LegendTopRight;
            this.LegendCenterLeft = key.LegendCenterLeft;
            this.LegendCenter = key.LegendCenter;
            this.LegendCenterRight = key.LegendCenterRight;
            this.LegendBottomLeft = key.LegendBottomLeft;
            this.LegendBottomCenter = key.LegendBottomCenter;
            this.LegendBottomRight = key.LegendBottomRight;
            this.LegendFrontLeft = key.LegendFrontLeft;
            this.LegendFrontCenter = key.LegendFrontCenter;
            this.LegendFrontRight = key.LegendFrontRight;
        }

        public void Update(string propertyName, object? value)
        {
            this.GetType().GetProperty(propertyName)?.SetValue(this, value);
        }

        private string BuildLegend()
        {
            var regend = this.EnumerateLegendParts().Join(@"\n");
            return LegendRegex().Replace(regend, "$1");
        }

        private IEnumerable<string> EnumerateLegendParts()
        {
            yield return this.LegendTopLeft.Escape();
            yield return this.LegendBottomLeft.Escape();
            yield return this.LegendTopRight.Escape();
            yield return this.LegendBottomRight.Escape();
            yield return this.LegendFrontLeft.Escape();
            yield return this.LegendFrontRight.Escape();
            yield return this.LegendCenterLeft.Escape();
            yield return this.LegendCenterRight.Escape();
            yield return this.LegendTopCenter.Escape();
            yield return this.LegendCenter.Escape();
            yield return this.LegendBottomCenter.Escape();
            yield return this.LegendFrontCenter.Escape();
        }

        public override bool Equals(object? obj)
        {
            return obj is IKey other
                && this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        [GeneratedRegex("^(.*?)(\\\\n)*$")]
        private static partial Regex LegendRegex();
    }
}
