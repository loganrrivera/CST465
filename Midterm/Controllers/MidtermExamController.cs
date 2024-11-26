using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Midterm
{
    public class MidtermExamController : Controller
    {
        private readonly MidtermExam _Exam;

        public MidtermExamController(IOptions<MidtermExam> exam)
        {
            _Exam = exam.Value;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("TakeTest")]
        [HttpGet]
        public IActionResult TakeTest()
        {
            // Create models for all questions
            List<TestQuestionModel> questionModels = GetQuestionModels();
            return View(questionModels);
        }

        [Route("SubmitTest")]
        [HttpPost]
        public IActionResult SubmitTest(List<TestQuestionModel> model)
        {
            // Re-load the original questions
            List<TestQuestionModel> questionModels = GetQuestionModels();

            // Map posted answers back to the original questions
            foreach (var question in model)
            {
                var originalQuestion = questionModels.FirstOrDefault(q => q.ID == question.ID);
                if (originalQuestion != null)
                {
                    originalQuestion.Answer = question.Answer; // Assign the submitted answer
                }
            }

            // Check validation
            if (!ModelState.IsValid)
            {
                return View("TakeTest", questionModels);
            }

            // Pass the updated questionModels to the results view
            return View("DisplayResults", questionModels);
        }

        private List<TestQuestionModel> GetQuestionModels()
        {
            List<TestQuestionModel> questionModels = new List<TestQuestionModel>();

            foreach (var question in _Exam.Questions)
            {
                switch (question.QuestionType)
                {
                    case "TrueFalseQuestion":
                        questionModels.Add(new TrueFalseQuestionModel
                        {
                            ID = question.ID,
                            Question = question.Question
                        });
                        break;

                    case "ShortAnswerQuestion":
                        questionModels.Add(new ShortAnswerQuestionModel
                        {
                            ID = question.ID,
                            Question = question.Question
                        });
                        break;

                    case "LongAnswerQuestion":
                        questionModels.Add(new LongAnswerQuestionModel
                        {
                            ID = question.ID,
                            Question = question.Question
                        });
                        break;

                    case "MultipleChoiceQuestion":
                        questionModels.Add(new MultipleChoiceQuestionModel
                        {
                            ID = question.ID,
                            Question = question.Question,
                            Choices = question.Choices
                        });
                        break;
                }
            }

            return questionModels;
        }
    }
}
