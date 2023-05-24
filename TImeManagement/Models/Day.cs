namespace TImeManagement.Models
{
    public class Day
    {
        public int Id { get; set; }
        public DateTime DateOnly { get; set; }

        public ICollection<Employer> Employers { get; set; }

    }
}
