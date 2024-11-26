using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public class TestQuestionModel
    {
        public int ID { get; set; }
        public string? Question { get; set; }
        [Required]
        public virtual string Answer { get; set; }
    }
}