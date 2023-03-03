using Microsoft.EntityFrameworkCore;
using PaymentLogInterfce.API.Data;
using PaymentLogInterfce.API.Models.Domain;
//using PaymentLogInterfce.API.Models.DTO;

namespace PaymentLogInterfce.API.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PaymentLogDbContext paymentLogDbContext;

        public OwnerRepository(PaymentLogDbContext paymentLogDbContext)
        {
            this.paymentLogDbContext = paymentLogDbContext;
        }

        public async Task<Owner> AddOwnerAsync(Owner owner)
        {
            await this.paymentLogDbContext.AddAsync(owner);
            await this.paymentLogDbContext.SaveChangesAsync();

            return owner;
        }

        public async Task<Owner> DeleteOwnerAsync(string ownerCode)
        {
            var owner = await this.paymentLogDbContext.Owners.FirstOrDefaultAsync(x => x.OwnerCode == ownerCode && x.IsDeleted == "N");

            if(owner == null)
            {
                return null;
            }

            owner.IsDeleted = "Y";
            await this.paymentLogDbContext.SaveChangesAsync();

            return owner;

        }

        public async Task<IEnumerable<Owner>> GetAllActiveOwnersAsync()
        {
            return await this.paymentLogDbContext.Owners.Where(x => x.IsDeleted == "N").ToListAsync();

        }

        public async Task<Owner> GetActiveOwnerByIdAsync(string ownerCode)
        {

            return await this.paymentLogDbContext.Owners.Where(x => x.OwnerCode == ownerCode && x.IsDeleted == "N").FirstOrDefaultAsync();

        }

        public async Task<Owner> UpdateOwnerAsync(string ownerCode, Owner owner)
        {

            var existingOwner = await this.paymentLogDbContext.Owners.FirstOrDefaultAsync(x => x.OwnerCode == ownerCode && x.IsDeleted == "N");

            if (existingOwner == null)
            {
                return null;
            }

            existingOwner.FirstName = owner.FirstName; 
            existingOwner.LastName = owner.LastName;
            existingOwner.MobileNo= owner.MobileNo;
            existingOwner.Email = owner.Email;

            this.paymentLogDbContext.SaveChanges();

            return existingOwner;

        }

        public async Task<Owner> AuthenticateAsync(string username, string password)
        {

            return await this.paymentLogDbContext.Owners.FirstOrDefaultAsync(x=> x.UserName.ToLower() == username.ToLower() && x.Password == password);


        }


    }
}
