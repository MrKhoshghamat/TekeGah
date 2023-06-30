using TekeGah.Data.Context;
using TekeGah.Data.Repositories.Base;
using TekeGah.Domain.Entities.Account;
using TekeGah.Domain.Interfaces;
using TekeGah.Domain.Interfaces.Base;

namespace TekeGah.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IRepository<User> _userRepository;

    public UserRepository(TekeGahDbContext context, IRepository<User> userRepository) : base(context)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _userRepository.GetAsync(s => s.Email == email);
    }

    public async Task<bool> IsExistUserByEmail(string email)
    {
        return await _userRepository.IsExistAsync(s => s.Email == email);
    }

    public async Task<User?> GetUserByMobile(string mobile)
    {
        return await _userRepository.GetAsync(s => s.Mobile == mobile);
    }

    public async Task<bool> IsExistUserByMobile(string mobile)
    {
        return await _userRepository.IsExistAsync(s => s.Mobile == mobile);
    }
}