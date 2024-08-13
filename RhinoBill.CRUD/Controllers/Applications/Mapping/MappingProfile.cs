using AutoMapper;
using RhinoBill.CRUD.Controllers.Applications.Dtos;
using RhinoBill.CRUD.Models;

namespace RhinoBill.CRUD.Controllers.Applications.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Application, ApplicationFormDto>();
        CreateMap<ApplicationFormDto, Application>();

        CreateMap<Application, ApplicationListDto>()
            .ForMember(l => l.StudentName,
                s => s.MapFrom(a => a.Student.FullName))
            .ForMember(l => l.Course,
                s => s.MapFrom(a => a.Course.CodeAndTitle));

    }
}