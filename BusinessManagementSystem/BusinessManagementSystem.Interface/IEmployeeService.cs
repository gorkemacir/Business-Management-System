using BusinessManagementSystem.Entity.Dto;
using BusinessManagementSystem.Entity.IBase;
using BusinessManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Interface
{
    public interface IEmployeeService : IGenericService<Employee,DtoEmployee>
    {
        IResponse<DtoEmployeeToken> Login(DtoLogin login);
        //Bu sınıfa ait özel metotları burda yazacağız.login gibi işlemler
    }
}
