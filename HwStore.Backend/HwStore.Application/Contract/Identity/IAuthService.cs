using HwStore.Application.Models.Identity;

namespace HwStore.Application.Contract.Identity;

public interface IAuthService
{
    public Task<AuthResponse> Login(AuthRequest request);
    public Task<RegisterationResponse> Register(RegistarationRequest request);
    public Task<ApplicationUser> GetCurrentUser();
    public Task<ApplicationUser> GetUser(AuthRequest request);
}
