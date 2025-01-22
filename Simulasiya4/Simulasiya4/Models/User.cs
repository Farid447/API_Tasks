using Microsoft.AspNetCore.Identity;

namespace Simulasiya4.Models;

public class User : IdentityUser
{
    public string UserName { get; set; }
}
