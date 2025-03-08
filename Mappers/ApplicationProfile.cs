using AutoMapper;
using employee_app.Dtos;
using employee_app.Entities;
namespace employee_app.Mappers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<DepartmentCreateDto, Department>().ReverseMap();
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<Department, DepartmentListDto>();
        }
    }
}
