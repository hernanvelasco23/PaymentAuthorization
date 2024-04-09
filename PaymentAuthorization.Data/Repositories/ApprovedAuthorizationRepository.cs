using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PaymentAuthorization.Data.Entities;

namespace PaymentAuthorization.Data.Repositories
{
    public class ApprovedAuthorizationRepository : IApprovedAuthorizationRepository
    {
        private readonly PaymentAuthorizationDbContext _context;

        public ApprovedAuthorizationRepository(PaymentAuthorizationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ApprovedAuthorization authorization)
        {

            _context.ApprovedAuthorizations.Add(authorization);
            await _context.SaveChangesAsync();
            
        }
    }
}
