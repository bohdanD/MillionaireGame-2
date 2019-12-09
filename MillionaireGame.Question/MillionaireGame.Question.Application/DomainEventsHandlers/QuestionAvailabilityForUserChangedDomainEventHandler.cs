using MediatR;
using MillionaireGame.Question.Domain.Events;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Application.DomainEventsHandlers
{
    class QuestionAvailabilityForUserChangedDomainEventHandler : INotificationHandler<QuestionAvailabilityForUserChangedDomainEvent>
    {
        public Task Handle(QuestionAvailabilityForUserChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine("QuestionAvailabilityForUserChangedDomainEventHandler");
            return Task.CompletedTask;
        }
    }
}
