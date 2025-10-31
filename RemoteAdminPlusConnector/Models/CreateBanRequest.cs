namespace RemoteAdminPlusConnector.Models;

public record CreateBanRequest(
    string CreatorId,
    long Duration,
    string PlatformId,
    string Reason,
    bool Permanent
    );