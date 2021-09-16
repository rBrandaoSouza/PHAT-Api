using Api.Domain.Commands;
using Api.Domain.Queries;
using Api.Helpers;
using Api.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IDispatcher dispatcher;

        public MessageController(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(GetMessagesFilter filter)
        {
            var messages = await this.dispatcher.GetAsync<IEnumerable<GetMessagesResult>>(filter);

            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateMessageCommand command)
        {
            var operationResult = await dispatcher.DoAsync(command);

            return this.SwitchResult(operationResult);
        }


    }
}
