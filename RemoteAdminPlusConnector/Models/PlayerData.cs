namespace RemoteAdminPlusConnector.Models;

// ReSharper disable NotAccessedPositionalProperty.Global
[Serializable]
public sealed record PlayerData(
    DateTimeOffset CreatedAt,
    bool DoNotTrack,
    string Name,
    string PlatformId,
    DateTimeOffset UpdatedAt,
    string UserId,
    string Uuid,
    Ban[] Bans
    );