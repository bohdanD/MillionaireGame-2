using MediatR;
using MillionaireGame.Question.Application.DataContracts;
using MillionaireGame.Question.Application.Questions.Models;
using System;
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
            throw new NotImplementedException();
        }
    }
}
