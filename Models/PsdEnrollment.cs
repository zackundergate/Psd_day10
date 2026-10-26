using System.ComponentModel.DataAnnotations;

namespace Psd_day10.Models
{
    public class PsdEnrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int LearnerID { get; set; }
        public float Grade { get; set; }
        public virtual PsdLearner? Learner { get; set; }
        public virtual PsdCourse? Course { get; set; }
    }
}
