namespace QmkConfigBuilder.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static bool HasMeaningfulValue(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }

        public static EnclosingType HowEnclosed(this string source, string enclosure)
        {
            if (source.StartsWith(enclosure) && source.EndsWith(enclosure))
            {
                return EnclosingType.Both;
            }

            if (source.StartsWith(enclosure) && !source.EndsWith(enclosure))
            {
                return EnclosingType.Head;
            }

            if (!source.StartsWith(enclosure) && source.EndsWith(enclosure))
            {
                return EnclosingType.Tale;
            }

            return EnclosingType.None;
        }

        public static string Enclose(this string source, string enclosure)
        {
            var kind = source.HowEnclosed(enclosure);

            switch (kind)
            {
                case EnclosingType.Both:
                    return source;
                case EnclosingType.Head:
                    return $"{source}{enclosure}";
                case EnclosingType.Tale:
                    return $"{enclosure}{source}";
                default:
                    return $"{enclosure}{source}{enclosure}";
            }
        }

        public static string Join(this IEnumerable<string> source, string separator)
        {
            return string.Join(separator, source);
        }

        public static string JoinSpace(this IEnumerable<string> source)
        {
            return source.Join(" ");
        }

        public static string JoinComma(this IEnumerable<string> source)
        {
            return source.Join(",");
        }

        public static string JoinNewLine(this IEnumerable<string> source)
        {
            return source.Join(Environment.NewLine);
        }

        public static IEnumerable<string> SplitComma(this string source, StringSplitOptions options = StringSplitOptions.None)
        {
            return source.Split(",", options);
        }

        public static IEnumerable<string> SplitNewLine(this string source, StringSplitOptions options = StringSplitOptions.None)
        {
            return source.Split(Environment.NewLine, options);
        }

        public static string Trim(this string source, string trimStr)
        {
            return source.Trim(trimStr.ToCharArray());
        }

        public static string TrimStart(this string source, string trimStr)
        {
            return source.TrimStart(trimStr.ToCharArray());
        }

        public static string TrimEnd(this string source, string trimStr)
        {
            return source.TrimEnd(trimStr.ToCharArray());
        }

        public static string Escape(this string source)
        {
            return source.Replace(@"\", @"\\").Replace(@"""", @"\""");
        }
    }
}
