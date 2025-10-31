using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RemoteAdminPlusConnector.Web;

public static class Serializer
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
    
    private static readonly MediaTypeHeaderValue Header = new(ContentTypes.Json);
    
    public static string Serialize<T>(T o) => JsonSerializer.Serialize(o, SerializerOptions);

    public static StringContent SerializeContent<T>(T o) => new(Serialize(o))
    {
        Headers =
        {
            ContentType = Header
        }
    };

    public static T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, SerializerOptions);
}