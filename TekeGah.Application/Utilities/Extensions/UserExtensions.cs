using TekeGah.Domain.Entities.Account;

namespace TekeGah.Application.Utilities.Extensions;

public static class UserExtensions
{
    public static string? GetUserName(this User user)
    {
        if (!string.IsNullOrEmpty(user.Username))
            return $"{user.Username}";

        var mobile = user.Mobile;

        return mobile;
    }
}