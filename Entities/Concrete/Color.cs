using Entities.Abstract;

namespace Entities.Concrete
{
    public class Color : BaseEntity, IEntity
    {
        public string ColorName { get; set; }
    }
}
