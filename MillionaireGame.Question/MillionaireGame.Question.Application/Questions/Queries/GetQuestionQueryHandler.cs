using MediatR;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Questions.Models;
using System.Linq;
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

        public async Task<QuestionDto> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetSingle(q => q.ComplexityId == request.CopmlexityId);
            QuestionDto dto = null;
            if (result != null)
            {
                dto = new QuestionDto
                {
                    Answers = result.Answers.Select(a => new AnswerDto() { AnswerId = a.AnswerId, AnswerText = a.AnswerText }),
                    Complexity = result.Complexity?.Name,
                    ComplexityId = result.ComplexityId,
                    QuestionText = result.QuestionText
                };
            }

            return dto;
        }
    }
}
