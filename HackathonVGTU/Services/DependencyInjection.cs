using HackathonVGTU.API.Commons.AutoMapper;
using HackathonVGTU.API.Services.Implementations;
using HackathonVGTU.API.Services.Interfaces;
using HackathonVGTU.DAL;
using Microsoft.EntityFrameworkCore;

namespace HackathonVGTU.API.Services
{
    public static class DependencyInjection : object
    {
        public static IServiceCollection AddBllServices(this IServiceCollection collection, IConfiguration configuration)
        {
            return collection
                .AddAutoMapper(typeof(EntitiesMapping))
                .AddDbContextFactory<VgtuFinderDbContext>(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("Default"));
                })
                .AddTransient<ITeacherService, TeacherService>()
                .AddTransient<IScheduleService, ScheduleService>();
        }
    }
}
