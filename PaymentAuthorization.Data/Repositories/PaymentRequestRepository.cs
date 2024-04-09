using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PaymentAuthorization.Data.Entities;

namespace PaymentAuthorization.Data.Repoditories
{
    public class PaymentRequestRepository : IPaymentRequestRepository
    {
        private readonly PaymentAuthorizationDbContext _dbContext;

        public PaymentRequestRepository(PaymentAuthorizationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(PaymentRequest paymentRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PaymentRequest>> GetAllAsync()
        {
            throw new NotImplementedException();
           
        }

        public async Task<PaymentRequest> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.PaymentRequests.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateAsync(PaymentRequest paymentRequest)
        {
            try
            {
               
                    _dbContext.PaymentRequests.Update(paymentRequest);
                    await _dbContext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task AddOrUpdateAsync(PaymentRequest paymentRequest)
        {
            try
            {

                _dbContext.PaymentRequests.Add(paymentRequest);
                    await _dbContext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
