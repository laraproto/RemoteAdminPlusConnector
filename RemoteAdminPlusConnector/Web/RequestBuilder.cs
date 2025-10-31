using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace RemoteAdminPlusConnector.Web;

public partial class Request
{

    private delegate T CreateRequestDelegate<out T>(string url, string context) where T : Request;

    protected static string ResolveContext()
    {
        var trace = new StackTrace();
        foreach (var frame in trace.GetFrames() ?? [])
            if (!typeof(Request).IsAssignableFrom(frame.GetMethod().DeclaringType))
                return frame.GetMethod().Name;
        return "Request";
    }
    
    public static Task<SendRequest<T>> Post<T>(string url, object data, string context = null)
        => Send(url, context, CreateSendRequest<T>(HttpMethod.Post, data));

    private static CreateRequestDelegate<SendRequest<T>> CreateSendRequest<T>(HttpMethod post, object data)
        => (url, context) => SendRequest<T>.Create(post, url, context, data);

    private static async Task<T> Send<T>(string url, string context, CreateRequestDelegate<T> createDelegate) where T : Request
    {
        var request = createDelegate(url, context ?? ResolveContext());
        await request.SendAsync().ConfigureAwait(false);
        return request;
    }

}