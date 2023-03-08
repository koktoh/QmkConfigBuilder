namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public interface IKey
    {
        public Guid Id { get; }
        public string Label { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public ushort? Row { get; set; }
        public ushort? Column { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public KeyType KeyType { get; set; }
        public string Legend { get; }
        public string LegendTopLeft { get; set; }
        public string LegendTopCenter { get; set; }
        public string LegendTopRight { get; set; }
        public string LegendCenterLeft { get; set; }
        public string LegendCenter { get; set; }
        public string LegendCenterRight { get; set; }
        public string LegendBottomLeft { get; set; }
        public string LegendBottomCenter { get; set; }
        public string LegendBottomRight { get; set; }
        public string LegendFrontLeft { get; set; }
        public string LegendFrontCenter { get; set; }
        public string LegendFrontRight { get; set; }

        public void Update(string propertyName, object? value);
    }
}
