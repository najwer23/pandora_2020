using System;

namespace pandora
{
    class Menu : Utils
    {
        public char SelectedOption { get; set; }
        public void ShowMenu()
        {
            Console.WriteLine(" Menu");
            Console.WriteLine(" __________________________________________________");
            Console.WriteLine(" m --- Pokaż menu");
            Console.WriteLine(" __________________________________________________");
            Console.WriteLine(" p --- Push Ups");
            Console.WriteLine(" __________________________________________________");
            Console.WriteLine(" f --- Pogoda Wrocław");
            Console.WriteLine(" __________________________________________________");
            Console.WriteLine(" r --- Informacje o wersji");
            Console.WriteLine(" d --- Dodaj zmianę w dokumentacji");
            Console.WriteLine(" u --- Usuń ostanią zmianę w dokumentacji");
            Console.WriteLine(" __________________________________________________");
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
                    Console.WriteLine(" m <- Pokaż menu\n");
                    ShowMenu();
                    GetMenuOption();
                    break;
                case 'r':
                    ShowRelaseNote();
                    GetMenuOption();
                    break; 
                case 'f':
                    ShowForecast();
                    GetMenuOption();
                    break;   
                case 'p':
                    Dispose();
                    PushUps pushUps = new PushUps();
                    pushUps.MainPushUps();
                    Console.WriteLine(" m <- Pokaż menu");
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
                    Console.WriteLine(" Brak opcji w Menu. Spróbuj ponownie..");
                    GetMenuOption();
                    break;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
