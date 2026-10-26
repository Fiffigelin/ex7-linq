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
    TakeFunction(studenter);
    DistinctFunction(studenter);
    AnyAllFunction(studenter);
    FirstDefaultLastSingleFunction(studenter);
    GroupByFunction(studenter);
    SumAverageMinMaxFunction(studenter);
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

  public static void TakeFunction(List<Student> studenter)
  {
    // === TAKE ===
    var threeFirstStudents = studenter.Take(3);
    Console.WriteLine($"\n===== TAKE =====");
    Console.WriteLine($"Tre första studenterna");
    int index = 0;
    foreach (var s in threeFirstStudents)
    {
      Console.WriteLine($"{index}: {s.Namn}");
      index++;
    }

    var studentsInClassA = studenter.OrderByDescending(s => s.Poang).Take(2);
    Console.WriteLine($"\nDe högsta poängen:");
    foreach (var student in studentsInClassA)
    {
      Console.WriteLine(student.Poang);
    }
  }

  public static void DistinctFunction(List<Student> studenter)
  {
    // === DISTINCT ===
    var uniqueClasses = studenter.Select(s => s.Klass).Distinct();
    Console.WriteLine($"\n===== DISTINCT =====");
    Console.WriteLine($"Unika klasser");
    foreach (var s in uniqueClasses)
    {
      Console.WriteLine(s);
    }

    var uniqueAges = studenter.Select(s => s.Alder).Distinct();
    Console.WriteLine($"Unika åldrar");
    foreach (var s in uniqueAges)
    {
      Console.WriteLine(s);
    }
  }

  public static void AnyAllFunction(List<Student> studenter)
  {
    // === ANY / ALL ===
    var isThereAnyScoreBy100 = studenter.Any(s => s.Poang == 100); // <== hahahah variabelnamnet kan jag jobba på lite
    Console.WriteLine($"\n===== ANY / ALL =====");
    Console.WriteLine($"Finns det en student med 100 poäng?: {isThereAnyScoreBy100}");

    var isEveryScoreEqual50 = studenter.All(s => s.Poang >= 50);
    Console.WriteLine($"Är allas poäng åtminstone 50: {isEveryScoreEqual50}");
  }

  public static void FirstDefaultLastSingleFunction(List<Student> studenter)
  {
    // === FIRSTORDEFAUL / LAST / SINGLE ===
    var firstStudent = studenter.FirstOrDefault();
    Console.WriteLine($"\n=== FIRSTORDEFAUL / LAST / SINGLE ===");
    Console.WriteLine($"Första studenten: {firstStudent?.Namn}");

    var lastStudent = studenter.Last();
    Console.WriteLine($"Sista studenten: {lastStudent.Namn}");

    var studentWithId = studenter.Single(s => s.Id == 6);
    Console.WriteLine($"Student med Id 6: {studentWithId.Namn}");
  }

  public static void GroupByFunction(List<Student> studenter)
  {
    // === GROUP BY ===
    var groups = studenter.GroupBy(s => s.Klass);
    Console.WriteLine($"\n=== GROUP BY ===");

    foreach (var group in groups)
    {
      // det var ett tag sedan jag använt mig av GroupBy
      // helt glömt av att man har en Key
      // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.groupby?view=net-10.0
      Console.WriteLine($"\nKlass: {group.Key}");
      foreach (var student in group)
      {
        Console.WriteLine(student.Namn);
      }
    }
  }

  public static void SumAverageMinMaxFunction(List<Student> studenter)
  {
    // === SUM / AVERAGE / MIN / MAX ===
    var sum = studenter.Sum(s => s.Poang);
    Console.WriteLine($"\n=== SUM / AVERAGE / MIN / MAX ===");
    Console.WriteLine($"Summa: {sum}");

    var average = studenter.Average(s => s.Poang);
    Console.WriteLine($"Average: {average}");

    var min = studenter.Min(s => s.Poang);
    var max = studenter.Max(s => s.Poang);
    Console.WriteLine($"Min: {min}\nMax: {max}");
  }
}