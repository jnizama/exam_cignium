
namespace PremiumCalculator.Data.Entities
{
    /*
        Class Payment
    */
    public class Payment
    {
        public string State { get;set; }
        public string MonthOfBirth { get;set; }
        public int AgeMinimum { get;set; }
        public int AgeMaximum { get;set; }
        public double Premium { get;set; }

        public Payment(string State, string MonthOfBirth, int AgeMinimum, int AgeMaximum, double Premium)
        {
            this.State = State;
            this.MonthOfBirth = MonthOfBirth;
            this.AgeMinimum = AgeMinimum;
            this.AgeMaximum = AgeMaximum;
            this.Premium = Premium;
        }
    }
}