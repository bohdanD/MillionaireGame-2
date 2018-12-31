using MediatR;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Models;
using MillionaireGame.Question.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Application.Answers.Queries
{
    public class GetAnswerCorrectnessQueryHandler : IRequestHandler<GetAnswerCorrectnessQuery, AnswerDto>
    {
        private IRepository<Answer> _repository;

        public GetAnswerCorrectnessQueryHandler(IRepository<Answer> repository)
        {
            _repository = repository;
        }

        public async Task<AnswerDto> Handle(GetAnswerCorrectnessQuery request, CancellationToken cancellationToken)
        {
            var answer = await _repository.Find(request.AnswerId);
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
