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
        //create a constructor that accept the origination date and an enum
        // for 15 or 30 years, throw exception if origination date < today - in the past

    }hi nate

    public enum MortgageType
    {
        FixRate,
        AdjustableRate
    }

    public enum 

    //create enum for 15 year mortgage & 30 year mortgage


}