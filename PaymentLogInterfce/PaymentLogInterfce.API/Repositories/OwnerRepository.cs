using Microsoft.EntityFrameworkCore;
using PaymentLogInterfce.API.Data;
using PaymentLogInterfce.API.Models.Domain;

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

        public async Task<Owner> DeleteOwnerAsync(string  ownerCode)
        {
            var owner = await this.paymentLogDbContext.Owners.FirstOrDefaultAsync(x => x.OwnerCode == ownerCode);

            if(owner == null)
            {
                return null;
            }

            this.paymentLogDbContext.Owners.Remove(owner);
            await this.paymentLogDbContext.SaveChangesAsync();

            return owner;

        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await this.paymentLogDbContext.Owners.ToListAsync();

        }

        public async Task<Owner> GetByIdAsync(string ownerCode)
        {
            return await this.paymentLogDbContext.Owners.FirstOrDefaultAsync(x => x.OwnerCode == ownerCode);
        }

        public async Task<Owner> UpdateOwnerAsync(string ownerCode, Owner owner)
        {

            var existingOwner = await this.paymentLogDbContext.Owners.FirstOrDefaultAsync(x => x.OwnerCode == ownerCode);

            if (existingOwner == null)
            {
                return null;
            }

            existingOwner.FirstName = owner.FirstName; 
            existingOwner.LastName = owner.LastName;
            existingOwner.MobileNo= owner.MobileNo;
            existingOwner.Email = owner.Email;
            existingOwner.TowerNo= owner.TowerNo;
            existingOwner.FlatNo  = owner.FlatNo;


            this.paymentLogDbContext.SaveChanges();

            return existingOwner;

        }
    }
}
