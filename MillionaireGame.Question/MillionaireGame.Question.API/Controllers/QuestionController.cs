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
        // GET api/values
        [HttpGet]
        public async Task<QuestionDto> Get()
        {
            var query = new GetQuestionQuery { CopmlexityId = 1 };
            var result = await _mediator.Send(query);
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
