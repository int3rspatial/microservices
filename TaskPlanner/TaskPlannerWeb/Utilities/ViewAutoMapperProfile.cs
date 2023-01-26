using AutoMapper;
using BusinessLogicLevel.Models;
using TaskPlannerWeb.Models;

namespace TaskPlannerWeb.Utilities
{
    public class ViewAutoMapperProfile : Profile
    {
        public ViewAutoMapperProfile() 
        {
            CreateMap<TaskViewModel, TaskModel>().ReverseMap();
            CreateMap<EmployeeViewModel, EmployeeModel>().ReverseMap();
        }
    }
}
