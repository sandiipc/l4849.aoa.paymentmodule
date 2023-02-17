using Microsoft.EntityFrameworkCore;
using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Data
{
    public class PaymentLogDbContext : DbContext
    {
        public PaymentLogDbContext(DbContextOptions<PaymentLogDbContext> options): base(options)
        {

        }


        public DbSet<Owner> Owners { get; set; }
        public DbSet<PaymentLog> PaymentLogs { get; set; }



    }
}
