using MediatR;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Questions.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Application.Questions.Queries
{
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionDto>
    {
        private IRepository<Domain.Question> _repository;

        public GetQuestionQueryHandler(IRepository<Domain.Question> repository)
        {
            _repository = repository;
        }

        public Task<QuestionDto> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetSingle(q => q.ComplexityId == request.CopmlexityId);

            var dto = new QuestionDto
            {
                Answers = result.Answers,
                Complexity = result.Complexity?.Name,
                ComplexityId = result.ComplexityId,
                QuestionText = result.QuestionText
            };

            return Task.Run(() => dto);
        }
    }
}
