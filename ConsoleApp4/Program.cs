public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var students = new List<Student> {
            new Student { Name = "chidam", Grade = 65, Age = 20 },
            new Student { Name = "adi", Grade = 75, Age = 21 },
            new Student { Name = "shyam", Grade = 85, Age = 20 },
            new Student { Name = "aam", Grade = 85, Age = 22 },
            new Student { Name = "jitesh", Grade = 90, Age = 22 },
        };

        var filteredSortedStudents = students
            .Where(s => s.Grade >= 70)
            .Select(s => new { s.Name, s.Grade })
            .OrderBy(s => s.Grade)
            .ThenBy(s => s.Name);

        foreach (var student in filteredSortedStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
        }
    }
}
