using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonVGTU.DAL.Entities
{
    public partial class LoggingEntity : object
    {
        [KeyAttribute]
        public int Id { get; set; } = default!;
        public DateTime RequestTime { get; set; } = default!;

        [MaxLength(20)]
        public string UserIp { get; set; } = default!;

        [MaxLength(100)]
        public string CategoryName { get; set; } = default!;

        [MaxLength(100)]
        public string Value { get; set; } = default!;
    }
}
