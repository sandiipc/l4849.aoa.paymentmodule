using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);

    }
}
