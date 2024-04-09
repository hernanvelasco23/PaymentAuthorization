namespace PaymentAuthorization.Models
{
    // Clase que representa la solicitud de autorización de pago
    public class AuthorizationRequest
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public PaymentType PaymentType { get; set; }  // Cobro, devolución o reversa
        // Otros campos necesarios para la solicitud de autorización

        // Constructor
        public AuthorizationRequest(string transactionId, decimal amount, string currency, PaymentType paymentType)
        {
            TransactionId = transactionId;
            Amount = amount;
            Currency = currency;
            PaymentType = paymentType;
        }
    }
    // Enum para el tipo de pago
    public enum PaymentType
    {
        Charge,
        Refund,
        Reversal
    }
}


