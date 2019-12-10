using MediatR;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Models;
using MillionaireGame.Question.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Application.Questions.Queries
{
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionDto>
    {
        private IRepository<Domain.Question> _repository;
        private IMediator _mediator;

        public GetQuestionQueryHandler(IRepository<Domain.Question> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<QuestionDto> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetSingle(q => q.ComplexityId == request.CopmlexityId);
            QuestionDto dto = null;
            if (result != null)
            {
                dto = new QuestionDto
                {
                    Answers = result.Answers?.Select(a => new AnswerDto() { AnswerId = a.AnswerId, AnswerText = a.AnswerText }),
                    Complexity = result.Complexity?.Name,
                    ComplexityId = result.ComplexityId,
                    QuestionText = result.QuestionText
                };
            }

            result.SetUnAvailableStatusForUser(request.UserId);
            _mediator.DispatchDomainEventsAsync(result);

            return dto;
        }
    }
}
