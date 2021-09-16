using Api.SharedKernel.Interfaces;

namespace Api.Domain.Queries
{
    public class GetAllUsersFilter : IQuery
    {
        public string Login { get; set; }

        public GetAllUsersFilter(string login)
        {
            Login = login;
        }
    }


}
