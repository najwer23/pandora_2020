using System;

namespace pandora
{
    class Program
    {
        static void Main()
        {
            Utils.ShowWelcomeText();
    
            Menu menu = new Menu();
            menu.ShowMenu();
            menu.GetMenuOption();
        }
    }
}
