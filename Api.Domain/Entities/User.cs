using Api.SharedKernel.Interfaces;
using System;

namespace Api.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PayerId { get; set; }

        public virtual Message Message { get; set; }
    }
}
