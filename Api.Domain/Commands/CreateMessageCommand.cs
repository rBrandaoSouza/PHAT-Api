using Api.Domain.Entities;
using Api.SharedKernel.Interfaces;

namespace Api.Domain.Commands
{
    public class CreateMessageCommand : ICommand
    {
        public string Name { get; set; }
        public string MessageText { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string OrderId { get; set; }
        public CreateUserCommand CreateUserCommand{ get; set; }

    }
}
