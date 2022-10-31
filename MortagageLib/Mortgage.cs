using System.Reflection.Emit;

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

        public Mortgage(MortgageLength length, DateTime OriginationDate)
        {
            throw new NotImplementedException();
            if (OriginationDate < DateTime.Now)
            { throw new ArgumentException();}
        }
        public Payment CalculateMonthlyPayment(DateTime maturityDate)
        { throw new NotImplementedException(); }
        public Payment CalculateMonthlyPayment(int numberOfPayments)
        { throw new NotImplementedException(); }

        public List<Payment> GetAmortizationSchedule(DateTime maturityDate)
        { throw new NotImplementedException(); }
        public List<Payment> GetAmortizationSchedule(int numberOfPayments)
        { throw new NotImplementedException(); }
        


    }

    public enum MortgageType
    {
        FixRate,
        AdjustableRate
    }

    public enum MortgageLength
    {
        FifteenYear,
        ThirtyYear
    }
}