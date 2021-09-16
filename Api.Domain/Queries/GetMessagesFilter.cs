using Api.SharedKernel.Interfaces;

namespace Api.Domain.Queries
{
    public class GetMessagesFilter : IQuery
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
