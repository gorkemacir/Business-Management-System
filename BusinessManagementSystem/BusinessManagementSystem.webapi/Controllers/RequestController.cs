using BusinessManagementSystem.Entity.Dto;
using BusinessManagementSystem.Entity.Models;
using BusinessManagementSystem.Interface;
using BusinessManagementSystem.WebApi.Base;
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
    public class RequestController : ApiBaseController<IRequestService, Request, DtoRequest>
    {
        private readonly IRequestService requestService;
        public RequestController(IRequestService requestService) : base(requestService)
        {
            this.requestService = requestService;
        }
    }
}

