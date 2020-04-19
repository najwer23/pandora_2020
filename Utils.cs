using System;
using System.Collections.Generic;
using System.Text;

namespace pandora
{
    class Utils
    {
        public static void ShowWelcomeText()
        {
            Console.WriteLine("Project Pandora 2020");
            Console.WriteLine("Autor: Mariusz Najwer");
            Console.WriteLine();
        }

        public static void ShowExitText()
        {
            Console.WriteLine("Naciśnij enter żeby zakończyć...");
            Console.ReadLine();
        }

        public static void ShowRelaseNote()
        {
            Console.WriteLine("Wspanialy text wczytany z pliku");
        }
    }
}
