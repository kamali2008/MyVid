
using Microsoft.AspNetCore.Identity;
using MyVid.Core.Models;
using MyVid.Core.Services;
using MyVid.Core.Services.Users;
using System.Security.Claims;
using System.Text;

namespace MyVid.Services.Users
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserManager<Usuario> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<Usuario> signInManager;
        public UserAuthenticationService(UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;

        }

        
        public async Task<Status> RegisterAsync(Usuario model, string password, string role)
        {
            var status = new Status();
            var userExists = await userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User already exist";
                return status;
            }
            
            var result = await userManager.CreateAsync(model, password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return status;
            }

            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));


            if (await roleManager.RoleExistsAsync(role))
            {
                await userManager.AddToRoleAsync(model, role);
            }

            status.StatusCode = 1;
            status.Message = "You have registered successfully";
            return status;
        }


        public async Task<Status> LoginAsync(string email, string password)
        {
            var status = new Status();
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid email";
                return status;
            }

            if (!await userManager.CheckPasswordAsync(user, password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password";
                return status;
            }

            var signInResult = await signInManager.PasswordSignInAsync(user, password, false, true);
            if (signInResult.Succeeded)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                status.StatusCode = 1;
                status.Message = "Logged in successfully";
            }
            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User is locked out";
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Error on logging in";
            }

            return status;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();

        }

        public async Task<Status> ChangePasswordAsync(string currentPassword, string newPassword, string email)
        {
            var status = new Status();

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                status.Message = "User does not exist";
                status.StatusCode = 0;
                return status;
            }
            var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded)
            {
                status.Message = "Password has updated successfully";
                status.StatusCode = 1;
            }
            else
            {
                status.Message = "Some error occcured";
                status.StatusCode = 0;
            }
            return status;

        }

        public async Task<Usuario> GetByEmailAsync(string email) => await userManager.FindByEmailAsync(email);
    }


}
