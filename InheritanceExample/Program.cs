// See https://aka.ms/new-console-template for more information
using InheritanceExample;

Parent p;
Child c = new Child();
p = c;
p.NonVirtualMethod();
c.NonVirtualMethod();

Console.ReadLine();


void BetterTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
{
    var timer = sender as BetterTimer;
    Console.WriteLine($"Timer {timer.Name} has fired {timer.HowManyTimesHasItFired} times");

}

void test() {
    ;
}