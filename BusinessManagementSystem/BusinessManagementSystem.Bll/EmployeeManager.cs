using Microsoft.AspNetCore.Http;
using BusinessManagementSystem.Dal.Abstract;
using BusinessManagementSystem.Entity.Base;
using BusinessManagementSystem.Entity.Dto;
using BusinessManagementSystem.Entity.IBase;
using BusinessManagementSystem.Entity.Models;
using BusinessManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BusinessManagementSystem.Bll
{
    public class EmployeeManager : GenericManager<Employee, DtoEmployee>, IEmployeeService
    {
        public readonly IEmployeeRepository employeeRepository;
        private IConfiguration configuration;

        public EmployeeManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            employeeRepository = service.GetService<IEmployeeRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoEmployeeToken> Login(DtoLogin login)
        {//login işlemi token yönetimi
            var employee = employeeRepository.Login(ObjectMapper.Mapper.Map<Employee>(login));

            if (employee != null)
            {
                var dtoEmployee = ObjectMapper.Mapper.Map<DtoLoginEmployee>(employee);

                var token = new TokenManager(configuration).CreateAccessToken(dtoEmployee);

                var userToken = new DtoEmployeeToken()
                {
                    DtoLoginEmployee = dtoEmployee,
                    AccessToken = token
                };

                return new Response<DtoEmployeeToken>
                {
                    Message = "Token üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoEmployeeToken>
                {
                    Message = "Kullanıcı kodu veya parolanız yanlış!",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }
        }
    }
}