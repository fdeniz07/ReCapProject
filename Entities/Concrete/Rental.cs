using System;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Rental : BaseEntity, IEntity
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentStartDate { get; set; }
        public DateTime RentEndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}