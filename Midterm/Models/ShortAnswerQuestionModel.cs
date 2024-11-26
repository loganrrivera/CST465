using System.ComponentModel.DataAnnotations;

namespace Midterm
{
    public class ShortAnswerQuestionModel : TestQuestionModel
    {
        [Required]
        [MaxLength(100)] // Restrict to 100 characters
        public override string Answer { get; set; }
    }
}
