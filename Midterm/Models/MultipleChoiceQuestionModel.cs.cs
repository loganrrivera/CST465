using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Midterm
{
    public class MultipleChoiceQuestionModel : TestQuestionModel
    {
        public List<string> Choices { get; set; } = new List<string>();

        [Required]
        public override string Answer { get; set; }
    }
}
