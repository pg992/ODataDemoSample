﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataWebApiAspNetCore.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeProject = new HashSet<EmployeeProject>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? PracticeId { get; set; }
        public int? TitleId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Practice Practice { get; set; }
        public virtual Title Title { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProject { get; set; }
    }

    public partial class Employee
    {
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}
