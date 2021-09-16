using Api.Domain.Commands;
using Api.Domain.Entities;
using Api.SharedKernel;
using Api.SharedKernel.Interfaces;
using System;
using System.Threading.Tasks;

namespace Api.Application.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IDbContext dbContext;

        public CreateUserCommandHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<OperationResult> HandleAsync(CreateUserCommand command)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                Adress = command.Adress,
                PayerId = command.PayerId
            };

            await dbContext.CreateAsync(user);

            await dbContext.SaveChangesAsync();

            return new OperationResult(user.Id);
        }
    }
}
