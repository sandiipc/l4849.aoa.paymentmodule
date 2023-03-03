using Microsoft.EntityFrameworkCore;
using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Data
{
    public class PaymentLogDbContext : DbContext
    {
        public PaymentLogDbContext(DbContextOptions<PaymentLogDbContext> options): base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner_Role>()
                .HasOne(o => o.Owner)
                .WithMany(x => x.OwnerRoles)
                .HasForeignKey(y => y.OwnerId);


            modelBuilder.Entity<Owner_Role>()
                .HasOne(r => r.Role)
                .WithMany(a => a.OwnerRoles)
                .HasForeignKey(b => b.RoleId);

            modelBuilder.Entity<PaymentLog>()
                .HasOne(o => o.Owner)
                .WithMany(x => x.PaymentLogs)
                .HasForeignKey(y => y.OwnerId);


        }


        public DbSet<Owner> Owners { get; set; }
        public DbSet<PaymentLog> PaymentLogs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Owner_Role> Owners_Roles { get; set; }


    }
}
