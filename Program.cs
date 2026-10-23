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

    WhereFunction(studenter);
    SelectFunction(studenter);
    OrderByFunction(studenter);
    CountFunction(studenter);

    // === TAKE ===
    // === DISTINCT ===
    // === ANY / ALL ===
    // === FIRSTORDEFAUL / LAST / SINGLE ===
    // === GROUP BY ===
    // === SUM / AVERAGE / MIN / MAX ===

  }

  public static void WhereFunction(List<Student> studenter)
  {
    // === WHERE ===
    var olderThan20 = studenter.Where(s => s.Alder > 20);
    Console.WriteLine("===== WHERE =====\nÄldre än 20 år");
    foreach (var s in olderThan20)
    {
      Console.WriteLine(s.Namn);
    }

    var pointsOver80 = studenter.Where(s => s.Poang > 80);
    Console.WriteLine("\nHar över 80 i poäng");
    foreach (var s in pointsOver80)
    {
      Console.WriteLine(s.Namn);
    }
  }

  public static void SelectFunction(List<Student> studenter)
  {
    // === SELECT ===
    var studentsName = studenter.Select(s => s.Namn);
    Console.WriteLine("\n===== SELECT =====\nStudenternas namn");
    foreach (var s in studentsName)
    {
      Console.WriteLine(s);
    }

    var namePoints = studenter.Select(s => new
    {
      Name = s.Namn,
      Score = s.Poang
    });
    Console.WriteLine("\nVisa namn och poäng");
    foreach (var s in namePoints)
    {
      Console.WriteLine($"Namn: {s.Name} Poäng: {s.Score}");
    }
  }

  public static void OrderByFunction(List<Student> studenter)
  {
    // === ORDER BY ===
    var orderByAge = studenter.OrderBy(s => s.Alder);
    Console.WriteLine("\n===== ORDER BY =====\nYngst till äldst");
    foreach (var s in orderByAge)
    {
      Console.WriteLine($"{s.Alder} {s.Namn}");
    }

    var orderByScore = studenter.OrderByDescending(s => s.Poang);
    Console.WriteLine("\nHögsta poäng");
    foreach (var s in orderByScore)
    {
      Console.WriteLine($"{s.Poang} {s.Namn}");
    }
  }

  public static void CountFunction(List<Student> studenter)
  {
    // === COUNT ===
    var countedStudents = studenter.Count();
    Console.WriteLine($"\n===== COUNT =====");
    Console.WriteLine($"Antal studenter: {countedStudents}");

    var studentsInClassA = studenter.Count(s => s.Klass == "A");
    Console.WriteLine($"Antal studenter i klass A: {studentsInClassA}");
  }
}