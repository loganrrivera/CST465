using System.Collections.Generic;

namespace Midterm
{
    public class TestQuestion
    {
        public int ID { get; set; }
        public string QuestionType { get; set; } = string.Empty;
        public string Question { get; set; } = string.Empty;
        public List<string> Choices { get; set; } = new List<string>();
    }
}
