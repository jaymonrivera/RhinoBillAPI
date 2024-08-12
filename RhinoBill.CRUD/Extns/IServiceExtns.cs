using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RhinoBill.CRUD.Services.Interfaces;
using RhinoBill.CRUD.Services;

namespace RhinoBill.CRUD.Extns;

public static class IServiceExtns 
{
    public static IServiceCollection AddRhinoBillServices(this IServiceCollection services)
    {
        services.AddDbContext<RhinoBillDbContext>(options =>
            options.UseInMemoryDatabase("RhinoBillDb"));

        // Add MediatR
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        // Add FluentValidation
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<Program>();

        // Add AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddMediatorServices();

        return services;
    }

    public static IServiceCollection AddMediatorServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<ICourseService, CourseService>();

        return services;
    }
}
