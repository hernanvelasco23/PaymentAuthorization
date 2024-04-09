using PaymentAuthorization.Data.Entities;
using PaymentAuthorization.Data.Repoditories;
using PaymentAuthorization.Data.Repositories;

namespace PaymentAuthorization.Services
{
    public class PaymentProcessorService
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IApprovedAuthorizationRepository _approvedAuthRepository;

        public PaymentProcessorService(IPaymentRequestRepository paymentRequestRepository, IApprovedAuthorizationRepository approvedAuthRepository)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _approvedAuthRepository = approvedAuthRepository;
        }

        public async Task<bool> ProcessAuthorizationAsync(PaymentRequest request)
        {
            bool isAuthorized = request.Amount % 1 == 0;

            request.Status = isAuthorized ? RequestStatus.Approved : RequestStatus.Rejected;
            request.IsConfirmed = isAuthorized;

            await _paymentRequestRepository.AddOrUpdateAsync(request);

            if (isAuthorized)
            {
                await RegisterApprovedAuthorizationAsync(request);
            }

            if(request.ClientType == ClientType.Premium && !isAuthorized)
            { 
                await ProcessPremiumAuthorizationAsync(request);
            }

            return isAuthorized;
        }
        private async Task ProcessPremiumAuthorizationAsync(PaymentRequest request)
        {
            var reversalScheduleTime = DateTime.UtcNow.AddMinutes(5);

            await Task.Run(async () =>
            {
                var delayTime = reversalScheduleTime - DateTime.UtcNow;

                await Task.Delay(delayTime);

                var requestScheduled = await _paymentRequestRepository.GetByIdAsync(request.Id);

                if (requestScheduled != null && !requestScheduled.IsConfirmed)
                {
                    requestScheduled.Status = RequestStatus.ScheduledReversal;

                    await _paymentRequestRepository.UpdateAsync(requestScheduled);
                }
            });

        }
        private async Task RegisterApprovedAuthorizationAsync(PaymentRequest request)
        {
            ApprovedAuthorization approvedAuthorization = new ()
            {
                AuthorizationDate = DateTime.UtcNow,
                Amount = request.Amount,
                ClientId = request.ClientId
            };
            await _approvedAuthRepository.AddAsync(approvedAuthorization);
        }
        public enum AuthorizationStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }
    
}

