using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonVGTU.DAL.Entities
{
    public enum WeekType : int { White, Grey }

    public partial class ScheduleEntity : object
    {
        [Key]
        public int Id { get; set; } = default!;

        [MaxLength(50)]
        public string GroupName { get; set; } = default!;

        [MaxLength(50)]
        public string WeekDay { get; set; } = default!;
        public WeekType WeekType { get; set; } = default!;

        public List<LessonEntity> Lessons { get; set; } = new();
    }
}
