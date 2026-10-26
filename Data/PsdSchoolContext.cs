using Microsoft.EntityFrameworkCore;
using Psd_day10.Models;

namespace Psd_day10.Data
{
    public class PsdSchoolContext : DbContext
    {
        public PsdSchoolContext(DbContextOptions<PsdSchoolContext> options) : base(options)
        {
        }

        public virtual DbSet<PsdCourse> Courses { get; set; }
        public virtual DbSet<PsdLearner> Learners { get; set; }
        public virtual DbSet<PsdEnrollment> Enrollments { get; set; }
        public virtual DbSet<PsdMajor> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PsdMajor>().ToTable(nameof(PsdMajor)).HasKey(m => m.MajorID);
            modelBuilder.Entity<PsdCourse>().ToTable(nameof(PsdCourse)).HasKey(c => c.CourseID);
            modelBuilder.Entity<PsdLearner>().ToTable(nameof(PsdLearner)).HasKey(l => l.LearnerID);
            modelBuilder.Entity<PsdEnrollment>().ToTable(nameof(PsdEnrollment)).HasKey(e => e.EnrollmentID);
        }
    }
}
