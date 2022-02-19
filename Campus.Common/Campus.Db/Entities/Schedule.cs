using Campus.Db.Interfaces;
using Campus.Db.Models;

namespace Campus.Db.Entities
{
    public class Schedule : IEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public WorkGroup WorkGroup { get; set; }

        public WeekTime StartTime { get; set; }
        public WeekTime EndTime { get; set; }
    }
}
