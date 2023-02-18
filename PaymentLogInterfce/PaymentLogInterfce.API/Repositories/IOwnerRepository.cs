using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Repositories
{
    public interface IOwnerRepository
    {

        Task<IEnumerable<Owner>> GetAllAsync();



    }
}
