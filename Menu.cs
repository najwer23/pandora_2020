using System;

namespace pandora
{
    class Menu : Utils
    {
        public char SelectedOption { get; set; }
        public void ShowMenu()
        {
            Console.WriteLine(" Menu");
            Console.WriteLine(" m --- Pokaż menu");
            Console.WriteLine(" r --- Informacje o wersji");
            Console.WriteLine(" p --- Pogoda Wrocław");
            Console.WriteLine(" d --- Dodaj zmianę dla dokumentacji");
            Console.WriteLine(" u --- Usuń ostanią zmianę dla dokumentacji");
            Console.WriteLine(" e --- Koniec");
        }

        public void GetMenuOption()
        {
            Console.WriteLine();
            Console.Write(" >> ");
           
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
                    ShowRelaseNote();
                    GetMenuOption();
                    break; 
                case 'p':
                    ShowForecast();
                    GetMenuOption();
                    break;  
                case 'e':
                    ShowExitText();
                    break;
                case 'd':
                    SaveRelaseNote();
                    GetMenuOption();
                    break;  
                case 'u':
                    RemoveLastRelasedItem();
                    GetMenuOption();
                    break; 
                default:
                    Console.WriteLine(" Brak opcji w menu. Spróbuj ponownie..");
                    GetMenuOption();
                    break;

            }
        }
    }
}
