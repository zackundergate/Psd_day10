using System.ComponentModel.DataAnnotations;

namespace Psd_day10.Models
{
    public class PsdMajor
    {
        public PsdMajor()
        {
            Learners = new HashSet<PsdLearner>();
        }

        [Key]
        public int MajorID { get; set; }
        public string? MajorName { get; set; }
        public virtual ICollection<PsdLearner> Learners { get; set; }
    }
}
