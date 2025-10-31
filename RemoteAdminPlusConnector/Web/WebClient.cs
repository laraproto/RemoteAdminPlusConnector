using System.Net.Http;

namespace RemoteAdminPlusConnector.Web;

public static class WebClient
{
    public static HttpClient Client { get; private set; }

    public static void Init()
    {
        Client = new HttpClient();
        Client.DefaultRequestHeaders.Add("Authorization", $"Server {RemoteAdminPlusPlugin.Cfg.ApiKey}");
        Client.BaseAddress = new Uri(RemoteAdminPlusPlugin.Cfg.ApiUrl);
    }
}