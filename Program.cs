using System;

class Program
{
    static void Main()
    {
        bool kilepes = false;

        while (!kilepes)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════════════════════════════════════╗");
            Console.WriteLine("║            MOZI NYILVÁNTARTÓ RENDSZER             ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine($"\n   Jelenleg 0 film van az adatbázisban.");
            Console.WriteLine("  " +new string('-', 49));

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
            Console.Write("   Válasszon menüpontot: ");

            string valasztas = Console.ReadLine();

            switch (valasztas)
            {
                case "1":
                    Console.WriteLine("Listázás folyamatban...");
                    Kilepes();
                    break;
                case "5":
                    Console.WriteLine("\nSikeres mentés!");
                    Console.WriteLine("\nNyomjon egy gombot a továbblépéshez...");
                    Console.ReadKey();
                    kilepes = true;
                    break;
                default:
                    Console.WriteLine("Érvénytelen választás!");
                    Kilepes();
                    break;
            }
        }
    }

    static void Kilepes()
    {
        Console.WriteLine("Nyomjon meg egy billentyűt a kilépéshez");
        Console.ReadKey();
    }
}