using HackathonVGTU.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackathonVGTU.DAL
{
    public partial class VgtuFinderDbContext : DbContext
    {
        public virtual DbSet<LoggingEntity> Loggins { get; set; } = default!;
        public virtual DbSet<TeacherEntity> Teachers { get; set; } = default!;
        public virtual DbSet<ScheduleEntity> Schedules { get; set; } = default!;

        public VgtuFinderDbContext(DbContextOptions options) : base(options)
        {
        }

        protected VgtuFinderDbContext() : base()
        {
        }
    }
}