using MediatR;
using MillionaireGame.Question.Application.Models;

namespace MillionaireGame.Question.Application.Answers.Queries
{
    public class GetAnswerCorrectnessQuery : IRequest<AnswerDto>
    {
        public int AnswerId { get; set; }
    }
}
