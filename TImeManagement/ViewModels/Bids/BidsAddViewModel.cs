using System.ComponentModel.DataAnnotations;

namespace TImeManagement.ViewModels.Bids
{
    public class BidsAddViewModel
    {
        public int TypeId { get; set; }
        [Required(ErrorMessage = "Укажите сообщение")]
        [MaxLength(100, ErrorMessage = "Максимальная длина сообщения 100 символов")]
        [MinLength(3, ErrorMessage = "Минимальная длина сообщения 5 символов")]
        public string Messange { get; set; } 

        public string SenderLogin { get; set; }
        public bool isClosed { get; set; } = false;
        public DateTime DateTimeCreated { get; set; } = DateTime.Now;
    }
}
