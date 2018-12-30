using MediatR;
using MillionaireGame.Question.Application.Questions.Models;

namespace MillionaireGame.Question.Application.Questions.Queries
{
    public class GetQuestionQuery : IRequest<QuestionDto>
    {
        public int CopmlexityId { get; set; }
    }
}
