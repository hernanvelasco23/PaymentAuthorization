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
        // Agrega otras DbSet para las demás entidades si las tienes

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Puedes configurar aquí las relaciones y restricciones de la base de datos
        }
    }
}