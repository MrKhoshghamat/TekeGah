using TekeGah.Domain.Entities.Account;
using TekeGah.Domain.Interfaces.Base;

namespace TekeGah.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmail(string email);
    Task<bool> IsExistUserByEmail(string email);
}