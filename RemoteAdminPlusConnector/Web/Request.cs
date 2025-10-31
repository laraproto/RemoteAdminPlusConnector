using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RemoteAdminPlusConnector.Web;

public partial class Request
{

    private readonly HttpMethod _method;
    private readonly string _url;

    public string Context { get; set; }

    public HttpStatusCode StatusCode { get; private set; }

    public bool Ok => StatusCode is HttpStatusCode.OK or HttpStatusCode.Created;

    public bool NotFound => StatusCode == HttpStatusCode.NotFound;
    
    public bool BadRequest => StatusCode == HttpStatusCode.BadRequest;
    
    public bool Unauthorized => StatusCode == HttpStatusCode.Unauthorized;

    public string ResponseString { get; private set; }

    public Exception Exception { get; private set; }

    protected Request(HttpMethod method, string url, string context)
    {
        _method = method;
        _url = url;
        Context = context;
    }

    public async Task SendAsync()
    {
        try
        {
            using var content = GetContent();
            using var request = new HttpRequestMessage(_method, _url);
            request.Content = content;
            using var response = await WebClientHandler.Client.SendAsync(request).ConfigureAwait(false);
            StatusCode = response.StatusCode;
            ResponseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
                ProcessResponse();
        }
        catch (Exception e)
        {
            Exception = e;
            Logger.Debug($"Request failed:\n{e}");
        }
    }

    protected virtual HttpContent GetContent() => null;

    protected virtual void ProcessResponse()
    {
    }

}