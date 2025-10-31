namespace RemoteAdminPlusConnector.Models;

// ReSharper disable NotAccessedPositionalProperty.Global
[Serializable]
public sealed record PlayerCreateRequest(
    string Name,
    string PlatformId,
    bool DoNotTrack
);
    