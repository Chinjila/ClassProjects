// See https://aka.ms/new-console-template for more information
using MortagageLib;

Stack<Mortgage> mortgages = new();
mortgages.Push(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.FifteenYears,200000,0.65M)

);

mortgages.Push(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.FifteenYears, 300000, 0.065M)

);
mortgages.Push(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.FifteenYears, 400000, 0.065M)
);
Console.WriteLine(mortgages.Pop().Payments.Sum(p => p.InterestAmount));
Console.WriteLine(mortgages.Pop().Payments.Sum(p => p.InterestAmount));
Console.WriteLine(mortgages.Pop().Payments.Sum(p => p.InterestAmount));

Queue<Mortgage> mortgages2 = new();
mortgages2.Enqueue(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.FifteenYears, 200000, 0.065M)

);

mortgages2.Enqueue(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.ThirtyYears, 200000, 0.065M)

);
mortgages2.Enqueue(new Mortgage(DateTime.Now.AddMinutes(3), MortgageDuration.FifteenYears, 400000, 0.065M)
);
Console.WriteLine(mortgages2.Dequeue().Payments.Sum(p => p.InterestAmount));
Console.WriteLine(mortgages2.Dequeue().Payments.Sum(p => p.InterestAmount));
Console.WriteLine(mortgages2.Dequeue().Payments.Sum(p => p.InterestAmount));