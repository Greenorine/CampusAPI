using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Campus.Db.Interfaces;

namespace Campus.Db.Entities
{
    public class AcademicGroup : IEntity
    {
        [JsonIgnore] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [JsonIgnore] public string? CreatedBy { get; set; }
        [JsonIgnore] public string? ModifiedBy { get; set; }
        [JsonIgnore] public DateTime? CreatedOn { get; set; }
        [JsonIgnore] public DateTime? ModifiedOn { get; set; }
        [JsonIgnore] public bool IsDeleted { get; set; }
    }
}