using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentAuthorization.Data.Entities;

namespace PaymentAuthorization.Data.Repositories
{
    public interface IApprovedAuthorizationRepository
    {
        Task AddAsync(ApprovedAuthorization authorization);
    }
}
