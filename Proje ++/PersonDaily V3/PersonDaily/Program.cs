

string DosyaYolu = "GunlukKayit.txt";

Console.WriteLine("Gunluk Uygulamasına Hoşgeldiniz \n");

while (true)
{
    Console.Clear();
    Console.WriteLine("1.Kayıtları Listele / Düzenle");
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

            var Date = DateTime.Now.ToString("dd MMMM yyyy");

            bool kayitVarMi = false;

            if (File.Exists(DosyaYolu))
            {
                var lines = File.ReadAllLines(DosyaYolu);
                kayitVarMi = lines.Any(line => line == Date);
            }

            if (kayitVarMi)
            {
                Console.WriteLine("Günde bir defa günlük yazabilirsin.");
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Kaydınızı Giriniz:");
                var DailyText = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(DailyText))         
                {
                    Console.WriteLine("boş olamaz!!!");
                }else
                {
                    using (StreamWriter sw = File.AppendText(DosyaYolu))
                    {
                        sw.WriteLine(Date);
                        sw.WriteLine(DailyText);
                        sw.WriteLine("-----------------");
                    }

                    Console.WriteLine("Kayıt eklendi. Devam etmek için tuşa bas...");
                    Console.ReadKey();
                }
              
            }
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

    if (!File.Exists(DosyaYolu))
    {
        Console.WriteLine("Kayıt dosyası bulunamadı.");
        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadKey();
        return;
    }

    var satirlar = File.ReadAllLines(DosyaYolu);
    int i = 0;

    while (i < satirlar.Length)
    {
        Console.Clear();

     
        for (int j = 0; j < 3 && (i + j) < satirlar.Length; j++)
        {
            Console.WriteLine(satirlar[i + j]);
        }

        i += 3;

        if (i < satirlar.Length)
        {
            Console.WriteLine("\nSonraki kaydı görmek için bir tuşa basın...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("\nTüm kayıtlar gösterildi. Devam etmek için bir tuşa basın...");
            Console.WriteLine($"duzenleme yapmak için D/d kullanın ");
           var duzenle=  Console.ReadLine();
           if (duzenle == "d")
           {
               GunlukTarihleDuzenle();
           }
           {
               
           }
        }
    }
}




void TumKayitSil()
{
    Console.WriteLine("Tüm kayıtların silinmesine emin misiniz? (E/H) ");
    var deleteOkay = Console.ReadKey().KeyChar;

    Console.WriteLine();

    if (deleteOkay == 'E' || deleteOkay == 'e')
    {
        if (File.Exists(DosyaYolu))
        {
            File.Delete(DosyaYolu);
            Console.Clear();
            Console.WriteLine("Silme işlemi başarılı.");
            
        }
        else
        {
            Console.WriteLine("Kayıt dosyası bulunamadı.");
        }
    }
    else if (deleteOkay == 'H' || deleteOkay == 'h')
    {
        Console.WriteLine("Silme işlemi iptal edildi.");
    }
    else
    {
        Console.WriteLine("Geçersiz giriş! Lütfen sadece E veya H giriniz.");
    }

    Console.WriteLine("Devam etmek için bir tuşa basın...");
    Console.ReadKey();
}



void GunlukTarihleDuzenle()
{
    if (!File.Exists(DosyaYolu))
    {
        Console.WriteLine("Kayıt dosyası bulunamadı.");
        Console.ReadKey();
        return;
    }

    var satirlar = File.ReadAllLines(DosyaYolu).ToList();

    Console.Write("Düzenlemek istediğiniz tarihi girin orn: 1 mayıs 2025 ");
    
    string girilenTarih = Console.ReadLine();

    int index = satirlar.FindIndex(line => line.Trim() == girilenTarih);

    if (index == -1)
    {
        Console.WriteLine("Bu tarihe ait bir günlük bulunamadı.");
        Console.ReadKey();
        return;
    }

    string eskiMetin = satirlar[index + 1];

    Console.WriteLine($"\nTarih: {girilenTarih}");
    Console.WriteLine($"Mevcut günlük: {eskiMetin}");

    Console.Write("\nYeni metni girin: ");
    string yeniMetin = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(yeniMetin))
    {
        Console.WriteLine("Boş kayıt olamaz!");
    }
    else
    {
        satirlar[index + 1] = yeniMetin; // sadece içeriği değiştir
        File.WriteAllLines(DosyaYolu, satirlar);
        Console.WriteLine("Günlük başarıyla güncellendi.");
    }

    Console.WriteLine("Devam etmek için bir tuşa basın...");
    Console.ReadKey();
}




