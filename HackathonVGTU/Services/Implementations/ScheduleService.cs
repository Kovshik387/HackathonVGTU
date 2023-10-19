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
        public async Task Add(ScheduleDto schedule)
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
                return await dbcontext.Schedules.Select(item => item.GroupName).ToListAsync();
            }
        }

        public async Task<List<string>> GetGroupsListByName(string group)
        {
            var regex = new Regex(group);
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                return await dbcontext.Schedules.Where(item => regex.IsMatch(item.GroupName))
                    .Select(item => item.GroupName).ToListAsync();
            }
        }

        public async Task<ScheduleDto?> GetSchedules(string group)
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                var result = await dbcontext.Schedules.Where(item => item.GroupName == group).ToListAsync();
                return this.mapper.Map<ScheduleDto>(result);
            }
        }
    }
}
