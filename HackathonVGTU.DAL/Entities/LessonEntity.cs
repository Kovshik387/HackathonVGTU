using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonVGTU.DAL.Entities
{
    public partial class LessonEntity : object
    {
        [Key]
        public int Id { get; set; } = default!;

        [MaxLength(100)]
        public string LessonName { get; set; } = default!;

        [MaxLength(50)]
        public string Auditorium { get; set; } = default!;

        public int LessonOrder { get; set; } = default!;
        public TimeOnly StartTime { get; set; } = default!;
        public TimeOnly EndTime { get; set; } = default!;

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; } = default!;
        public TeacherEntity Teacher { get; set; } = new();

        [ForeignKey(nameof(Schedule))]
        public int ScheduleId { get; set; } = default!;
        public ScheduleEntity Schedule { get; set; } = new();
    }
}
