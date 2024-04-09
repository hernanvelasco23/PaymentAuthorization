using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentAuthorization.Data.Entities;

namespace PaymentAuthorization.Data.Repoditories
{
    public interface IPaymentRequestRepository
    {
        Task<IEnumerable<PaymentRequest>> GetAllAsync();
        Task<PaymentRequest> GetByIdAsync(int id);
        Task AddAsync(PaymentRequest paymentRequest);
        Task UpdateAsync(PaymentRequest paymentRequest);
        Task DeleteAsync(int id);
        Task AddOrUpdateAsync(PaymentRequest paymentRequest);
    }
}
