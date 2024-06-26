﻿using Project.Entities.Enums;

namespace Project.Entities.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

    }
}
