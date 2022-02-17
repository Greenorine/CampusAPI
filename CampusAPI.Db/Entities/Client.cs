using CampusAPI.Model.Interfaces;

namespace CampusAPI.Db.Entities;

public class Client : IEntity
{
    public string? Name { get; set; }
    public Guid? Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public bool? IsDeleted { get; set; }
}