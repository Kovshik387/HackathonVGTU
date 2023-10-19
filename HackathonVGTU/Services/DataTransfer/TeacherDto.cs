using HackathonVGTU.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace HackathonVGTU.API.Services.DataTransfer
{
    public partial class TeacherDto : object
    {
        public string Surname { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Patronymic { get; set; } = default!;

        public string Post { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Education { get; set; } = default!;


        public string Department { get; set; } = default!;
        public int Code { get; set; } = default!;
        public byte[]? Image { get; set; } = default!;
        public List<ScheduleEntity> Schedules { get; set; } = new();
    }
}
