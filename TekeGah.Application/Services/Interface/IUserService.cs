using TekeGah.Application.Models.Status;
using TekeGah.Application.Models.ViewModels;

namespace TekeGah.Application.Services.Interface;

public interface IUserService
{
    #region Register

    Task<UserRegisterStatus> Register(UserRegisterViewModel userRegisterViewModel);

    #endregion

    #region Login



    #endregion

    #region Logout



    #endregion
}