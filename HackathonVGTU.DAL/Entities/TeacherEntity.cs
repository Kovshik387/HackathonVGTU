using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonVGTU.DAL.Entities
{
    public partial class TeacherEntity : object
    {
        [Key]
        public int Id { get; set; } = default!;

        [MaxLength(100)]
        public string Surname { get; set; } = default!;

        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(100)]
        public string Patronymic { get; set; } = default!;


        [MaxLength(100)]
        public string Post { get; set; } = default!;

        [MaxLength(20)]
        public string Phone { get; set; } = default!;

        [MaxLength(100)]
        public string Email { get; set; } = default!;
        public string Education { get; set; } = default!;

        [MaxLength(100)]
        public string Department { get; set; } = default!;
        public int Code { get; set; } = default!;

        public string? Image { get; set; } = default!;
        public List<LessonEntity> Lessons { get; set; } = new();
    }
}
