using Api.Domain.Commands;
using Api.Domain.Entities;
using Api.SharedKernel;
using Api.SharedKernel.Interfaces;
using System;
using System.Threading.Tasks;

namespace Api.Application.Commands
{
    public class CreateMessageCommandHandler : ICommandHandler<CreateMessageCommand>
    {
        private readonly IDbContext _dbContext;
        private readonly IDispatcher _dispatcher;

        public CreateMessageCommandHandler(IDbContext dbContext, IDispatcher dispatcher)
        {
            _dbContext = dbContext;
            _dispatcher = dispatcher;

        }
        public async Task<OperationResult> HandleAsync(CreateMessageCommand command)
        {
            var userId = await _dispatcher.DoAsync(command.User);

            var message = new Message()
            {
                Id = Guid.NewGuid(),
                Ammount = command.Amount,
                Currency = command.Currency,
                Date = DateTime.Now,
                OrderId = command.OrderId,
                MessageText = command.MessageText,
                UserId = userId.EntityId
            };

            await _dbContext.CreateAsync(message);

            await _dbContext.SaveChangesAsync();

            return new OperationResult(message.Id);
        }
    }
}