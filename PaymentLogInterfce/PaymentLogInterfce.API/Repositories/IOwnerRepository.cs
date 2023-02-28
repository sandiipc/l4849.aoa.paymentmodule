using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Repositories
{
    public interface IOwnerRepository
    {

        Task<IEnumerable<Owner>> GetAllActiveOwnersAsync();

        Task<Owner> GetActiveOwnerByIdAsync(string ownerId);

        Task<Owner> AddOwnerAsync(Owner owner);

        Task<Owner> UpdateOwnerAsync(string ownerId, Owner owner);

        Task<Owner> DeleteOwnerAsync(string ownerId);

    }
}
