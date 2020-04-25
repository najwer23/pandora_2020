using System;
using System.Collections.Generic;
using System.Text;

namespace pandora
{
    class PushUps
    {
        public void MainPushUps()
        {
            Console.WriteLine(" Witaj w programie Push-Ups (pompki)!");
            Console.WriteLine(" Program Push-Ups zakończył pracę");

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
