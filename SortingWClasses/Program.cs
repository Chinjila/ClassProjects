
using System.Data.Common;

Person[] people = new Person[]
{
    new Person() { Name = "Bob", Age = 34, Height = 170, Weight = 74 },
    new Person() { Name = "Alex", Age = 42, Height = 200, Weight = 72 },
    new Person() { Name = "Marky Mark", Age = 31, Height = 150, Weight = 60 },
    new Person() { Name = "Joseph", Age = 33, Height = 140, Weight = 50 },
    new Person() { Name = "Winston", Age = 22, Height = 160, Weight = 62 },
    new Person() { Name = "Marlboro", Age = 25, Height = 175, Weight = 54 }
};
Person[] people2 = new Person[]
{
    new Person() { Name = "Bob2", Age = 34, Height = 170, Weight = 74 },
    new Person() { Name = "Alex2", Age = 42, Height = 200, Weight = 70 },
    new Person() { Name = "Marky Mark2", Age = 31, Height = 150, Weight = 60 },
    new Person() { Name = "Joseph2", Age = 33, Height = 140, Weight = 50 },
    new Person() { Name = "Winston2", Age = 22, Height = 160, Weight = 62 },
    new Person() { Name = "Marlboro2", Age = 25, Height = 175, Weight = 54 }
};

//SortedList<Person, Car> sortedList = new SortedList<Person, Car>();
//sortedList.Add(people[1], new Car { VIN = "abc", Price = 2000, Weight = 300 });
//sortedList.Add(people2[1], new Car { VIN = "abc", Price = 2000, Weight = 300 });
//sortedList.Add(people2[2], new Car { VIN = "abc", Price = 2000, Weight = 300 });
//sortedList.Add(people2[3], new Car { VIN = "abc", Price = 2000, Weight = 300 });

SortedDictionary<Person, Car> sortedDictionary = new SortedDictionary<Person, Car>();
sortedDictionary.Add(people[1], new Car { VIN = "abc", Price = 2000, Weight = 300 });
sortedDictionary.Add(people2[1], new Car { VIN = "abc", Price = 2000, Weight = 300 });
sortedDictionary.Add(people2[2], new Car { VIN = "abc", Price = 2000, Weight = 300 });
sortedDictionary.Add(people2[3], new Car { VIN = "abc", Price = 2000, Weight = 300 });


List<Person> customers = new List<Person>(people);
customers.AddRange(people2);

customers.Sort();

//int position = customers.BinarySearch(new Person() { Name = "Bob2", Age = 34, Height = 170, Weight = 74 });
Person bob = customers.Find(p => p.Name == "Bob");
List<Person> Over30 = customers.FindAll(p => p.Age >= 30);


//customers.CopyTo(people);

//String s = "Apple";
//String s2 = "Cherry";
//var result = s.CompareTo(s2);
//Console.WriteLine(result);

//Person[] arrPerson =  customers.ToArray();
//Array.Sort(arrPerson);
//Console.ReadLine();

System.Collections.Hashtable ht  =new System.Collections.Hashtable();

var o1 = new Person() { Name = "Bob", Age = 34, Height = 170, Weight = 74 };
Console.WriteLine(o1.GetHashCode());

var o2 = new Person() { Name = "Bob", Age = 34, Height = 180, Weight = 65 };
Console.WriteLine(o2.GetHashCode());

Console.WriteLine(o1==o2);
Console.WriteLine(o1.Equals(o2));

var aPerson = new Person() { Name = "Bob", Age = 34, Height = 170, Weight = 74 };
ht.Add(aPerson, new Car { VIN = "abc", Price =2000,Weight=300 });

Car aCar = ht[new Person() { Name = "Bob", Age = 34 }] as Car;




Car one = new Car { VIN = "abc", Price = 2000, Weight = 300 };
Car two = new Car { VIN = "abc", Price = 2000, Weight = 300 };
Console.WriteLine(one==two);
Console.WriteLine(aCar.VIN);
class Person : IComparable<Person> {
    public string Name { get; set; }

    public int Age { get; set; }

    public int Weight { get; set; }
    public int Height { get; set; }

    public int CompareTo(Person? other) //implmenting interface defined method
    {
        switch (this.Height.CompareTo(other.Height))
        {
            case 0:
                return this.Weight.CompareTo(other.Weight);
                break;
            default:
                return this.Height.CompareTo(other.Height);
                break;
        }
        
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode() + Age.GetHashCode();
    }
    public static bool operator ==(Person p1, Person p2){
        return p1.Equals(p2);
    }
    public static bool operator !=(Person p1, Person p2)
    {
        return !p1.Equals(p2);
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Person) { throw new ArgumentException(); };
        Person p = obj as Person;
        return this.Name.Equals(p.Name) && this.Age.Equals(p.Age);
    }
}

class Car {
    public string VIN { get; set; }
    public int Price { get; set; }

    public int Weight { get; set; }


}