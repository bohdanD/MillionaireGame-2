using MediatR;
using MillionaireGame.Question.Application.Models;

namespace MillionaireGame.Question.Application.Questions.Queries
{
    public class GetFiftyFiftyQuestionQuery : IRequest<QuestionDto>
    {
        public int QuestionId { get; set; }
    }
}
