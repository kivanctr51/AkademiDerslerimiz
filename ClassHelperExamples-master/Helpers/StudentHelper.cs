namespace ClassHelperExamples.Helpers;

public static class StudentHelper
{
    public static void ListStudents(List<Student> students)
    {
        Console.Clear();
        Console.WriteLine("TÜM ÖĞRENCİLER \n");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} - {student.GetAge()}");
        }
    }
    
    
}
