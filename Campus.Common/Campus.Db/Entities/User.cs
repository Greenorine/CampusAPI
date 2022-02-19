using Campus.Db.Interfaces;

namespace Campus.Db.Entities;

public class User : IBaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Roles { get; set; }
    public Guid Id { get; set; }
}