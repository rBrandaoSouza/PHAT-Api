using System.Threading.Tasks;

namespace Api.SharedKernel.Interfaces
{
    public interface IDispatcher
    {
        Task<OperationResult> DoAsync(ICommand command);
        Task<T> GetAsync<T>(IQuery query);
    }
}
