using AutoMapper;
using HackathonVGTU.API.Services.DataTransfer;
using HackathonVGTU.API.Services.Interfaces;
using HackathonVGTU.DAL;
using Microsoft.EntityFrameworkCore;

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

            }
        }

        public async Task<List<string>> GetGroupsList()
        {
            return null;
        }

        public async Task<List<string>> GetGroupsListByName(string group)
        {
            return null;
        }

        public async Task<ScheduleDto?> GetSchedules(string group)
        {
            return null;
        }
    }
}
