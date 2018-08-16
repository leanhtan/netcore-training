﻿using System;

namespace SimpleBlogEngine.Repository.Models
{
    public class BaseEntity
    {
        public Int64 Id { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string IPAddress { get; set; }
    }
}
