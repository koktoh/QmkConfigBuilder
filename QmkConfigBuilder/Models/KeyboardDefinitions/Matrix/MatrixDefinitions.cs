using QmkConfigBuilder.Extensions;
using System.Text.RegularExpressions;

namespace QmkConfigBuilder.Models.KeyboardDefinitions.Matrix
{
    public class MatrixDefinitions : PinSelectableBase
    {
        public MatrixType MatrixType { get; }
        public ushort Index { get; }

        public MatrixDefinitions(MatrixType matrixType, ushort index) : base(1)
        {
            this.MatrixType = matrixType;
            this.Index = index;
        }

        public override bool Equals(object? obj)
        {
            return obj is MatrixDefinitions other
                && other.MatrixType == this.MatrixType
                && other.Index == this.Index;
        }

        public override int GetHashCode()
        {
            return this.MatrixType.GetHashCode() | this.Index.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.MatrixType.ToDisplayString()} {this.Index}";
        }

        public static bool TryCast(string value, out MatrixDefinitions result)
        {
            result = default!;

            if (value is null || value.IsNullOrWhiteSpace())
            {
                return false;
            }

            var match = Regex.Match(value, $@"^(?<type>{MatrixType.Row}|(Col|{MatrixType.Column}))\s*(?<index>\d+)$");

            if (!match.Success)
            {
                return false;
            }

            var type = match.Groups["type"].Value.CastMatrixType();
            var index = ushort.Parse(match.Groups["index"].Value);

            result = new MatrixDefinitions(type, index);

            return true;
        }
    }
}
