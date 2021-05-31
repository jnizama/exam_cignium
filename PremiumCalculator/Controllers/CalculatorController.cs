using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PremiumCalculator.Data.Domain;
using PremiumCalculator.Data.Entities;


namespace PremiumCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        //Using dependency injection
        private IPaymentApplication PaymentApplication;

        public CalculatorController(IPaymentApplication PaymentApplication)
        {
            this.PaymentApplication = PaymentApplication;
        }
        [HttpPost]
        [Route("GetPayment")]
        public ActionResult<Payment> Get(String DateOfBirth, String State, String Age)
        {
            try{
                var result = PaymentApplication.getListPayment(DateOfBirth, State, Age);
                if(result.Any()){
                    var premium = result.FirstOrDefault().Premium;                    
                    return Ok(new PaymentResult() { Premium = premium } );

                }
                return Ok(new PaymentResult() {Premium = 0.00 } );
            }catch(Exception ex)
            {
                return NotFound(ex.Message); //put this constants in language resources
            }

        }       
    }
}
