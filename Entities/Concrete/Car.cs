using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : BaseEntity, IEntity
    {
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }

        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
    }
}
