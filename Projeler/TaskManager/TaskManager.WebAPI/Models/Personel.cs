namespace TaskManager.WebAPI.Models;

public sealed class Personel
{
    //public Ulid Id { get; set; } = Ulid.NewUlid();  database tarafında string type olarak atamak gerekiyor.
    public Personel()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ",FirstName, LastName);
    public string AvatarUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

}
