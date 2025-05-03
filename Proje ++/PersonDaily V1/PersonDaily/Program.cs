

string DosyaYolu = "GunlukKayit.txt";

Console.WriteLine("Gunluk Uygulamasına Hoşgeldiniz \n");

while (true)
{
    Console.Clear();
    Console.WriteLine("1.Kayıtları Listele");
    Console.WriteLine("2.Yeni Kayıt Ekle");
    Console.WriteLine("3.Tüm Kayıtları Sil");
    Console.WriteLine("4.Ana Menüye Dön");
    Console.WriteLine("5.Çıkış Yap");

    var value = Console.ReadKey().KeyChar;
    Console.Clear();

    switch (value)
    {
        case '1':
            if (File.Exists(DosyaYolu) && new FileInfo(DosyaYolu).Length > 0)
            {
                Console.Clear();
                KayitListele();
            }
            else
            {
                Console.WriteLine("Herhangi bir kayıt yok.");
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
            break;
        

        case '2':
            Console.Clear();
            Console.WriteLine("Kaydınızı Giriniz:");
            var DailyText = Console.ReadLine();
            var Date = DateTime.Now.ToString("dd MMMM yyyy");

            using (StreamWriter sw = File.AppendText(DosyaYolu))
            {
                sw.WriteLine(Date);
                sw.WriteLine(DailyText);
                sw.WriteLine("-----------------");
            }

            Console.WriteLine("Kayıt eklendi. Devam etmek için tuşa bas...");
            Console.ReadKey();
            break;

        case '3':
            TumKayitSil();
            break;

        case '4':
            continue;

        case '5':
            Console.WriteLine("sistemden Başarılı şekilde cıkış yapıldı");
            break;
        default:
            Console.WriteLine("Geçersiz Giriş Tekrar deneyiniz.");
            Console.ReadKey();
            break;
    }
}


void KayitListele()
{
    Console.Clear();

    if (File.Exists(DosyaYolu))
    {
        foreach (var line in File.ReadAllLines(DosyaYolu))
        {
            Console.WriteLine(line);
        }
    }
    else
    {
        Console.WriteLine("Kayıt yok");
    }

    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
    Console.ReadKey();
}

 void TumKayitSil()
{
    Console.WriteLine("Tüm kayıtların silinmesine emin Misiniz ? E/H ");
    var deleteOkay = Console.ReadKey().KeyChar;

    if (deleteOkay == 'E' || deleteOkay =='e')
    {
        if (File.Exists(DosyaYolu))
        {  File.Delete(DosyaYolu);

            Thread.Sleep(2000);
      
            Console.WriteLine("Silme işlemi Başarılı");
            
        }
        else
        {
            Console.WriteLine("Sıkıntı Oluştu !!!");
        }
    }
}


