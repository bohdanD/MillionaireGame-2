using MediatR;
using MillionaireGame.Question.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MillionaireGame.Question.Application.Questions.Queries
{
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, Domain.Question>
    {
        public Task<Domain.Question> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
