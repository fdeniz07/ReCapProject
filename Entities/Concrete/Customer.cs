using Entities.Abstract;

namespace Entities.Concrete
{
    public class Customer : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}