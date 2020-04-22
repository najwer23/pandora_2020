using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

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
            try
            {
                Console.WriteLine("Historia programu (timeline)\n");

                string txt = File.ReadAllText("FILES\\JSON\\relase.json"); // akcja kompilacji -> zawartość
                List<JsonRelase> deserializedJsonRelase = JsonConvert.DeserializeObject<List<JsonRelase>>(txt);

                int sizeList = deserializedJsonRelase.Count;
                int it = 1;
                int sizeIdSpaceMax = sizeList.ToString().Length;
                int sizeIdSpaceItem = 0;
                int sizeIdSpace = 0;
                foreach (var item in deserializedJsonRelase)
                {
                    sizeIdSpaceItem = item.Id.ToString().Length;
                    sizeIdSpace = sizeIdSpaceItem < sizeIdSpaceMax ? (sizeIdSpaceMax - sizeIdSpaceItem) : 0;
                    Console.Write(item.Id + "." + new string(' ', sizeIdSpace) + " | ");
                    Console.WriteLine(item.Time.Replace("#", " | "));
                    Console.WriteLine(new string(' ', 1) + item.Text);
                    if (it != sizeList)
                    {
                        Console.WriteLine(); it++;
                    }                     
                }
            } catch
            {
                Console.Write("Wystąpił błąd podczas wczytywania pliku relase.json");
            }
            
        }
    }
}
