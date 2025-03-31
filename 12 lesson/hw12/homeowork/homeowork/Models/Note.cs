using System.ComponentModel.DataAnnotations;

namespace homeowork.Models
{
    public class Note
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Text { get; set; } = null!;
        [Required]
        public DateTime CreatedAt { get; set; }
        public string? Tags { get; set; }
    }
}
