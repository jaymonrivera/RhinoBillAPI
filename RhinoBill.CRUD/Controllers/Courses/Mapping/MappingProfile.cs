using AutoMapper;
using RhinoBill.CRUD.Controllers.Courses.Dtos;
using RhinoBill.CRUD.Models;

namespace RhinoBill.CRUD.Controllers.Courses.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseFormDto>();
        CreateMap<CourseFormDto, Course>();

        CreateMap<Course, CourseListDto>();

    }
}
