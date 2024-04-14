using Microsoft.EntityFrameworkCore;
using PaymentAuthorization.Data.Entities;

namespace PaymentAuthorization.Data
{
    public class PaymentAuthorizationDbContext : DbContext
    {
        public PaymentAuthorizationDbContext(DbContextOptions<PaymentAuthorizationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PaymentRequest> PaymentRequests { get; set; }
        public DbSet<ApprovedAuthorization> ApprovedAuthorizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}