namespace RemoteAdminPlusConnector.Models;

[Serializable]
public record Ban(
    bool Active,
    string AuthorId,
    DateTime CreatedAt,
    DateTime ExpiresAt,
    string Reason,
    string Type,
    DateTime UpdatedAt,
    string Uuid,
    string VictimId
    );