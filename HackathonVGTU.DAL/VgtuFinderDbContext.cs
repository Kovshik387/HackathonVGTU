using HackathonVGTU.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HackathonVGTU.DAL
{
    public partial class VgtuFinderDbContext : DbContext
    {
        public virtual DbSet<LoggingEntity> Loggins { get; set; } = default!;
        public virtual DbSet<TeacherEntity> Teachers { get; set; } = default!;
        public virtual DbSet<ScheduleEntity> Schedules { get; set; } = default!;
        public virtual DbSet<LessonEntity> Lessons { get; set; } = default!;

        public VgtuFinderDbContext(DbContextOptions options) : base(options)
        {
        }

        protected VgtuFinderDbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}