namespace Project.Entities.Models
{
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
