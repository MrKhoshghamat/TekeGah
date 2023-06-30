using TekeGah.Application.Models.Status;
using TekeGah.Application.Models.ViewModels;
using TekeGah.Application.Services.Interface;
using TekeGah.Application.Utilities.Generators;
using TekeGah.Application.Utilities.Security;
using TekeGah.Domain.Entities.Account;
using TekeGah.Domain.Interfaces;

namespace TekeGah.Application.Services.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserRegisterStatus> Register(UserRegisterViewModel userRegisterViewModel)
    {
        if (await _userRepository.IsExistUserByMobile(userRegisterViewModel.Mobile.SanitizeText().Trim().ToLower()))
            return UserRegisterStatus.UserExisted;

        var user = new User()
        {
            Id = CodeGenerator.EntityGuidGenerator(),
            Mobile = userRegisterViewModel.Mobile.SanitizeText().Trim().ToLower()
        };

        await _userRepository.CreateAsync(user);
        
        // TODO Send Verification Code

        return UserRegisterStatus.Succeed;
    }
}