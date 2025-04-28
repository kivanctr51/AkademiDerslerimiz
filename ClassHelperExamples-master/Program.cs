using ClassHelperExamples;
using ClassHelperExamples.Helpers;



var students = new List<Student> {  };

while (true)
{
    Console.Clear();
    Console.WriteLine("Öğrenci Yönetim Sistemi\n".ToUpper());
    var inputSelection = Helper.AskOption("Yapmak istediğin işlemi seç", ["Listele", "Ekle", "Sil", "Çıkış"]);

    if (inputSelection == 1)
    {
        
        if (students.Count == 0)
        {
            Console.WriteLine("kayıtlı hiçbir kullaıcı yok !!!");
        }
        
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {students[i].FirstName}  {students[i].LastName}  {students[i].BirthDate} {students[i].Gender}");
        }
        
    } else if (inputSelection == 2)
    {
        Console.WriteLine("isim:");
        var UserNameAdd = Console.ReadLine();
        Console.WriteLine("soyisim:");
        var UserLastName = Console.ReadLine();
        Console.WriteLine("Dogum Tarihi:");
        var UserBirthdateAdd =DateOnly.Parse(Console.ReadLine());
        Console.WriteLine("cinsiyet:");
        var UserGenderAdd = Console.ReadLine();

        var newStudent = new Student
        {
            FirstName = UserNameAdd,
            LastName = UserLastName,
            BirthDate = UserBirthdateAdd,
            Gender = UserGenderAdd,
        };

        students.Add(newStudent);
    }else if (inputSelection == 3)
    {
        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine("Kayıtlı Kullanıcılar : ");
            Console.WriteLine($"{i + 1}. {students[i].FirstName} {students[i].LastName}");
        }
        
        Console.WriteLine("hangi kullanıcıyı silmek istiyorsunuz :");
        bool UserRemove = int.TryParse(Console.ReadLine(), out int SelectRemove);

        if (UserRemove)
        {
            int index = SelectRemove - 1;

            if (index >= 0 && index < students.Count)
            {
                var DeleteStudent = students[index];
                students.RemoveAt(index);
            }
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Hoşçakalın...");
        Thread.Sleep(1000);
        break;
    }
    
    Console.WriteLine("\nMenüye dönmek için bir tuşa basın.");
    Console.ReadKey(true);
}



