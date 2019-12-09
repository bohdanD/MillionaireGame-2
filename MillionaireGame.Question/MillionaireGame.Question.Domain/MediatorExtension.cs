using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Domain
{
    public static class MediatorExtension
    {

        // might be good idea in future to extract this method into another class or Context
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, Question question)
        {
            foreach (var domainEvent in question.DomainEvents ?? Enumerable.Empty<INotification>())
            {
                await mediator.Publish(domainEvent);
            }
        }

    }
}
