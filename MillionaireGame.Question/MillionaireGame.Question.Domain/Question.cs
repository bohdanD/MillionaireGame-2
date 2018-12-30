using System.Collections.Generic;

namespace MillionaireGame.Question.Domain
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public int ComplexityId { get; set; }

        public Complexity Complexity { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
