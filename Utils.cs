using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace pandora
{
    class Utils
    {
        public static void ShowWelcomeText()
        {
            Console.WriteLine(" Project Pandora 2020");
            Console.WriteLine(" Autor: Mariusz Najwer");
            Console.WriteLine(" "+ DateTime.Now + "\n");
        }

        public static void ShowExitText()
        {
            Console.WriteLine(" Naciśnij enter żeby zakończyć...");
            Console.ReadLine();
        }

        public static void SaveRelaseNote()
        {
            //Console.Write(" Zmiana w dokumentacji");

            //string pass;
            //bool isPassOk = false;

            //while (!isPassOk)
            //{
            //    Console.Write("\n Proszę podać hasło: ");
            //    pass = "";
            //    do
            //    {
            //        ConsoleKeyInfo key = Console.ReadKey(true);
            //        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            //        {
            //            pass += key.KeyChar;
            //            Console.Write("*");
            //        }
            //        else
            //        {
            //            if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
            //            {
            //                pass = pass[0..^1];
            //                Console.Write("\b \b");
            //            }
            //            else if (key.Key == ConsoleKey.Enter)
            //            {
            //                if (pass == "halo")
            //                {
            //                    isPassOk = true;
            //                }
            //                break;
            //            }
            //        }
            //    } while (true);
            //}

            try
            {
                string txt = File.ReadAllText("FILES\\JSON\\relase.json"); // akcja kompilacji -> zawartość
                List<JsonRelase> deserializedJsonRelase = JsonConvert.DeserializeObject<List<JsonRelase>>(txt);

                Console.Write(" Opis zmian: ");
                string userText = Console.ReadLine();

                int sizeList = deserializedJsonRelase.Count;
                deserializedJsonRelase.Add(new JsonRelase
                {
                    Id = sizeList++,
                    Time = DateTime.Now,
                    Text = userText
                });

                string json = JsonConvert.SerializeObject(deserializedJsonRelase.ToArray());
                File.WriteAllText("FILES\\JSON\\relase.json", json);

                File.WriteAllText(@"C:\Users\mariusz\pandora_2020\pandora\FILES\JSON\relase.json", json); //kopia dla gita
                Console.WriteLine(" Zmiany w dokumentacji zostały zapisane!");
            } catch
            {
                Console.Write(" Wystąpił błąd podczas wczytywania pliku relase.json");
            }
            
        }

        public static void ShowRelaseNote()
        {
            try
            {
                Console.WriteLine(" Historia programu (timeline)\n");

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
                    Console.Write(" " + item.Id + "." + new string(' ', sizeIdSpace) + " | ");
                    Console.WriteLine(item.Time);
                    Console.WriteLine(new string(' ', 1) + item.Text);
                    if (it != sizeList)
                    {
                        Console.WriteLine(); it++;
                    }
                }
            }
            catch
            {
                Console.Write(" Wystąpił błąd podczas wczytywania pliku relase.json");
            }

        }

        public static void ShowForecast()
        {
            try
            { 
                //Should It hide?
                var jsonForecast = new WebClient().DownloadString("https://api.openweathermap.org/data/2.5/weather?q=Wroclaw,PL&appid=44d4448ac56b1e46ac958095e7a55622");
                dynamic forecast = JsonConvert.DeserializeObject(jsonForecast);

                double tempCelWroclaw = forecast.main.temp - 273.15;
                double pressureWroclaw = forecast.main.pressure;
                double windWroclaw = forecast.wind.speed * 3.6;

                double lonWroclaw = forecast.coord.lon;
                double latWroclaw = forecast.coord.lat;

                long sunriseMsWroclaw = (forecast.sys.sunrise + forecast.timezone) * 1000;
                DateTime sunriseWroclaw = DateTimeOffset.FromUnixTimeMilliseconds(sunriseMsWroclaw).UtcDateTime;

                long sunsetMsWroclaw = (forecast.sys.sunset + forecast.timezone) * 1000;
                DateTime sunsetWroclaw = DateTimeOffset.FromUnixTimeMilliseconds(sunsetMsWroclaw).UtcDateTime;

                Console.WriteLine(" Pogoda we Wrocławiu :)\n");

                Console.WriteLine(" Temperatura: " + tempCelWroclaw.ToString("F") + " \u00B0C");
                Console.WriteLine(" Ciśnienie atmosferyczne: " + pressureWroclaw.ToString("F") + " hPa\n");
                Console.WriteLine(" Prędkość wiatru: " + windWroclaw.ToString("F") + " km/h");

                Console.WriteLine(" Szerokość geograficzna: " + latWroclaw.ToString("F") + " \u00B0N");
                Console.WriteLine(" Długość geograficzna: " + lonWroclaw.ToString("F") + " \u00B0E\n");
                Console.WriteLine(" Wschód Słońca: " + sunriseWroclaw);
                Console.WriteLine(" Zachód Słońca: " + sunsetWroclaw);
            }
            catch
            {
                Console.Write(" Wystąpił błąd z usługą api.openweathermap.org");
            }
        }
    }
}
