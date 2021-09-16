using Api.Application.Commands;
using Api.Application.Queries;
using Api.Domain.Commands;
using Api.Domain.Queries;
using Api.SharedKernel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Api.Application
{
    public static class IoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddScoped<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();
            services.AddScoped<ICommandHandler<CreateMessageCommand>, CreateMessageCommandHandler>();

            services.AddScoped<IQueryHandler<GetAllUsersFilter, IEnumerable<GetAllUsersResult>>, GetAllUsersQueryHandler>();
            services.AddScoped<IQueryHandler<GetMessagesFilter, IEnumerable<GetMessagesResult>>, GetMessagesQueryHandler>();
        }
    }
}
