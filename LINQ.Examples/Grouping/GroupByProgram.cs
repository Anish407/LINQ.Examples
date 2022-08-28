// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



var groupedByGender = from p in people
                      group p by p.Gender into gender
                      select new
                      {
                          gender= gender.Key,
                          data = gender.Select(i=> new { 
                            i.FirstName,
                            i.LastName,
                            i.ID,
                            i.Age
                          })
                      };

var groupWithConditions = from p in people
                          where p.Age > 20
                          group p by p.Age  into ageGroup
                          select new
                          {
                              age = ageGroup.Key,
                              data = ageGroup.Select(i => new {
                                  i.FirstName,
                                  i.LastName,
                                  i.ID,
                                  i.Gender
                              })
                          };


var groupByFirstCharOfFirstName = from p in people
                          where p.Age > 20
                          group p by p.FirstName[0] into nameGroup
                          select new
                          {
                              key = nameGroup.Key,
                              data = nameGroup.Select(i => new {
                                  i.FirstName,
                                  i.LastName,
                                  i.ID,
                                  i.Gender,
                                  i.Age
                              })
                          };

foreach (var item in groupByFirstCharOfFirstName)
{
    Console.WriteLine($"Key: {item.key}");
    foreach (var person in item.data)
    {
        Console.WriteLine($"ID: {person.ID}, FirstName: {person.FirstName}," +
             $" LastName:{person.LastName} ");
    }
}


Console.ReadLine();



