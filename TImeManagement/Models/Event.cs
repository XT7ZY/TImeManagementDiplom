namespace TImeManagement.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public Employer? Employer { get; set; } 
        public DateTime EventDay { get; set; }
    }
}
