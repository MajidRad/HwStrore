using Microsoft.AspNetCore.Identity;

namespace HwStore.Domain;

public class ApplicationUser : IdentityUser<int>
{
    public UserAddress? Address { get; set; }
}
