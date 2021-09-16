using Api.SharedKernel.Interfaces;
using System;

namespace Api.Domain.Entities
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public decimal Ammount { get; set; }
        public string MessageText { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
