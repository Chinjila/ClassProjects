namespace MortagageLib
{
    public class Payment
    {
        public Payment(int paymentNumber, decimal principalAmount, decimal interestAmount, decimal loanBalance, decimal payment, DateTime paymentDate)
        {
            PaymentNumber = paymentNumber;
            PrincipalAmount = principalAmount;
            InterestAmount = interestAmount;
            LoanBalance = loanBalance;
            PaymentAmount = payment;
            PaymentDate = paymentDate;
        }

        public int PaymentNumber { get; }
        public decimal PrincipalAmount { get; }
        public decimal InterestAmount { get; }
        public decimal LoanBalance { get; }
        public decimal PaymentAmount{ get; }
        public DateTime PaymentDate { get; }
    }
}