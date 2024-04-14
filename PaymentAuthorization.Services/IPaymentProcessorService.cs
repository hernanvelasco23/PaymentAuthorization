using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentAuthorization.Data.Entities;

namespace PaymentAuthorization.Services
{
    public interface IPaymentProcessorService
    {
        public Task<bool> ProcessAuthorizationAsync(PaymentRequest request);
    }
}
