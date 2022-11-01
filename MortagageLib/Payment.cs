namespace MortagageLib
{
    public class Payment
    {
        public Payment(int paymentNumber, decimal principalAmount, decimal interestAmount, decimal loanBalance, decimal payment)
        {
            PaymentNumber = paymentNumber;
            PrincipalAmount = principalAmount;
            InterestAmount = interestAmount;
            LoanBalance = loanBalance;
            PaymentAmount = payment;
        }

        public int PaymentNumber { get; }
        public decimal PrincipalAmount { get; }
        public decimal InterestAmount { get; }
        public decimal LoanBalance { get; }
        public decimal PaymentAmount{ get; }
    }
}