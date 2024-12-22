using MiniECommerce.Domain.Core;

namespace MiniECommerce.Domain.Users
{
    public class Role : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
