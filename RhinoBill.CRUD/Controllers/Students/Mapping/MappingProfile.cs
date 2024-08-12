using AutoMapper;
using RhinoBill.CRUD.Controllers.Students.Dtos;
using RhinoBill.CRUD.Models;

namespace RhinoBill.CRUD.Controllers.Students.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentFormDto>();
        CreateMap<StudentFormDto, Student>();

        CreateMap<Student, StudentListDto>();

    }
}
