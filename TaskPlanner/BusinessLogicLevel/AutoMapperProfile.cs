using AutoMapper;
using BusinessLogicLevel.Models;
using DataAccessLayer.Entities;

namespace BusinessLogicLevel
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataAccessLayer.Entities.Task, TaskModel>().ReverseMap();
            CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
