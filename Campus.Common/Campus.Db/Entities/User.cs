using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Campus.Db.Interfaces;

namespace Campus.Db.Entities;

public class User : IBaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Roles { get; set; }

    [JsonIgnore] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? Id { get; set; }
}