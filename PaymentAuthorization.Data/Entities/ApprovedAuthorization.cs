using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAuthorization.Data.Entities
{
    public class ApprovedAuthorization
    {
        public int Id { get; set; }
        public DateTime AuthorizationDate { get; set; }
        public decimal Amount { get; set; }
        public string ClientId { get; set; }
    }
}
