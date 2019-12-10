using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async Task<QuestionDto> Get(int id)
        {
            var query = new GetQuestionQuery { CopmlexityId = 1, UserId = id };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
