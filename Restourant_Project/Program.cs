using System.Runtime.InteropServices;

namespace Restourant_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] desks = new bool[5] { false, false, false, false, false, };
            Dictionary<string, double> mainFood = new Dictionary<string, double>
            {
                {"Kebap",180 },
                {"İskender",175 },
                {"Kanat",110 },
            };

            Dictionary<string, double> Soaps = new Dictionary<string, double>
            {
                {"Mercimek Çorbası",55 },
                {"Domates Çorbası",60 },
                {"Kelle Paça Çorbası",105 },
            };

            Dictionary<string, double> Drinks = new Dictionary<string, double>
            {
                {"Kola",20 },
                {"Su",10 },
                {"Fanta",15 },
            };

            Dictionary<string, double> Desserts = new Dictionary<string, double>
            {
                {"Puding",45},
                {"Tiramisu",65 },
                {"Cake",55 },
            };

            while (true)
            {
                Console.WriteLine("1.Hesap Öde");
                Console.WriteLine("2.Sipariş Al");
                Console.WriteLine("3.Çıkış");
                Console.WriteLine("Seçim:");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    HesapAl(desks);
                }
                else if (secim == "2")
                {
                    SiparisAl(desks, mainFood, Drinks, Soaps, Desserts);
                }
                else if (secim == "3")
                {
                    break;
                }
                else 
                {
                 Console.WriteLine("Geçersiz Bir Seçim Yaptınız Lütfen Daha Sonra Tekrar Deneyiniz.");
                }

            }

        }
        static void HesapAl(bool[] desks)
        {
            Console.WriteLine("Hangi Masanın Hesabını almak istiyorsunuz ?");
            int deskNo = Convert.ToInt32(Console.ReadLine())-1;
            if (deskNo >0 && deskNo <= 5)
            {
                desks[deskNo] = false;
                Console.WriteLine($"Masa{deskNo + 1}Boşaltıldı Ve Hesap Ödendi");
            }
            else
            {
                Console.WriteLine("Geçersiz Veya Boş Bir Masa Numarası Girdiniz.");
            }
        }
        static void SiparisAl(bool[] masalar, Dictionary<string, double> mainFood, Dictionary<string, double> soaps, Dictionary<string, double> Desserts, Dictionary<string, double> drinks)
        {
            int deskNo = MasaBul(masalar);   
            if (deskNo == 0)
            {
                Console.WriteLine("Üzgünüz Tüm Masalarımız Dolu.");
                return;
            }

            else
            {
                Console.WriteLine("Lütfen Kaç Kişi Olduğunuzu Belirtiniz");
                int KisiSayisi = Convert.ToInt32(Console.ReadLine());

                masalar[deskNo]= true;
                Console.WriteLine($"Masa{deskNo + 1}Size ayrıldı.");

                double toplamTutar = 0;
                for (int i = 1; i <= KisiSayisi; i++)
                {
                    Console.WriteLine($"\nKişi{i} için sipariş alınıyor.");
                    toplamTutar += SiparisVer(mainFood, soaps, Desserts, drinks);
                }
                Console.WriteLine($"Toplam Sipariş Tutarınız{toplamTutar} TL");
            }
        }

        static int MasaBul(bool[] masalar)
        {
            for (int i = 0; i < masalar.Length; i++)
            {
                if (!masalar[i]) 
                {
                    return i;
                }
            }
            return -1; 
        }

        static double SiparisVer(Dictionary<string, double> mainFoods, Dictionary<string, double> soaps, Dictionary<string, double> Desserts, Dictionary<string, double> drinks)
        {
            string siparis;
            double toplamTutar = 0;

            do
            {
                Console.WriteLine("\n--- Menü ---");
                Console.WriteLine("Ana Yemekler:");
                foreach (var yemek in mainFoods)
                {
                    Console.WriteLine($"{yemek.Key} - {yemek.Value} TL");
                }

                Console.WriteLine("\nÇorbalar:");
                foreach (var corba in soaps)
                {
                    Console.WriteLine($"{corba.Key} - {corba.Value} TL");
                }

                Console.WriteLine("\nTatlılar:");
                foreach (var tatli in Desserts)
                {
                    Console.WriteLine($"{tatli.Key} - {tatli.Value} TL");
                }

                Console.WriteLine("\nİçecekler:");
                foreach (var icecek in drinks)
                {
                    Console.WriteLine($"{icecek.Key} - {icecek.Value} TL");
                }

                Console.Write("\nSiparişinizi girin (Çıkmak için (Bitti): ");
                siparis = Console.ReadLine();

                if (mainFoods.ContainsKey(siparis))
                {
                    toplamTutar += mainFoods[siparis];
                }
                else if (soaps.ContainsKey(siparis))
                {
                    toplamTutar += soaps[siparis];
                }
                else if (drinks.ContainsKey(siparis))
                {
                    toplamTutar += drinks[siparis];
                }
                else if (Desserts.ContainsKey(siparis))
                {
                    toplamTutar += Desserts[siparis];
                }
                else if (siparis.ToLower() != "yok")
                {
                    Console.WriteLine("Geçersiz Seçim");
                }

                Console.WriteLine("Başka bir isteğiniz varmı ? (Evet/Hayır)");

            } while (Console.ReadLine().ToLower() == "Evet");

              return toplamTutar;

        }
    }
}























