using BusinessManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessManagementSystem.Entity.Models
{
    public partial class Business : EntityBase
    {
        public Business()
        {
            Departments = new HashSet<Department>();
        }

        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessDetails { get; set; }
        public DateTime BusinessStartDate { get; set; }
        public DateTime BusinessEndDate { get; set; }
        public int EmployeeId { get; set; }
        public int RequestId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Request Request { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
