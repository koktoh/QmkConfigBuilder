namespace QmkConfigBuilder.Shared
{
    public class Padding
    {
        private readonly string _top;
        private readonly string _right;
        private readonly string _bottom;
        private readonly string _left;

        public string Value => this.GetPadding();

        public Padding(string top, string right, string bottom, string left)
        {
            this._top = top;
            this._right = right;
            this._bottom = bottom;
            this._left = left;
        }
        public Padding(string top, string horizontal, string bottom) : this(top, horizontal, horizontal, bottom) { }
        public Padding(string vertical, string horizontal) : this(vertical, horizontal, vertical) { }
        public Padding(string all) : this(all, all) { }
        public Padding(int top, int right, int bottom, int left) : this($"{top}px", $"{right}px", $"{bottom}px", $"{left}px") { }
        public Padding(int top, int horizontal, int bottom) : this(top, horizontal, horizontal, bottom) { }
        public Padding(int vertical, int horizontal) : this(vertical, horizontal, vertical) { }
        public Padding(int all) : this(all, all) { }

        private string GetPadding()
        {
            return $"padding: {this._top} {this._right} {this._bottom} {this._left};";
        }
    }
}
