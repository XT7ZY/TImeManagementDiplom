using System.ComponentModel.DataAnnotations.Schema;

namespace TImeManagement.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int TypeID { get; set; }
        public BidType BidType { get; set; }
        public int SenderID { get; set; }
        public int RecieverId { get; set; }
        public DateTime SendTime { get; set; } = DateTime.Now;
    }
}
