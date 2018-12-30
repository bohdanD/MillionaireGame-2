using MillionaireGame.Question.Domain;
using System.Collections.Generic;

namespace MillionaireGame.Question.Application.Questions.Models
{
    public class QuestionDto
    {
        public string QuestionText { get; set; }

        public int ComplexityId { get; set; }

        public string Complexity { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
    }
}
