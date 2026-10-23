using System;
using System.Collections.Generic;
using System.Linq;
namespace ex7_linq;

public class Student
{
  public int Id { get; set; }
  public string Namn { get; set; } = "";
  public int Alder { get; set; }
  public string Klass { get; set; } = "";
  public int Poang { get; set; }
}
class Program
{
  static void Main(string[] args)
  {
    // Exempeldata
    List<Student> studenter = new List<Student>
 {
 new Student { Id = 1, Namn = "Anna", Alder = 19, Klass = "A", Poang = 85 },
 new Student { Id = 2, Namn = "Bertil", Alder = 22, Klass = "B", Poang = 72 },
 new Student { Id = 3, Namn = "Cecilia", Alder = 20, Klass = "A", Poang = 91 },
 new Student { Id = 4, Namn = "David", Alder = 24, Klass = "C", Poang = 64 },
 new Student { Id = 5, Namn = "Eva", Alder = 19, Klass = "B", Poang = 85 },
 new Student { Id = 6, Namn = "Felix", Alder = 21, Klass = "A", Poang = 77 },
 new Student { Id = 7, Namn = "Gustav", Alder = 23, Klass = "C", Poang = 58 },
 new Student { Id = 8, Namn = "Hanna", Alder = 20, Klass = "B", Poang = 95 }
 };
    Console.WriteLine("LINQ-ÖVNINGAR MED STUDENTER\n");
    //  ---
  }
}