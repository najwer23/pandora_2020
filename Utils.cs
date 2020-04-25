using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace pandora
{
    class Utils
    {
        protected string orginPass = "54b793b281b8aa779d1d5017ad73f588c9f1de98c7cfee52f3c8337e455107a64d29da1e2b638daace1f137a4675a56935a721f75f396ff429d16addefbea5ff";

        public string GetOrginPass()
        {
            return orginPass;
        }

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

        public void RemoveLastRelasedItem()
        {
            Console.WriteLine(" u <-- Usuń ostanią zmianę dla dokumentacji");
            CheckCredentials(GetOrginPass());

            try
            {
                string txt = File.ReadAllText("FILES\\JSON\\relase.json"); // akcja kompilacji -> zawartość
                List<JsonRelase> deserializedJsonRelase = JsonConvert.DeserializeObject<List<JsonRelase>>(txt);

                if (deserializedJsonRelase == null)
                {
                    Console.WriteLine(" Plik jest pusty");
                    return;
                }

                int sizeList = deserializedJsonRelase.Count;
                deserializedJsonRelase.RemoveAt(sizeList - 1);

                string json = JsonConvert.SerializeObject(deserializedJsonRelase.ToArray());
                File.WriteAllText("FILES\\JSON\\relase.json", json);

                File.WriteAllText(@"C:\Users\mariusz\pandora_2020\pandora\FILES\JSON\relase.json", json); //kopia dla gita
                Console.WriteLine(" Usunięto ostatnią zmianę!");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Variable is Null!");
            }
            catch
            {
                Console.WriteLine(" Wystąpił błąd podczas wczytywania pliku relase.json");
            }
           
        }

        public void SaveRelaseNote()
        {
            Console.WriteLine(" d <-- Dodaj zmianę w dokumentacji");
            CheckCredentials(GetOrginPass());

            //Obecnie nie ma większego sensu sprawdzać czy hasło jest poprawne,
            //kiedy plik json nie jest szyfrowany

            try
            {
                string txt = File.ReadAllText("FILES\\JSON\\relase.json"); // akcja kompilacji -> zawartość
                List<JsonRelase> deserializedJsonRelase = JsonConvert.DeserializeObject<List<JsonRelase>>(txt);

                Console.Write(" Opis zmian: ");
                string userText = Console.ReadLine();

                if (IsYesForSave())
                {
           
                    deserializedJsonRelase ??= new List<JsonRelase>();

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
                } else
                {
                    Console.WriteLine(" Nie dokonano zmian w dokumentacji!");
                }             
            } catch
            {
                Console.WriteLine(" Wystąpił błąd podczas wczytywania pliku relase.json");
            }
            
        }

        public bool IsYesForSave()
        {
            Console.WriteLine("\n Czy zapisać zmiany (y/n)?");
            Console.Write(" >> ");
            char charFromUser = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return charFromUser == 'y';
        }

        public static void CheckCredentials(string orginPass)
        {
            string pass;
            bool isPassOk = false;

            while (!isPassOk)
            {
                Console.Write("\n Proszę podać hasło: ");
                pass = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass = pass[0..^1];
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            if (MakeSHA512(pass) == orginPass)
                            {
                                isPassOk = true;
                            }
                            break;
                        }
                    }
                } while (true);
            }

            Console.WriteLine("\n Hasło OK!");
        }

        public static string MakeSHA512(string text)
        {
            byte[] hashedPass;
            SHA512 shaM = new SHA512Managed();
            hashedPass = shaM.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder hashedPassStringBuilder = new StringBuilder();
            for (int i = 0; i < hashedPass.Length; i++)
            {
                hashedPassStringBuilder.Append(hashedPass[i].ToString("x2"));
            }

            return hashedPassStringBuilder.ToString();
        }

        public static void ShowRelaseNote()
        {
            Console.WriteLine(" r <-- Informacje o wersji\n");

            try
            {
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
            Console.WriteLine(" f <-- Pogoda Wrocław");

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
