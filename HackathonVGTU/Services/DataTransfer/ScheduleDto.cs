using HackathonVGTU.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HackathonVGTU.API.Services.DataTransfer
{
    public sealed class ScheduleDto : object
    {
        public string GroupName { get; set; } = default!;
        public string WeekDay { get; set; } = default!;
        public WeekType WeekType { get; set; } = default!;

        public List<LessonEntity> Lessons { get; set; } = new();
    }
}
