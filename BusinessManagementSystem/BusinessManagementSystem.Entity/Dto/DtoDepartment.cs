using BusinessManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Entity.Dto
{
    public class DtoDepartment : DtoBase
    {
        public DtoDepartment()
        {
          
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int BusinessId { get; set; }
    }
}
