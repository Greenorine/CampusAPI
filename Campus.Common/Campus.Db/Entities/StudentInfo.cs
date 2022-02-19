using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Campus.Db.Interfaces;

namespace Campus.Db.Entities;

public class StudentInfo : IEntity
{
    [ForeignKey(nameof(Entities.User))] public Guid UserId { get; set; }
    [JsonIgnore] public virtual User? User { get; set; }

    [ForeignKey(nameof(Entities.AcademicGroup))]
    public Guid AcademicGroupId { get; set; }

    [JsonIgnore] public virtual List<WorkGroup>? WorkGroups { get; set; }

    [JsonIgnore] public virtual AcademicGroup? AcademicGroup { get; set; }

    [JsonIgnore] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid? Id { get; set; }

    [JsonIgnore] public DateTime? CreatedOn { get; set; }
    [JsonIgnore] public DateTime? ModifiedOn { get; set; }
    [JsonIgnore] public string? CreatedBy { get; set; }
    [JsonIgnore] public string? ModifiedBy { get; set; }
    [JsonIgnore] public bool IsDeleted { get; set; }
}