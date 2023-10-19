using HackathonVGTU.API.Services.DataTransfer;

namespace HackathonVGTU.API.Services.Interfaces
{
    public interface IScheduleService
    {
        public Task Add(ScheduleDto schedule);

        public Task<List<string>> GetGroupsListByName(string group);
        public Task<List<string>> GetGroupsList();
        public Task<ScheduleDto?> GetSchedules(string group);
    }
}
