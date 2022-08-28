using System.Linq;

var groupByGenderAge = from p in Person.GetPeople
                       group p by new { p.Gender, p.Age } into grouping1
                       orderby grouping1.Count() descending
                       select new
                       {
                           key = grouping1.Key,
                           data = grouping1.Select(i => new
                           {
                               i.FirstName,
                               i.LastName,
                               i.ID,
                               i.Age
                           })
                       };

// how many young/old males and females
var groupByGenderAge2 = from p in Person.GetPeople
                       let ageGroup = p.Age < 20 ? "young" : "old"
                       group p by new { p.Gender, ageGroup } into grouping1
                       orderby grouping1.Count() descending
                       select new
                       {
                           key = $"AgeGroup: {grouping1.Key.ageGroup}, Gender: {grouping1.Key.Gender}, Count: {grouping1.Count()} ",
                           data = grouping1.Select(i => new
                           {
                               i.FirstName,
                               i.LastName,
                               i.ID,
                               i.Age
                           })
                       };

// group by even or odd numbers
int[] array = new int[] { 1, 2, 3 ,5,6,7,8,9 };

var evenOdd = from a in array
              let x = (a % 2 == 0 ? "even": "odd")
              group a by x into g
              select new
              {
                  key= g.Key,
                  g
              };

//foreach (var item in evenOdd)
//{
//    Console.WriteLine("___________________");
//    Console.WriteLine(item.key);
//    foreach (var n in item.g)
//    {
//        Console.WriteLine(n);
//    }
//}



foreach (var item in groupByGenderAge2)
{
    Console.WriteLine("___________________");
    Console.WriteLine($"Key: {item.key}");

    foreach (var person in item.data)
    {
        Console.WriteLine($"ID: {person.ID}, FirstName: {person.FirstName}," +
             $" LastName:{person.LastName}, Age: {person.Age} ");
    }
}