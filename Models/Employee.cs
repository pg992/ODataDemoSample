using System;
using System.Collections.Generic;

namespace ODataWebApiAspNetCore.Models
{
    public partial class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? PracticeId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Practice Practice { get; set; }
    }
}
