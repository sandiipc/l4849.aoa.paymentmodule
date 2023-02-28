using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Repositories
{
    public interface IUserRepository
    {

        Task<User> AuthenticateAsync(string username, string password);

    }
}
