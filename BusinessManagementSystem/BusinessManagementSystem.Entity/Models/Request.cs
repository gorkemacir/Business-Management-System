using BusinessManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessManagementSystem.Entity.Models
{
    public partial class Request : EntityBase
    {
        public Request()
        {
            Businesses = new HashSet<Business>();
        }

        public int RequestId { get; set; }
        public string RequestNumber { get; set; }
        public string RequestTitle { get; set; }
        public string RequestState { get; set; }
        public string RequestContent { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
