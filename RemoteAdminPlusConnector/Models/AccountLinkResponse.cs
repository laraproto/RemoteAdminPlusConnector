namespace RemoteAdminPlusConnector.Models;

public record AccountLinkResponse(
    string LinkToken,
    bool Success
    );