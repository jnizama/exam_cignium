using System.Collections.Generic;
using PremiumCalculator.Data.Entities;

namespace PremiumCalculator.Data.Domain
{
    /*
        I use Domain Design Drive to implement business logic (DDD)
    */
    public interface IPaymentApplication
    {
        public IList<Payment> getListPayment(string DateOfBirth, string State, string Age);
    }
}
