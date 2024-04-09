using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAuthorization.Data.Entities
{

    

    [Table("PaymentRequests")]
    public class PaymentRequest
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public AuthorizationType Type { get; set; }
        public RequestStatus Status { get; set; }

        //tipo de cliente para procesar autorizacion, por simplicidad lo pongo aca en el request, se podria sacar
        //de la base de datos de la tabla clientes
        public ClientType ClientType { get; set; } 
    }

    public enum RequestStatus
    {
        Pending,        // Pendiente
        Approved,       // Aprobada
        Rejected,       // Rechazada
        ScheduledReversal, // Programada para Reversa
                           // Otros estados que necesites
    }
    public enum AuthorizationType
    {
        Charge,
        Refund,
        Reversal
    }

    public enum ClientType
    {
        Regular,
        Premium,
    }

    public class ConfirmedAuthorizationRequest : PaymentRequest
    {
        public string ConfirmationCode { get; set; }
    }
}
