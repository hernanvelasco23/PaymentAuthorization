using System.Net;
using Microsoft.AspNetCore.Mvc;
using PaymentAuthorization.Services;
using PaymentAuthorization.Data.Entities;

namespace PaymentAuthorization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymenController : ControllerBase
    {

        private readonly IPaymentProcessorService _paymentProcessorService;

        public PaymenController(IPaymentProcessorService paymentProcessorService)
        {
            _paymentProcessorService = paymentProcessorService;
        }

        [HttpPost]
        public async Task<ActionResult<Authorization>> AuthorizePayment([FromBody] PaymentRequest request)
        {
            var result = await _paymentProcessorService.ProcessAuthorizationAsync(request);
            if (result)
            {
                return Ok("Authorization successful");
            }
            else
            {
                return BadRequest("Authorization failed");
            }
        }
    }
}
