using System;
using System.Collections.Generic;
public class Film
{
    public string Cim { get; set; }
    public string Mufaj { get; set; }
    public int Hossz { get; set; }
    public int Korhatar { get; set; }

    public Film(string cim, string mufaj, int hossz, int korhatar)
    {
        Cim = cim;
        Mufaj = mufaj;
        Hossz = hossz;
        Korhatar = korhatar;
    }
}
class Program
{
    static List<Film> moziMusor = new List<Film>();
    static void Main(string[] args)
    {
        bool kilepes = false;

        while (!kilepes)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║            MOZI NYILVÁNTARTÓ RENDSZER             ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine($"  Jelenleg {moziMusor.Count} film van az adatbázisban.");
            Console.WriteLine("  " + new string('-', 49));

            string[] menu = {
                "Filmek listázása",
                "Új film felvétele",
                "Film törlése",
                "Statisztikák",
                "Mentés és Kilépés"
            };

            for (int i = 0; i < menu.Length; i++)
            {
                Console.Write("  [");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(i + 1);
                Console.ResetColor();
                Console.WriteLine($"] {menu[i]}");
            }
            Console.WriteLine("  " + new string('-', 49));
            Console.Write("  Válasszon menüpontot: ");

            string valasztas = Console.ReadLine();

            switch (valasztas)
            {
                case "1":
                    Listazas();
                    break;
                case "2":
                    UjFilmHozzaadasa(moziMusor);
                    break;
                case "3":FilmTorlese();
                    break;
                case "5":
                    Console.WriteLine("  Sikeres mentés!");
                    Console.WriteLine("  Nyomjon egy gombot a továbblépéshez...");
                    Console.ReadKey();
                    kilepes = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  Érvénytelen menüpont!");
                    Kilepes();
                    break;
            }
        }
    }

    static void Kilepes()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  Nyomjon meg egy billentyűt a kilépéshez");
        Console.ReadKey();
        Console.Clear();
    }

    static void UjFilmHozzaadasa(List<Film> lista)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔═══════════════════════════════════════════════════╗");
        Console.WriteLine("║                 Új film hozzáadása                ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.Write("  Film címe: ");
        string cim = Console.ReadLine();

        Console.Write("  Műfaj: ");
        string mufaj = Console.ReadLine();

        int hossz = BeolvasSzamot("  Hossz (perc): ", 1, 500);
        int korhatar = BeolvasSzamot("  Korhatár: ", 0, 18);

        lista.Add(new Film(cim, mufaj, hossz, korhatar));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  Sikeresen mentve! Nyomj egy gombot a menübe lépéshez");
        Console.ReadKey();
        Console.Clear();
    }
    static int BeolvasSzamot(string uzenet, int min, int max)
    {
        int vizsgaltSzam;
        while (true)
        {
            Console.Write(uzenet);
            string input = Console.ReadLine();

            
            if (int.TryParse(input, out vizsgaltSzam) && vizsgaltSzam >= min && vizsgaltSzam <= max)
            {
                return vizsgaltSzam;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  Hiba! Kérem egy számot adjon meg {min} és {max} között!");
            Console.ResetColor();
        }
    }

    static void Listazas()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔═══════════════════════════════════════════════════╗");
        Console.WriteLine("║                  Filmek listája                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════╝");
        Console.ResetColor();

        if (moziMusor.Count == 0)
        {
            Console.WriteLine("  A lista még üres.");
        }
        else
        {
            for (int i = 0; i < moziMusor.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. | Cím: {moziMusor[i].Cim} | Műfaj: {moziMusor[i].Mufaj} |{moziMusor[i].Hossz} perc | Korhatár: {moziMusor[i].Korhatar}+");
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  Nyomj egy gombot a menübe lépéshez");
        Console.ReadKey();
        Console.Clear();
        
    }

    static void FilmTorlese()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔═══════════════════════════════════════════════════╗");
        Console.WriteLine("║                  Film törlése                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════╝");
        Console.ResetColor();

        if (moziMusor.Count == 0)
        {
            Console.WriteLine("  A lista még üres.");
        }
        else
        {
            for (int i = 0; i < moziMusor.Count; i++)
            {
                Console.WriteLine($"  [{i + 1}] {moziMusor[i].Cim}");
            }
            Console.WriteLine("  " + new string('-', 49));

            int index = BeolvasSzamot("  Adja meg a törlendő film sorszámát: ", 1, moziMusor.Count);

            string torlendoCim = moziMusor[index - 1].Cim;
            moziMusor.RemoveAt(index - 1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  '{torlendoCim}' sikeresen törölve!");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n  Nyomj egy gombot a menübe lépéshez");
        Console.ReadKey();
        Console.Clear();
    }
}

    

