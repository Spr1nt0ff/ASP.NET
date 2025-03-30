using System.ComponentModel.DataAnnotations.Schema;

namespace homework.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}