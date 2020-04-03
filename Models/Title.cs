using System;
using System.Collections.Generic;

namespace ODataWebApiAspNetCore.Models
{
    public partial class Title
    {
        public Title()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public Position Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }

    public enum Position
    {
        JrTechnicalConsultant,
        TechnicalConsultant,
        SrTechnicalConsultant,
        LeadTechnicalConsultant,
        PracticeLead,
        JrTechnicalArchitect,
        TechincalArchitect
    }
}
