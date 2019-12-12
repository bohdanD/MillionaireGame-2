using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MillionaireGame.Question.Application.Answers.Queries;
using MillionaireGame.Question.Application.Models;
using MillionaireGame.Question.Application.Questions.Queries;

namespace MillionaireGame.Question.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{userId}/{complexity}")]
        [HttpGet]
        public async Task<QuestionDto> GetQuestionAsync(int userId, int complexity)
        {
            var query = new GetQuestionQuery { CopmlexityId = complexity, UserId = userId };
            var result = await _mediator.Send(query);
            return result;
        }

        [Route("{userId}/answer/{questionId}")]
        [HttpGet]
        public async Task<AnswerDto> GetAnswerAsync(int userId, int questionId)
        {
            var query = new GetCorrectAnswerQuery { UserId = userId, QuestionId = questionId };
            return await _mediator.Send(query);
        }

    }
}
