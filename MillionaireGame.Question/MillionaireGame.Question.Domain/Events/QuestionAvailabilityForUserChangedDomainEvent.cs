using MediatR;

namespace MillionaireGame.Question.Domain.Events
{
    public class QuestionAvailabilityForUserChangedDomainEvent : INotification
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public bool IsAvailable { get; set; }

        public QuestionAvailabilityForUserChangedDomainEvent(int questionId, int userId, bool isAvailable = false)
        {
            QuestionId = questionId;
            UserId = userId;
            IsAvailable = isAvailable;
        }
    }
}
