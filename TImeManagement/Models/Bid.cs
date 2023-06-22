using System.ComponentModel.DataAnnotations.Schema;

namespace TImeManagement.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int TypeID { get; set; }
        public BidType? BidType { get; set; }
        public string Message { get; set; }
        public int SenderID { get; set; }
        public int? RecieverId { get; set; }
        public bool IsClosed { get; set; } = false;
        public DateTime SendTime { get; set; } = DateTime.Now;
        public Employer? EmployerSender { get; set; }
        public ICollection<Employer> Employers { get; set; }

    }
}
