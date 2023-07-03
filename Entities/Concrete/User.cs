using Entities.Abstract;

namespace Entities.Concrete
{
    public class User : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}