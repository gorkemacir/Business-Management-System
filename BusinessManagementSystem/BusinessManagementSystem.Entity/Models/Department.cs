using BusinessManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessManagementSystem.Entity.Models
{
    public partial class Department : EntityBase
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Requests = new HashSet<Request>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int BusinessId { get; set; }

        public virtual Business Business { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
