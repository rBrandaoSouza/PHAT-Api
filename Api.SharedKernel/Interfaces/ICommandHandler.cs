using System.Threading.Tasks;

namespace Api.SharedKernel.Interfaces
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task<OperationResult> HandleAsync(TCommand command);
    }
}