using HackathonVGTU.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HackathonVGTU.API.Services.DataTransfer
{
    public sealed class LessonDto : object
    {
        public string LessonName { get; set; } = default!;
        public string Auditorium { get; set; } = default!;

        public int LessonOrder { get; set; } = default!;
        public TimeOnly StartTime { get; set; } = default!;
        public TimeOnly EndTime { get; set; } = default!;

        public int TeacherId { get; set; } = default!;
        public TeacherEntity Teacher { get; set; } = new();
        public ScheduleEntity Schedule { get; set; } = new();
    }
}
