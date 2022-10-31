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

        public Mortgage(DateTime mortagageOriginationDate, LoanTerms terms)
        {
            if(mortagageOriginationDate < System.DateTime.Now)
            {
                throw new Exception("Start time cannot be in the past.");
            }
        }
    }

    public enum MortgageType
    {
        FixRate,
        AdjustableRate
    }

    public enum LoanTerms
    {
        FifteenYears,
        ThirtyYears
    }
}