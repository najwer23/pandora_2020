using System;

namespace pandora
{
    class MainProgram
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
