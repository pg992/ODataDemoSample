﻿using System;
using System.Collections.Generic;

namespace ODataWebApiAspNetCore.Models
{
    public partial class Company
    {
        public Company()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Addreess { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
