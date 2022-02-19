﻿using Campus.Db.Interfaces;

namespace Campus.Db.Entities
{
    public class Activity : IEntity
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public virtual WorkGroup WorkGroup { get; set; }

        public DateTime StartsAt { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
