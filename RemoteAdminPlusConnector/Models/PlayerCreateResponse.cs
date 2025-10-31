using JetBrains.Annotations;

namespace RemoteAdminPlusConnector.Models;

// ReSharper disable NotAccessedPositionalProperty.Global
[Serializable]
public sealed record PlayerCreateResponse(
    [CanBeNull] PlayerData Player,
    bool Success
    );