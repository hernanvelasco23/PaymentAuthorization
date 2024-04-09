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

        private readonly PaymentProcessorService _paymentProcessorService;

        public PaymenController(PaymentProcessorService paymentProcessorService)
        {
            _paymentProcessorService = paymentProcessorService ?? throw new ArgumentNullException(nameof(paymentProcessorService));
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
