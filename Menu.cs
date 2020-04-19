using System;

namespace pandora
{
    class Menu
    {
        public char SelectedOption { get; set; }
        public void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("m --- Pokaż menu");
            Console.WriteLine("r --- Informacje o wersji");
            Console.WriteLine("e --- Koniec");
        }

        public void GetMenuOption()
        {
            Console.WriteLine();
            Console.Write(">> ");
           
            SelectedOption = Console.ReadKey().KeyChar;

            Console.WriteLine();
            Console.WriteLine();

            switch (SelectedOption)
            {
                case 'm':
                    ShowMenu();
                    GetMenuOption();
                    break;
                case 'r':
                    Utils.ShowRelaseNote();
                    GetMenuOption();
                    break;  
                case 'e':
                    Utils.ShowExitText();
                    break; 
                default:
                    Console.WriteLine("Brak opcji w menu. Spróbuj ponownie..");
                    GetMenuOption();
                    break;
            }
        }
    }
}
