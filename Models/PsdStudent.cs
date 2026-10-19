namespace Psd_day10.Models
{
    public class PsdStudent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public PsdBranch? Branch { get; set; }
        public PsdGender? Gender { get; set; }
        public bool IsRegular { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBorth { get; set; }
    }
}
