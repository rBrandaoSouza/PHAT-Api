using Api.Application.Commands;
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
    public class UserController : ControllerBase
    {
        private readonly IDispatcher dispatcher;

        public UserController(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string name)
        {
            var users = await this.dispatcher.GetAsync<IEnumerable<GetAllUsersResult>>(new GetAllUsersFilter(name));

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserCommand command)
        {
            var operationResult = await dispatcher.DoAsync(command);

            return this.SwitchResult(operationResult);
        }


    }
}
