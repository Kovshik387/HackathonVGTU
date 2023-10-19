using HackathonVGTU.API.Services.DataTransfer;

namespace HackathonVGTU.API.Services.Interfaces
{
    public interface IScheduleService
    {
        public Task AddSchedule(ScheduleDto schedule);
        public Task<List<string>> GetGroupsListByName(string? group);

        public Task<List<string>> GetGroupsListByFaculty(string? faculty);
        public Task<List<string>> GetGroupsList();

        public Task<List<string>> GetAllFaculties();
        public Task<ScheduleDto?> GetSchedules(string group);
    }
}
