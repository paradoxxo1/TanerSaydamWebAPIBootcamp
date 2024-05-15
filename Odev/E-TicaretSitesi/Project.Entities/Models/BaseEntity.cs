using Project.Entities.Enums;
using Project.Entities.Interfaces;

namespace Project.Entities.Models
{
    public abstract class BaseEntity : IEntity
    {
        protected BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public  int Id { get; set; }
        public  DateTime CreatedDate { get; set; }
        public  DateTime? ModifiedDate { get; set; }
        public  DateTime? DeletedDate { get; set; }
        public  DataStatus Status { get; set; }
    }
}
