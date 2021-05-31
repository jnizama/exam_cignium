using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PremiumCalculator.Data.Entities;
using PremiumCalculator.Data.Repository;

namespace PremiumCalculator.Data.Domain
{
    /*
        I use Domain Design Drive to implement business logic (DDD)
    */
    public class PaymentApplication : IPaymentApplication
    {
        private PaymentRepository paymentRepository;        
        public PaymentApplication()
        {            
            paymentRepository = new PaymentRepository();
        }
        public IList<Payment> getListPayment(string DateOfBirth, string State, string Age)
        {      
            //validations on input data
            var dateOfBirthFormated = new DateTime();
            var ageInt = convertDateOfBirth(Age);
            validDataInput(DateOfBirth, State, Age);
            if(DateOfBirth != "*")
            {
                dateOfBirthFormated = validFormatDateOfBirth(DateOfBirth);
                ageInt = validDateOfBirth(ageInt, dateOfBirthFormated);
            }
            

            //getting data and applying logical conditionals
            var dataSetPayments = paymentRepository.Get();
            var dataSetPaymentsState = dataSetPayments.Where(x => x.State.ToLower().Contains(State.ToLower()));
            var monthOfBirth = dataSetPaymentsState.Where(
                                x=>x.MonthOfBirth == dateOfBirthFormated.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"))
                                );
                           
            var dateOfBirthLiteral = monthOfBirth.Any() && DateOfBirth != "*" ? monthOfBirth.FirstOrDefault().MonthOfBirth : "*";            
            var dataSetPaymentsMonth = dataSetPaymentsState.Where(
                                            x => x.MonthOfBirth == dateOfBirthLiteral
                                         );
            var dataSetPaymentsRangeAge = dataSetPaymentsMonth.Where(x=>x.AgeMinimum <= ageInt && x.AgeMaximum >= ageInt);

            //return data result
            return dataSetPaymentsRangeAge.ToList();
        }
        private DateTime validFormatDateOfBirth(string DateOfBirth)
        {
            try{
                var dteOfBirth = DateOfBirth == "*" ? DateTime.Today : DateTime.ParseExact(DateOfBirth, "dd/MM/yyyy", null);   
                return dteOfBirth;
            }
            catch(FormatException ex)
            {
                //return new DateTime(1900,01,01);
                throw new Exception(ex.Message);
            }            
        }
        private int convertDateOfBirth(string Age)
        {
            var ageInt = 0;            
            if(!int.TryParse(Age, out ageInt)) throw new Exception("Age was not recognized as a valid integer");
            return ageInt;
        }
        private int validDateOfBirth(int Age, DateTime DateOfBirth)
        {
            if(getAge(DateOfBirth) != Age)
            {
                throw new Exception("Age not make matching to DateOfBirth");
            }
            return Age;
            // var result = DateTime.Today;           
            // var birth = result.Subtract(DateOfBirth);
            // //var birth = result.Year - DateOfBirth.Year;
            // var ne = new DateTime(birth.Ticks);
            // if(ne.Year != Age) throw new Exception("Age not make matching to DateOfBirth");
            // return Age;
        }
        private int getAge(DateTime DateOfBirth)
        {
            var today = DateTime.Today;
            var dayToday = (today.Year * 100 + today.Month) * 100 + today.Day;
            var dayDateOfBirth = (DateOfBirth.Year * 100 + DateOfBirth.Month) * 100 + DateOfBirth.Day;
            return (dayToday - dayDateOfBirth) / 10000;
        }
        private void validDataInput(string DateOfBirth, string State, string Age)
        {
            if(DateOfBirth == null || DateOfBirth == string.Empty)
                throw new Exception("DateOfBirth was not supply as a valid value");
            if(State == null || State == string.Empty)
                throw new Exception("State was not supply as a valid value");
            if(Age == null || Age == string.Empty)
                throw new Exception("Age was not supply as a valid value");
        }
    }
}