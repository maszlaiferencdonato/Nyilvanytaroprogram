
using System;
using System.Collections.Generic;
using System.IO
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
    static string[] mufajok = { "Akció", "Vígjáték", "Dráma", "Sci-fi", "Horror", "Kaland", "Animáció", "Thriller" };
    static List<string> ujMufaj = new List<string>();
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
                "Filmek szűrése",
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
                case "3":
                    FilmTorlese();
                    break;
                case "4":
                    Szures();
                    break;
                case "5":
                    FajlbeMentes();
                    Console.WriteLine("  Sikeres mentés!");
                    Console.WriteLine("  Nyomjon egy gombot a továbblépéshez...");
                    Console.ReadKey();
                    kilepes = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("  Érvénytelen menüpont!");
                    Visszalepes();
                    break;
            }
        }
    }

    static void Visszalepes()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n  Nyomjon meg egy billentyűt a visszalépéshez...");
        Console.ResetColor();
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

        string mufaj = MufajValaszto();

        int hossz = BeolvasSzamot("  Hossz (perc): ", 1, 500);
        int korhatar = BeolvasSzamot("  Korhatár: ", 0, 18);

        lista.Add(new Film(cim, mufaj, hossz, korhatar));
        Visszalepes();
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
            Console.WriteLine($"  Kérem a megadott szám {min} és {max} között legyen!");
            Console.ResetColor();
        }
    }

    static string MufajValaszto()
    {
        Console.WriteLine("  Válasszon műfajt az alábbiak közül:");
        for (int i = 0; i < mufajok.Length; i++)
        {
            Console.Write("    [");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(i + 1);
            Console.ResetColor();
            Console.WriteLine($"] {mufajok[i]}");
        }
        int valasztas = BeolvasSzamot("  Választott műfaj sorszáma: ", 1, mufajok.Length);
        return mufajok[valasztas - 1];
    }
    static void MufajStatisztika()
    {
        Console.WriteLine("\n  Műfajok szerinti statisztika:");

        foreach (var film in moziMusor)
        {
            if (!ujMufaj.Contains(film.Mufaj))
            {
                ujMufaj.Add(film.Mufaj);
            }
        }


        foreach (string mufaj in ujMufaj)
        {
            int darab = 0;
            foreach (var film in moziMusor)
            {
                if (film.Mufaj == mufaj)
                {
                    darab++;
                }
            }
            Console.WriteLine($"  - {mufaj}: {darab} db");
        }
        Visszalepes();
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
                Console.WriteLine($"  {i + 1}. | Cím: {moziMusor[i].Cim} | Műfaj: {moziMusor[i].Mufaj} | {moziMusor[i].Hossz} perc | Korhatár: {moziMusor[i].Korhatar}+");
            }
        }
        Visszalepes();

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
            Console.WriteLine("  Nincs törölhető film.");
        }
        else
        {
            Console.WriteLine("  Törölhető filmek:");
            Console.WriteLine("");
            for (int i = 0; i < moziMusor.Count; i++)
            {

                Console.Write("    [");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(i + 1);
                Console.ResetColor();
                Console.WriteLine($"] {moziMusor[i].Cim}");
            }
            Console.WriteLine("  " + new string('-', 49));

            int index = BeolvasSzamot("  Adja meg a törlendő film sorszámát: ", 1, moziMusor.Count);

            string torlendoCim = moziMusor[index - 1].Cim;
            moziMusor.RemoveAt(index - 1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  '{torlendoCim}' sikeresen törölve!");
        }

        Visszalepes();
    }

    static void Szures()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔═══════════════════════════════════════════════════╗");
        Console.WriteLine("║                  Filmek szűrése                   ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════╝");
        Console.ResetColor();


        if (moziMusor.Count == 0)
        {
            Console.WriteLine("  Nincs adat a statisztikákhoz.");
            Visszalepes();
            return;
        }

        Console.WriteLine("  [1] Műfaj szerinti csoportosítás");
        Console.WriteLine("  [2] Korhatár szerinti csoportosítás");
        Console.WriteLine("  " + new string('-', 49));

        string valasztas = BeolvasSzamot("  Válasszon opciót: ", 1, 2).ToString();

        if (valasztas == "1")
            MufajStatisztika();
        else if (valasztas == "2")
        {

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Érvénytelen opció!");
        }

    }
    static void FajlbaMentes()
    {
        try
        {
            List<string> sorok = new List<string>();
            foreach (var f in moziMusor)    
            {
                sorok.Add($"{f.Cim};{f.Mufaj};{f.Hossz};{f.Korhatar}");
            }
            File.WriteAllLines("filmek.txt", sorok);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba a mentés során: " + ex.Message);
        }
    }
    static void Betoltes()
    {
        try
        {
            if (File.Exists("filmek.txt"))
            {
                string[] sorok = File.ReadAllLines("filmek.txt");
                moziMusor.Clear();
                foreach (var sor in sorok)
                {
                    if (!string.IsNullOrWhiteSpace(sor))
                    {
                        string[] adatok = sor.Split(';');
                        moziMusor.Add(new Film(adatok[0], adatok[1], int.Parse(adatok[2]), int.Parse(adatok[3])));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba az adatok betöltésekor: " + ex.Message);
            System.Threading.Thread.Sleep(2000);
        }
    }
    
}







