using HackathonVGTU.API.Services.DataTransfer;

namespace HackathonVGTU.API.Services.Implementations
{
    public interface IScheduleService
    {
        public Task Add(ScheduleDto schedule);
        public Task<List<ScheduleDto>> GetSchedules(string group);
    }
}
