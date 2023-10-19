using AutoMapper;
using HackathonVGTU.API.Services.DataTransfer;
using HackathonVGTU.API.Services.Interfaces;
using HackathonVGTU.DAL;
using HackathonVGTU.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HackathonVGTU.API.Services.Implementations
{
    public partial class ScheduleService : IScheduleService
    {
        private readonly IDbContextFactory<VgtuFinderDbContext> factory = default!;

        private readonly IMapper mapper = default!;
        public ScheduleService(IDbContextFactory<VgtuFinderDbContext> factory, IMapper mapper) : base()
        {
            this.factory = factory;
            this.mapper = mapper;
        }
        public async Task AddSchedule(ScheduleDto schedule)
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                await dbcontext.AddAsync(this.mapper.Map<ScheduleEntity>(schedule));
                await dbcontext.SaveChangesAsync();
            }
        }

        public async Task<List<string>> GetGroupsList()
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                return await dbcontext.Schedules.Include(item => item.Lessons)
                    .ThenInclude(item => item.Teacher)
                    .Select(item => item.GroupName).ToListAsync();
            }
        }

        public async Task<List<string>> GetGroupsListByFaculty(string? faculty)
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                return await ((IQueryable<ScheduleEntity>)(faculty switch 
                {
                    null => dbcontext.Schedules.AsQueryable(),
                    _ => dbcontext.Schedules.Where(item => Regex.IsMatch(item.Faculty, faculty)),
                }))
                .Include(item => item.Lessons).ThenInclude(item => item.Teacher)
                    .Select(item => item.GroupName).ToListAsync();
            }
        }

        public async Task<List<string>> GetGroupsListByName(string? group)
        {
            var regex = new Regex(group ?? string.Empty);
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                return await ((IQueryable<ScheduleEntity>)(group switch
                {
                    null => dbcontext.Schedules.AsQueryable(),
                    _ => dbcontext.Schedules.Where(item => regex.IsMatch(item.GroupName)),
                }))
                .Include(item => item.Lessons).ThenInclude(item => item.Teacher)
                    .Select(item => item.GroupName).ToListAsync();

            }
        }

        public async Task<ScheduleDto?> GetSchedules(string group)
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                var result = await dbcontext.Schedules.Where(item => item.GroupName == group)
                    .Include(item => item.Lessons).ThenInclude(item => item.Teacher)
                    .ToListAsync();
                return this.mapper.Map<ScheduleDto>(result);
            }
        }
    }
}
