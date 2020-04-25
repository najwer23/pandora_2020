using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace pandora
{
    class Utils
    {
        protected string orginPass = "54b793b281b8aa779d1d5017ad73f588c9f1de98c7cfee52f3c8337e455107a64d29da1e2b638daace1f137a4675a56935a721f75f396ff429d16addefbea5ff";
        protected string pathToRelaseJson = "FILES\\JSON\\relase.json";
        protected string pathToRelaseJsonDebug = "C:\\Users\\mariusz\\pandora_2020\\pandora\\FILES\\JSON\\relase.json";

        public string GetOrginPass()
        {
            return orginPass;
        }
        
        public string GetPathToRelaseJson()
        {
            return pathToRelaseJson;
        } 
        
        public string GetPathToRelaseJsonDebug()
        {
            return pathToRelaseJsonDebug;
        }





        public static void ShowWelcomeText()
        {
            Console.WriteLine(" Project Pandora Reborn 2020");
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
            if (CheckCredentials(GetOrginPass()))
            {
                try
                {
                    string txt = File.ReadAllText(GetPathToRelaseJson()); // akcja kompilacji -> zawartość
                    List<JsonRelase> deserializedJsonRelase = JsonConvert.DeserializeObject<List<JsonRelase>>(txt);

                    if (deserializedJsonRelase == null)
                    {
                        Console.WriteLine(" Plik jest pusty");
                        return;
                    }

                    int sizeList = deserializedJsonRelase.Count;
                    deserializedJsonRelase.RemoveAt(sizeList - 1);

                    string json = JsonConvert.SerializeObject(deserializedJsonRelase.ToArray());
                    File.WriteAllText(GetPathToRelaseJson(), json);
                    Console.WriteLine(" Usunięto ostatnią zmianę!");

                    #if DEBUG
                    File.WriteAllText(GetPathToRelaseJsonDebug(), json);
                    #endif
                    
                }
                catch
                {
                    Console.WriteLine(" Wystąpił błąd podczas wczytywania pliku relase.json");
                }
            } 
            else
            {
                Console.WriteLine(" Wpisano 3 razy błędne hasło");
                Console.WriteLine(" m <- Pokaż menu");
            }         
        }

        public void SaveRelaseNote()
        {
            Console.WriteLine(" d <-- Dodaj zmianę w dokumentacji");

            //Obecnie nie ma większego sensu sprawdzać czy hasło jest poprawne,
            //kiedy plik json nie jest szyfrowany lub nie leży na serwerze
            if (CheckCredentials(GetOrginPass()))
            {
                try
                {
                    string txt = File.ReadAllText(GetPathToRelaseJson()); // akcja kompilacji -> zawartość
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
                        File.WriteAllText(GetPathToRelaseJson(), json);
                        Console.WriteLine(" Zmiany w dokumentacji zostały zapisane!");

                        #if DEBUG
                        File.WriteAllText(GetPathToRelaseJsonDebug(), json);
                        #endif

                    }
                    else
                    {
                        Console.WriteLine(" Nie dokonano zmian w dokumentacji!");
                    }
                }
                catch
                {
                    Console.WriteLine(" Wystąpił błąd podczas wczytywania pliku relase.json");
                }
            } 
            else
            {
                Console.WriteLine("\n  Wpisano 3 razy błędne hasło");
                Console.WriteLine(" m <- Pokaż menu");
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

        public bool CheckCredentials(string orginPass)
        {
            string pass;
            int numberOfPassFromUser = 0;
            int maxMnumberOfPassFromUser = 3;

            while (numberOfPassFromUser != maxMnumberOfPassFromUser)
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
                            numberOfPassFromUser++;
                            if (MakeSHA512(pass) == orginPass)
                            {
                                Console.WriteLine("\n Hasło OK!");
                                return true;
                            }
                            break;
                        }
                    }
                } while (true);
            }

            return false;
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

        public void ShowRelaseNote()
        {
            Console.WriteLine(" r <-- Informacje o wersji\n");

            try
            {
                string txt = File.ReadAllText(GetPathToRelaseJson()); // akcja kompilacji -> zawartość
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
