using BusinessManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Entity.Dto
{
    public class DtoRequest : DtoBase
    {
        public DtoRequest()
        {
            
        }

        public int RequestId { get; set; }
        public string RequestNumber { get; set; }
        public string RequestTitle { get; set; }
        public string RequestState { get; set; }
        public string RequestContent { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
    }
}
