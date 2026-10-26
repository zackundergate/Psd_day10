using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psd_day10.Models
{
    public class PsdCourse
    {
        public PsdCourse()
        {
            Enrollments = new HashSet<PsdEnrollment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<PsdEnrollment> Enrollments { get; set; }
    }
}
