using System;

namespace Api.Domain.Queries
{
    public class GetMessagesResult
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public decimal Ammount { get; set; }
    }
}
