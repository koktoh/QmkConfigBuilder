using QmkConfigBuilder.Models.KeyboardDefinitions.Matrix;
using System.ComponentModel.DataAnnotations;

namespace QmkConfigBuilder.Models.KeyboardDefinitions.Matrix
{
    public enum MatrixType
    {
        Row,
        [Display(Description = "Col")]
        Column,
    }
}

public static class MatrixTypeExtensions
{
    private static readonly IDictionary<MatrixType, string> _toStringDict;
    private static readonly IDictionary<string, MatrixType> _toMatrixTypeDict;

    static MatrixTypeExtensions()
    {
        var type = typeof(MatrixType);
        var list = type.GetFields()
            .Where(x => x.FieldType == type)
            .Select(x => new { MatrixType = (MatrixType)x.GetValue(null)!, Attribute = (DisplayAttribute?)x.GetCustomAttributes(false).FirstOrDefault(y => y is DisplayAttribute) });

        _toStringDict = list.ToDictionary(x => x.MatrixType, x => x.Attribute?.GetDescription() ?? x.MatrixType.ToString());
        _toMatrixTypeDict = list.ToDictionary(x => x.Attribute?.GetDescription() ?? x.MatrixType.ToString(), x => x.MatrixType);
    }

    public static string ToDisplayString(this MatrixType mt)
    {
        return _toStringDict[mt];
    }

    public static MatrixType CastMatrixType(this string source)
    {
        if (Enum.TryParse<MatrixType>(source, out var result))
        {
            return result;
        }

        if (_toMatrixTypeDict.TryGetValue(source, out result))
        {
            return result;
        }

        return MatrixType.Row;
    }
}
