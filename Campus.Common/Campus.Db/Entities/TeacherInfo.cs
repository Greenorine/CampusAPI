using Campus.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campus.Db.Entities
{
    public class TeacherInfo : IEntity
    {
        public virtual User User { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<WorkGroup> WorkGroups { get; set; }
    }
}
