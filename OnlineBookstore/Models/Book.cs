using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Range(0, 5)]
        public double Rating { get; set; }

        public string? CoverImage { get; set; }
    }
}
