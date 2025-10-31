using System.Net.Http;

namespace RemoteAdminPlusConnector.Web;

public sealed class SendRequest<T> : Request
{

    public static SendRequest<T> Create(HttpMethod method, string url, string context, object data)
        => new(method, url, context, data);

    public T Response { get; private set; }
    
    private readonly object _data;

    private SendRequest(HttpMethod method, string url, string context, object data)
        : base(method, url, context) => _data = data;

    protected override HttpContent GetContent() => Serializer.SerializeContent(_data);
    
    protected override void ProcessResponse() => Response = Serializer.Deserialize<T>(ResponseString);

}