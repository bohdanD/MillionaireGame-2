using MediatR;
using MillionaireGame.Question.Application.Models;

namespace MillionaireGame.Question.Application.Answers.Queries
{
    public class GetCorrectAnswerQuery : IRequest<AnswerDto>
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
