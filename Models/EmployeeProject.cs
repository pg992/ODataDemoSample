using System;
using System.Collections.Generic;

namespace ODataWebApiAspNetCore.Models
{
    public partial class EmployeeProject
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
