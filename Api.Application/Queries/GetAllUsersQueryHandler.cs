using Api.Domain.Entities;
using Api.Domain.Queries;
using Api.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Application.Queries
{
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersFilter, IEnumerable<GetAllUsersResult>>
    {

        private readonly IDbContext dbContext;

        public GetAllUsersQueryHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetAllUsersResult>> HandleAsync(GetAllUsersFilter filter)
        {
            var users = dbContext.GetQueryable<User>();

            if(string.IsNullOrEmpty(filter?.Login))
            {
                //users = users.Where(user => user.Login.Contains(filter.Login));
            }


            var selectedUsers = users.Select(user => new GetAllUsersResult
            {
                //Login = user.Login
            });

            return await selectedUsers.ToListAsync();
        }
    }
}
