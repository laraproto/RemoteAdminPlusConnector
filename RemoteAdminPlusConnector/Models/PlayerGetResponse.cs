using JetBrains.Annotations;

namespace RemoteAdminPlusConnector.Models;

public record PlayerGetResponse(
    [CanBeNull] bool? BanActive,
    [CanBeNull] PlayerData Player,
    bool Success
    );