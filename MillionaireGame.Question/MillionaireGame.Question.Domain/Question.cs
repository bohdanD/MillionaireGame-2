using MillionaireGame.Question.Domain.Events;
using System.Collections.Generic;

namespace MillionaireGame.Question.Domain
{
    public class Question : Entity
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public override int Id { get; set; }

        public string QuestionText { get; set; }

        public int ComplexityId { get; set; }

        public Complexity Complexity { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public void SetUnAvailableStatusForUser(int userId)
        {
            AddDomainEvent(new QuestionAvailabilityForUserChangedDomainEvent(Id, userId, false));
        }
    }
}
