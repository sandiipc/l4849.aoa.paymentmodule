using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Repositories
{
    public interface IOwnerRepository
    {

        Task<IEnumerable<Owner>> GetAllActiveOwnersAsync();
        Task<Owner> GetActiveOwnerByIdAsync(string ownerCode);
        Task<Owner> AddOwnerAsync(Owner owner);
        Task<Owner> UpdateOwnerAsync(string ownerCode, Owner owner);
        Task<Owner> DeleteOwnerAsync(string ownerCode);
        Task<Owner> AuthenticateAsync(string username, string password);

    }
}
