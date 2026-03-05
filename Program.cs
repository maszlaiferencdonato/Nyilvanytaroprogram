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
            Console.WriteLine($"\n   Jelenleg {moziMusor.Count} film van az adatbázisban.");
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
            Console.Write("\nVálasszon menüpontot: ");

            string valasztas = Console.ReadLine();

            switch (valasztas)
            {
                case "1":
                    Listazas();
                    break;
                case "2":
                    UjFilmHozzaadasa(moziMusor);
                    break;
                case "5":
                    Console.WriteLine("\nSikeres mentés!");
                    Console.WriteLine("\nNyomjon egy gombot a továbblépéshez...");
                    Console.ReadKey();
                    kilepes = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nÉrvénytelen menüpont!");
                    Kilepes();
                    break;
            }
        }
    }

    static void Kilepes()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Nyomjon meg egy billentyűt a kilépéshez");
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

        Console.Write("\nFilm címe: ");
        string cim = Console.ReadLine();

        Console.Write("\nMűfaj: ");
        string mufaj = Console.ReadLine();

        int hossz = BeolvasSzamot("\nHossz (perc): ", 1, 500);
        int korhatar = BeolvasSzamot("\nKorhatár: ", 0, 18);

        lista.Add(new Film(cim, mufaj, hossz, korhatar));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nSikeresen mentve! Nyomj egy gombot a menübe lépéshez");
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
            Console.WriteLine($"\nHiba! Kérem egy számot adjon meg {min} és {max} között!");
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
            Console.WriteLine("\nA lista még üres.");
        }
        else
        {
            foreach (var f in moziMusor)
            {
                Console.WriteLine($"\n- {f.Cim} | {f.Mufaj} | {f.Hossz} perc | {f.Korhatar}+");
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nNyomj egy gombot a menübe lépéshez");
        Console.ReadKey();
        Console.Clear();
        
    }
}
