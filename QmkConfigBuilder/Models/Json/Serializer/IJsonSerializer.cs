namespace QmkConfigBuilder.Models.Json.Serializer
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T value);
        T Deserialize<T>(string json);
    }
}
