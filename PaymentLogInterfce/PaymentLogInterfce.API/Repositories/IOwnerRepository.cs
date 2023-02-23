using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Repositories
{
    public interface IOwnerRepository
    {

        Task<IEnumerable<Owner>> GetAllAsync();

        Task<Owner> GetByIdAsync(string ownerCode);

        Task<Owner> AddOwnerAsync(Owner owner);

        Task<Owner> UpdateOwnerAsync(string ownerCode, Owner owner);

        Task<Owner> DeleteOwnerAsync(string ownerCode);

    }
}
