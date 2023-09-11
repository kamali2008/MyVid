using MyVid.Core.Models;

namespace MyVid.Core.Services.Users
{
    public interface IUserAuthenticationService
    {

        Task<Status> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<Status> RegisterAsync(Usuario model, string password, string role);
        Task<Status> ChangePasswordAsync(string currentPassword, string newPassword, string email);
        Task<Usuario> GetByEmailAsync(string email);
        Task<Status> UpdateUser(Usuario usuario);


    }
}
