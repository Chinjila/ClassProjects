namespace MortagageLib
{
    public class Mortgage
    {

        public decimal OriginalPrincipalAmount;
        public decimal CurrentPrincipal;
        public decimal OriginalInterestRate;
        public MortgageType MortgageType;
        public List<Payment> Payments;
        public DateTime OriginationDate;

        public Payment CalculateMonthlyPayment(DateTime maturityDate)
        { throw new NotImplementedException(); }
        public Payment CalculateMonthlyPayment(int numberOfPayments)
        { throw new NotImplementedException(); }

        public List<Payment> GetAmortizationSchedule(DateTime maturityDate)
        { throw new NotImplementedException(); }
        public List<Payment> GetAmortizationSchedule(int numberOfPayments)
        { throw new NotImplementedException(); }

        public Mortgage(DateTime mortgageOriginationDate, MortgageDuration duration)
        {
            if (mortgageOriginationDate < System.DateTime.Now)
            {
                throw new Exception("Mortgage cannot be originated in the past");
            }
        }


    }

    public enum MortgageType
    {
        FixRate,
        AdjustableRate
    }

    //Create enum for 15 year mortgage and 30 year mortgage
    public enum MortgageDuration
    {
        FifteenYears,
        ThirtyYears
    }

}