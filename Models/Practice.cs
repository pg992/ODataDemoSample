using System;
using System.Collections.Generic;

namespace ODataWebApiAspNetCore.Models
{
    public partial class Practice
    {
        public Practice()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
