using System.ComponentModel.DataAnnotations;
namespace Midterm;

public class TrueFalseQuestionModel : TestQuestionModel
{
    [Required]
    public override string Answer{get;set;}
}