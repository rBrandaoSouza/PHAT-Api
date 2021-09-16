using Api.Domain.Entities;
using Api.Domain.Queries;
using Api.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Application.Queries
{
    public class GetMessagesQueryHandler : IQueryHandler<GetMessagesFilter, IEnumerable<GetMessagesResult>>
    {
        private readonly IDbContext _dbContext;

        public GetMessagesQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetMessagesResult>> HandleAsync(GetMessagesFilter filter)
        {
            //if (filter.Page > 0)
            var messages = _dbContext.GetQueryable<Message>()
                .Select(x => new GetMessagesResult
                {
                    Message = x.MessageText
                })
                .Skip((filter.Skip - 1) * filter.Take)
                .Take(filter.Take);

            return await messages.ToListAsync();
        }
    }
}
