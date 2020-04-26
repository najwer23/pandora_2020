using System;

namespace pandora
{
    class PushUps
    {
        private char SelectedOption { get; set; }

        public void MainPushUps()
        {
            ShowMenuPushUps();
            GetMenuPushUpsOption();

            Console.WriteLine(" Program Push-Ups zakończył pracę");
            Dispose();
        }

        public void ShowMenuPushUps()
        {
            Console.WriteLine(" p <-- Push Ups\n");
            Console.WriteLine(" Menu PushUps");
            Console.WriteLine(" ..................................................");
            Console.WriteLine(" Program 100pompek.pl");
            Console.WriteLine("  t --- Chcę zrobić test");
            Console.WriteLine("  k --- Kontynuuje trening");
            Console.WriteLine(" a --- Chcę podać własną liczbę pompek"); 
            Console.WriteLine(" c --- Kalendarz pompek");
            Console.WriteLine(" e --- Powrót do Menu");
            Console.WriteLine(" ..................................................");
        }

        public void GetMenuPushUpsOption()
        {
            Console.WriteLine();
            Console.Write(" >> ");

            SelectedOption = Console.ReadKey().KeyChar;

            Console.WriteLine();
            Console.WriteLine();

            switch (SelectedOption)
            {
                case 't':
                    Program100PushUpsTest();
                    break;
                case 'k':
                    Program100PushUpsNext();
                    break;
                case 'a':
                    ProgramCustomPushUps();
                    break; 
                case 'c':
                    CalendarPushUps();
                    break; 
                case 'e':
                    Console.WriteLine(" e <-- Powrót do Menu\n");
                    Menu menu = new Menu();
                    menu.ShowMenu();
                    menu.GetMenuOption();
                    break;
                default:
                    Console.WriteLine(" Brak opcji w Menu Push-Ups. Spróbuj ponownie..");
                    GetMenuPushUpsOption();
                    break;

            }
        }

        public void CalendarPushUps()
        {
            Console.WriteLine(" c <-- Kalendarz pompek");
        }

        public void ProgramCustomPushUps()
        {
            Console.WriteLine(" a <-- Chcę podać własną liczbę pompek");
        }

        public void Program100PushUps()
        {
            Console.WriteLine(" p <-- Program 100pompek.pl");

        }
        public void Program100PushUpsNext()
        {
            Console.WriteLine(" k <-- Kontynuuje Program 100pompek.pl");

        }

        public void Program100PushUpsTest()
        {
            Console.WriteLine(" t <-- Test siły dla Program 100pompek.pl");

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
