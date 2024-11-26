using System.ComponentModel.DataAnnotations;

namespace Midterm
{
    public class LongAnswerQuestionModel : TestQuestionModel
    {
        [Required]
        public override string Answer { get; set; }
    }
}
