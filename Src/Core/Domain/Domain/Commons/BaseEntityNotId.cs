﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commons
{
    public abstract class BaseEntityNotId
    {
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdateBy { get; set; }
        public string? IPAddress { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }
}