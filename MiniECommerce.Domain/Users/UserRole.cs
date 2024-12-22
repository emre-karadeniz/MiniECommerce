using MiniECommerce.Domain.Core;

namespace MiniECommerce.Domain.Users
{
    public class UserRole : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
