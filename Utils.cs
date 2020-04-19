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
            Console.WriteLine("Author: Mariusz Najwer");
            Console.WriteLine();
        }

        public static void ShowExitText()
        {
            Console.WriteLine("Please press Enter to exit...");
            Console.ReadLine();
        }


    }
}
