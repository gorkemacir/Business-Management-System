using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Entity.Dto
{
    public class DtoEmployeeToken
    {
        public DtoLoginEmployee DtoLoginEmployee { get; set; }   
        public object AccessToken { get; set; }
    }
}
