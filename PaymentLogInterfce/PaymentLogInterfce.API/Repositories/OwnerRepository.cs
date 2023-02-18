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

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await this.paymentLogDbContext.Owners.ToListAsync();

        }



    }
}
