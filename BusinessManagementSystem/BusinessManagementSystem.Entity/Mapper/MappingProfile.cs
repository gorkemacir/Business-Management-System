using AutoMapper;
using BusinessManagementSystem.Entity.Dto;
using BusinessManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {//modelleri dtolara ,dtoları modellere dönüştürüyoruz 
            CreateMap<Business, DtoBusiness>().ReverseMap();
            CreateMap<Employee, DtoEmployee>().ReverseMap();
            CreateMap<Request, DtoRequest>().ReverseMap();
            CreateMap<Employee, DtoLoginEmployee>();
            CreateMap<DtoLogin, Employee>();
        }
    }
}
