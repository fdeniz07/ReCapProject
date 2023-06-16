using Entities.Abstract;

namespace Entities.Concrete
{
    public class Brand : BaseEntity, IEntity
    {
        public string BrandName { get; set; }

    }
}
