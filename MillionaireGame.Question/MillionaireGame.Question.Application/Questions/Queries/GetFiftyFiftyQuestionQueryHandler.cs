using MediatR;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace MillionaireGame.Question.Application.Questions.Queries
{
    public class GetFiftyFiftyQuestionQueryHandler : IRequestHandler<GetFiftyFiftyQuestionQuery, QuestionDto>
    {
        private readonly IRepository<Domain.Question> _repository;

        public GetFiftyFiftyQuestionQueryHandler(IRepository<Domain.Question> repository)
        {
            _repository = repository;
        }

        public async Task<QuestionDto> Handle(GetFiftyFiftyQuestionQuery request, CancellationToken cancellationToken)
        {
            if (request == null || request.QuestionId < 1)
            {
                return null;
            }

            var question = await _repository.Find(request.QuestionId);

            QuestionDto result = null;

            if (question != null)
            {
                result = new QuestionDto()
                {
                    Complexity = question.Complexity?.Name,
                    ComplexityId = question.ComplexityId,
                    QuestionText = question.QuestionText
                };

                Random rnd = new Random();
                var num = rnd.Next(0, 3);
                var first = question.Answers.ElementAtOrDefault(num);
                Domain.Answer second;

                if (first != null && first.IsCorrect)
                {
                    second = question.Answers.LastOrDefault(a => !a.IsCorrect);
                }
                else
                {
                    second = question.Answers.FirstOrDefault(a => a.IsCorrect);
                }

                result.Answers = new[] { first, second }.Select(a => new AnswerDto
                {
                    AnswerId = a.AnswerId,
                    AnswerText = a.AnswerText,
                });
            }

            return result;
        }
    }
}
