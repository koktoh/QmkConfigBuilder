namespace QmkConfigBuilder.Models.KeyboardComponents
{
    public class KeySize
    {
        private static readonly IReadOnlyDictionary<KeyType, KeySize> _keySizeDict = new Dictionary<KeyType, KeySize>()
        {
            { KeyType.ISOEnter, new KeySize(1.5, 2) },
        };

        public double Width { get; } = 1;
        public double Height { get; } = 1;

        public KeySize() { }
        public KeySize(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public static KeySize GetKeySize(KeyType keyType)
        {
            if (_keySizeDict.ContainsKey(keyType))
            {
                return _keySizeDict[keyType];
            }

            return new KeySize();
        }
    }
}
