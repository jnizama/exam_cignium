using System.Collections.Generic;
using PremiumCalculator.Data.Entities;

namespace PremiumCalculator.Data.Repository
{
    /*
        Our reposity class used regurarly to access Datatabase
        (Entity framework, ADO, Enterpriselibrary, NHibernate, etc...)
        Except for this assignment (Tranzact Coding Challenge) I use static data
    */
    public class PaymentRepository
    {
        private IList<Payment> listPayments;
        public PaymentRepository()
        {
            listPayments = new List<Payment>();
        }
        //Get static data
        public IList<Payment> Get()
        {
            listPayments.Add(new Payment("NY", "August", 18, 45, 150));
            listPayments.Add(new Payment("NY", "January", 46, 65, 200.50));
            listPayments.Add(new Payment("NY", "*", 18, 65, 120.99));
            listPayments.Add(new Payment("AL", "November", 18, 65, 85.5));
            listPayments.Add(new Payment("AL", "*", 18, 65, 100));
            listPayments.Add(new Payment("AK", "December", 65, 999, 175.20));
            listPayments.Add(new Payment("AK", "December", 18, 64, 125.16));
            listPayments.Add(new Payment("AK", "*", 18, 65, 100.80));
            listPayments.Add(new Payment("*", "*", 18, 65, 90));
            return listPayments;
        }
    }
}