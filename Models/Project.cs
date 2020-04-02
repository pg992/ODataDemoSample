using System;
using System.Collections.Generic;

namespace ODataWebApiAspNetCore.Models
{
    public partial class Project
    {
        public Project()
        {
            EmployeeProject = new HashSet<EmployeeProject>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProject { get; set; }
    }
}
