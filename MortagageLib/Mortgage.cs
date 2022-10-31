namespace MortagageLib
{
    public class Mortgage
    {
        public DateTime OriginationDate;
        public decimal OriginalPrincipalAmount;
        public decimal CurrentPrincipal;
        public decimal OriginalInterestRate;
        public MortgageType MortgageType;
        public List<Payment> Payments;

        public Payment CalculateMonthlyPayment(DateTime maturityDate)
        { throw new NotImplementedException(); }
        public Payment CalculateMonthlyPayment(int numberOfPayments)
        { throw new NotImplementedException(); }

        public List<Payment> GetAmortizationSchedule(DateTime maturityDate)
        { throw new NotImplementedException(); }
        public List<Payment> GetAmortizationSchedule(int numberOfPayments)
        { throw new NotImplementedException(); }

        //create a constructor that accept the origination date and an enum
        // for 15 or 30 year, throw exception if origination < today - in the past
        public Mortgage(DateTime mortgageOriginationDate, MortgageDuration duration)
        {
            if (mortgageOriginationDate < System.DateTime.Now) {
                throw new Exception("Mortgage can not be originated in the past.");
            }
            // right click solution -> Add -> New Project -> search for MSTest Project
            // Name the project MortgageLibTest
            // delete UnitTest1.cs

            // right click on MortgageLibTest, select Add -> Project Reference so we can
            // instantiate the Mortgage class.
            // 
            // Right click on MortgageLibTest, add->class
            // make sure to call the test class file [classUnderTest]test.cs
            // referece the content of
            // https://github.com/Chinjila/ClassProjects/blob/51cd7400fbdac472d6bc2380dcbea2043203340b/MortgageLibTest/MortgageTest.cs

            // top menu-> Test -> Run All Tests
            Payments = new List<Payment>();

            //switch (duration)
            //{
            //    case MortgageDuration.FifteenYears:
            //        {
            //            for (int i = 0; i < 180; i++)
            //            {
            //                Payments.Add(new Payment());
            //            }
            //            break;
            //        }
            //    case MortgageDuration.ThirtyYears:
            //        {
            //            for (int i = 0; i < 360; i++)
            //            {
            //                Payments.Add(new Payment());
            //            }
            //            break;
            //        }
            //    default:
            //        break;
            //}

            for (int i = 0; i < (int) duration; i++)
            {
                Payments.Add(new Payment());
            }
        }


    }

    public enum MortgageType
    {
        FixRate,
        AdjustableRate
    }

    // Create enum for 15 Year Mortgage and 30 Year Mortgage
    public enum MortgageDuration
    { 
        FifteenYears=180,
        ThirtyYears=360
    }
}