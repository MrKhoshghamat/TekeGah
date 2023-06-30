using Microsoft.Extensions.DependencyInjection;
using TekeGah.Application.Services.Implementation;
using TekeGah.Application.Services.Interface;
using TekeGah.Data.Repositories;
using TekeGah.Domain.Interfaces;

namespace TekeGah.Data;

public class DependencyContainer
{
    public static void RegisterDependencies(IServiceCollection services)
    {
        #region Repositories

        services.AddScoped<IUserRepository, UserRepository>();

        #endregion

        #region Services

        services.AddScoped<IUserService, UserService>();

        #endregion
    }
}
