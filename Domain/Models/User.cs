using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public UserInfo UserInfo { get; set; }

        public List<Review> Reviews { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
    }
}
