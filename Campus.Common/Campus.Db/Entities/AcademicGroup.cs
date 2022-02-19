using Campus.Db.Interfaces;

namespace Campus.Db.Entities
{
    public class AcademicGroup : IEntity
    {
        public StudentInfo Elder { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        public Guid Id { get; set; }
    }
}
