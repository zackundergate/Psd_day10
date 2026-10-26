using System.ComponentModel.DataAnnotations;

namespace Psd_day10.Models
{
    public class PsdLearner
    {
        public PsdLearner()
        {
            Enrollments = new HashSet<PsdEnrollment>();
        }

        [Key]
        public int LearnerID { get; set; }
        public string? LastName { get; set; }
        public string? FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int MajorID { get; set; }
        public virtual PsdMajor? Major { get; set; }
        public virtual ICollection<PsdEnrollment> Enrollments { get; set; }
    }
}
