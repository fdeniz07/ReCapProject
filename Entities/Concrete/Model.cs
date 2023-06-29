using Entities.Abstract;

namespace Entities.Concrete
{
    public class Model : BaseEntity, IEntity
    {
        public string ModelName { get; set; }
        public string Details { get; set; }
    }
}