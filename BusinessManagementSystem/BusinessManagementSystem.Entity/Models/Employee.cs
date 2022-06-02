using BusinessManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessManagementSystem.Entity.Models
{
    public partial class Employee : EntityBase
    {
        public Employee()
        {
            Businesses = new HashSet<Business>();
            Requests = new HashSet<Request>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeTelephone { get; set; }
        public string EmployeeAuthority { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public object Password { get; set; }
    }
}
