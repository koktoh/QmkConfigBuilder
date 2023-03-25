namespace QmkConfigBuilder.Models.Json.Serializer
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T value)
        {
            return Utf8Json.JsonSerializer.ToJsonString(value);
        }

        public T Deserialize<T>(string json)
        {
            return Utf8Json.JsonSerializer.Deserialize<T>(json);
        }
    }
}
