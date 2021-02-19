using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab._1.z._3
{
  class Person
  {
    public string Name { get; set; }
    public int Age { get; set; }

  }

  class Program
  {
    static async Task Main(string[] args)
    {
      using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
      {
        Person tom = new Person() { Name = "Anton", Age = 20 };
        await JsonSerializer.SerializeAsync<Person>(fs, tom);
        Console.WriteLine("Data has been saved to file");
      }

      // чтение данных
      using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
      {
        Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
        Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
      }

    }
  }

}