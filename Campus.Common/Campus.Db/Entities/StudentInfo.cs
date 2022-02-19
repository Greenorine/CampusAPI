using Campus.Db.Interfaces;

namespace Campus.Db.Entities;

public class StudentInfo : IEntity
{
    public User User { get; set; }
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
    public AcademicGroup AcademicGroup { get; set; }

    public List<WorkGroup> WorkGroups { get; set; }
}