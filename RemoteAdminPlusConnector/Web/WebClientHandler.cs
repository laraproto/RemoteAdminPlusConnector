using System.Net.Http;
using System.Threading.Tasks;
using RemoteAdminPlusConnector.Models;

namespace RemoteAdminPlusConnector.Web;

public static class WebClientHandler
{
    public static HttpClient Client { get; private set; }

    public static void Init()
    {
        Client = new HttpClient();
        Client.DefaultRequestHeaders.Add("Authorization", $"Server {RemoteAdminPlusPlugin.Cfg.ApiKey}");
        Client.BaseAddress = new Uri(RemoteAdminPlusPlugin.Cfg.ApiUrl);
    }

    public static async Task<PlayerCreateResponse> CreatePlayer(PlayerCreateRequest createRequest)
    {
        Logger.Info("Creating player: " + createRequest.PlatformId);
        var request = await Request.Post<PlayerCreateResponse>("server/createPlayer", createRequest, nameof(CreatePlayer));
        if (request.Ok)
            return request.Response;
        Logger.Error($"Create Player Failed: {createRequest.PlatformId}:\n{request.ResponseString}");
        return null;
    }

    public static async Task<PlayerGetResponse> GetPlayer(PlayerGetRequest getRequest)
    {
        var request = await Request.Post<PlayerGetResponse>("server/getPlayer", getRequest, $"{nameof(GetPlayer)}: {getRequest.PlatformId}");
        if (request.Ok)
            return request.Response;
        Logger.Error($"Get Player Failed: {getRequest.PlatformId}:\n{request.ResponseString}");
        return null;
    }

    public static async Task<CreateBanResponse> CreateBan(CreateBanRequest createBanRequest)
    {
        var request = await Request.Post<CreateBanResponse>("server/createBan", createBanRequest, $"{nameof(CreateBan)}: {createBanRequest.PlatformId}");
        if (request.Ok)
            return request.Response;
        Logger.Error($"Create Ban Failed: {createBanRequest.PlatformId}:\n{request.ResponseString}");
        return null;
    }
    
    public static async Task<AccountLinkResponse> LinkAccount(PlayerGetRequest accountLinkRequest)
    {
        var request = await Request.Post<AccountLinkResponse>("server/startAccountLink", accountLinkRequest, $"{nameof(LinkAccount)}: {accountLinkRequest.PlatformId}");
        if (request.Ok)
            return request.Response;
        Logger.Error($"Link Account Failed: {accountLinkRequest.PlatformId}:\n{request.ResponseString}");
        return null;
    }
    
    public static async Task<PlayerCreateResponse> UpdatePlayer(PlayerCreateRequest updateRequest)
    {
        var request = await Request.Post<PlayerCreateResponse>("server/updatePlayer", updateRequest, $"{nameof(UpdatePlayer)}: {updateRequest.PlatformId}");
        if (request.Ok)
            return request.Response;
        Logger.Error($"Update Player Failed: {updateRequest.PlatformId}:\n{request.ResponseString}");
        return null;
    }
}