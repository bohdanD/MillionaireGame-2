using MediatR;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Models;
using MillionaireGame.Question.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Application.Answers.Queries
{
    public class GetCorrectAnswerQueryHandler : IRequestHandler<GetCorrectAnswerQuery, AnswerDto>
    {
        private IRepository<Domain.Question> _repository;

        public GetCorrectAnswerQueryHandler(IRepository<Domain.Question> repository)
        {
            _repository = repository;
        }

        public async Task<AnswerDto> Handle(GetCorrectAnswerQuery request, CancellationToken cancellationToken)
        {
            var question = await _repository.Find(request.QuestionId);
            var answer = question.Answers?.First(a => a.IsCorrect);
            AnswerDto dto = null;
            if (answer != null)
            {
                dto = new AnswerDto()
                {
                    AnswerId = answer.AnswerId,
                    AnswerText = answer.AnswerText,
                    IsCorrect = answer.IsCorrect
                };
            }

            return dto;
        }
    }
}
