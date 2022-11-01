// See https://aka.ms/new-console-template for more information
using MortagageLib;

Stack<Mortgage> mortgages = new();
mortgages.Push(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.FifteenYears,200000,0.65M)

);

mortgages.Push(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.FifteenYears, 300000, 0.065M)

);
mortgages.Push(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.FifteenYears, 400000, 0.065M)
);
foreach (var item in mortgages.Pop().GetYearlyAmortization())
{
    Console.WriteLine($"{item.Year} paid {item.TotalPrincipal.ToString("C2")} principal and {item.TotalInterest.ToString("C2")} interest");
}

