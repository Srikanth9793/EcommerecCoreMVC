using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    public class AppLocationUser:IdentityUser
    {
        public ICollection<Order>? orders { get; set; } 
    }
}
