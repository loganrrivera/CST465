using System.ComponentModel.DataAnnotations;

namespace LR.Models
{
    public class ContactModel
    {
        [Required, MaxLength(50)]
        public string? Name { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, MaxLength(500)]
        public string? Message { get; set; }
    }
}