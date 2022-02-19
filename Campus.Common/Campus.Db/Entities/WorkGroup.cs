using Campus.Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campus.Db.Entities
{
    public class WorkGroup : IEntity
    {
        public Guid Id { get; set; }
        public TeacherInfo Teacher { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        public List<StudentInfo> Students{get; set;}
        
    }
}
