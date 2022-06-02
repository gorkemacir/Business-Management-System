using BusinessManagementSystem.Entity.Base;
using BusinessManagementSystem.Entity.Dto;
using BusinessManagementSystem.Entity.IBase;
using BusinessManagementSystem.Entity.Models;
using BusinessManagementSystem.Interface;
using BusinessManagementSystem.WebApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ApiBaseController<IEmployeeService, Employee, DtoEmployee>
    {
        private readonly IEmployeeService employeeService;
    
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            this.employeeService = employeeService;
        }
       

        [HttpPost("Login")]
        [AllowAnonymous]
        public IResponse<DtoEmployeeToken> Login(DtoLogin login)
        {
            try
            {
                return employeeService.Login(login);
            }
            catch (Exception ex)
            {
                return new Response<DtoEmployeeToken>
                {
                    Message = "Error:" + ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }


    }
}
