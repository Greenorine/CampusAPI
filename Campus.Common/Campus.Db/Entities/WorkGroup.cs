using Campus.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Campus.Db.Entities
{
    public class WorkGroup : IEntity
    {
        public Guid TeacherId { get; set; }
        [JsonIgnore] public virtual TeacherInfo? Teacher { get; set; }

        public virtual List<StudentInfo>? Students { get; set; }

        [JsonIgnore] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [JsonIgnore] public string? CreatedBy { get; set; }
        [JsonIgnore] public string? ModifiedBy { get; set; }
        [JsonIgnore] public DateTime? CreatedOn { get; set; }
        [JsonIgnore] public DateTime? ModifiedOn { get; set; }
        [JsonIgnore] public bool IsDeleted { get; set; }
    }
}