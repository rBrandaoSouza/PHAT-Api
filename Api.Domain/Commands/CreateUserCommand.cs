using Api.SharedKernel.Interfaces;

namespace Api.Domain.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PayerId { get; set; }
    }
}
