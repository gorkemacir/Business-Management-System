using BusinessManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Entity.Dto
{
    public class DtoBusiness : DtoBase
    {
        public DtoBusiness()
        {
            
        }

        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessDetails { get; set; }
        public DateTime BusinessStartDate { get; set; }
        public DateTime BusinessEndDate { get; set; }
        public int EmployeeId { get; set; }
        public int RequestId { get; set; }
    }
}
