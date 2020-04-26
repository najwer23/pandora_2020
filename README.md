### Ostatnia aktualizacja 25.04.2020

# Pandora 2020 (remaster w C#)
> Aplikacja ma służyć jako wsparcie dla osób uprawiających aktywność fizyczną (kalistenikę)

# TODO
### Menu
- [x] Konsolowe Menu pozwalające wybierać pomiędzy dostępnymi funkcjami
### Pogoda 
- [x] Informacje pogodowe z wykorzystaniem api openweathermap.org
    - [x] Pobieranie danych w formacie JSON 
    - [x] Wyświetlane informacje: Temperatura, ciśnienie, prędkość wiatru, szerokość geograficzna, długość geograficzna, wschód i zachód słońca uwzględniający strefę czasową
    - [x] Informacje pogodowe dla miasta Wrocław
    - [ ] Informacje pogodowe dla Legnicy, Barcelony, Paryża, Londynu
### O projekcie
- [x] Informacje o aktualnej wersji (relase.json)
    - [x] Parsowanie lokalnego pliku formatu *.json
- [x] Funkcja pozwalająca dodawać treść nowej zmiany dla aktualnej wersji (relase.json)
    - [x] Parsowanie lokalnego pliku formatu *.json
    - [x] Ochrona hasłem, funkcja kodujaca, dekodująca oraz hashująca SHA512, dozwolone są 3 próby, wpisywane hasło jest ukryte w postaci gwiazdek: ****. Hasło to: "halo".
    - [x] Parsowanie danych wejściowych i zapisanie do lokalnego pliku *.json
    - [x] Obsługa wyjątków (brak plików, zły plik, pusty plik)
    - [ ] Plik *.json powinien być umieszczony na webowym serwerzem lub powinien być szyfrowany RSA, elGamalem etc.
- [x] Funkcja pozwalająca na usunięcie ostatniej dodanej zmiany dla aktualnej wersji (relase.json)
    - [x] Parsowanie lokalnego pliku formatu *.json
    - [x] Ochrona hasłem, funkcja kodujaca, dekodująca oraz hashująca SHA512, dozwolone są 3 próby, wpisywane hasło jest ukryte w postaci gwiazdek: ****. Hasło to: "halo".
    - [x] Parsowanie danych wejściowych i zapisanie do lokalnego pliku *.json
    - [x] Obsługa wyjątków (brak plików, zły plik, pusty plik)
    - [ ] Możliwość usnięcia dowolnej zmiany 
### Push-Ups (pompki)
- [ ] Push-Ups (pompki)
    - [x] Proste menu
        - [ ] Funkcja pozwalająca kontynuować program 100 pompek
        - [ ] Funckja pozwalająca zrobić "test siły" dla program 100 pompek
    - [ ] "Baza danych" w postaci plików JSON
    - [ ] Wpisanie dowlnej liczby pompek zrobionej w danym dniu
    - [ ] Kalendarz zrobionych pompek w postaci tabeli
    - [ ] Możliwość Eksportu aktualnych postępów do pliku *.txt 
    - [ ] Excel ze statystykami 
    - [ ] Minutnik, 60s, 90s, 120s, dowolna liczba sekund < 5min.
### Squats (przysiady)
- [ ] Squats (przysiady)
    - [ ] Proste menu
        - [ ] Znalezienie programu ćwiczeń
        - [ ] Funkcja pozwalająca kontynuować program
        - [ ] Funckja pozwalająca zrobić "test siły"
    - [ ] Wpisanie dowlnej liczby przysiadów zrobionej w danym dniu
    - [ ] Kalendarz zrobionych przysiadów w postaci tabeli
    - [ ] Możliwość Eksportu aktualnych postępów do pliku *.txt 
    - [ ] Excel ze statystykami
    - [ ] Minutnik, 60s, 90s, 120s, dowolna liczba sekund < 5min.
### Pull-Ups (podciągnięcia)
- [ ] Pull-Ups (podciągnięcia)
    - [ ] Proste menu
        - [ ] Znalezienie programu ćwiczeń
        - [ ] Funkcja pozwalająca kontynuować program 
        - [ ] Funckja pozwalająca zrobić "test siły"
    - [ ] Wpisanie dowlnej liczby podciągnięć zrobionej w danym dniu
    - [ ] Kalendarz zrobionych podciągnięć w postaci tabeli
    - [ ] Możliwość Eksportu aktualnych postępów do pliku *.txt 
    - [ ] Excel ze statystykami 
    - [ ] Minutnik, 60s, 90s, 120s, dowolna liczba sekund < 5min.
### Crunches (brzuszki)
- [ ] Crunches (brzuszki)
    - [ ] Proste menu
        - [ ] Znalezienie programu ćwiczeń
        - [ ] Funkcja pozwalająca kontynuować program 
        - [ ] Funckja pozwalająca zrobić "test siły"
    - [ ] Wpisanie dowlnej liczby brzuszków zrobionej w danym dniu
    - [ ] Kalendarz zrobionych podciągnięć w postaci tabeli
    - [ ] Możliwość Eksportu aktualnych postępów do pliku *.txt 
    - [ ] Excel ze statystykami 
    - [ ] Minutnik, 60s, 90s, 120s, dowolna liczba sekund < 5min.
### Ideas
- [ ] ???

# JSON

### Openweatherapi.org
```json
{
  "coord":{
    "lon":17.03,
    "lat":51.1
  },
  "weather":[
    {
      "id":500,
      "main":"Rain",
      "description":"light rain",
      "icon":"10d"
    }
  ],
  "base":"stations",
  "main":{
    "temp":287.01,
    "feels_like":281.68,
    "temp_min":286.15,
    "temp_max":288.15,
    "pressure":1012,
    "humidity":43
  },
  "visibility":10000,
  "wind":{
    "speed":5.1,
    "deg":330
  },
  "rain":{
    "3h":0.24
  },
  "clouds":{
    "all":54
  },
  "dt":1587894537,
  "sys":{
    "type":1,
    "id":1715,
    "country":"PL",
    "sunrise":1587872022,
    "sunset":1587924316
  },
  "timezone":7200,
  "id":3081368,
  "name":"Wrocław",
  "cod":200
}
```

### ExerciseProgress.json
- "id" - unikatowy id 
- "userId" - id użytkownika
- "programName" - nazwa programu do ćwiczeń
- "exId" - numer dnia z programu do ćwiczeń
- "exTest" - liczba powtórzeń (test siły) dla programu do ćwiczeń
- "exTime" - znacznik czasu ostatniego ćwiczenia z programem 

```json
[
  {
    "id": 1,
    "userId": 1,
    "programName": "100PushUps",
    "exId": 1,
    "exTest": 0,
    "exTime": "2020-04-24T20:46:59.9721842+02:00"
  }
]
```

### 100PushUpsDic.json
- "id" - nr treningu z planu ćw.
- "exWeek" - nr tygodnia z planu ćw.
- "exDay" - nr dnia z planu ćw.
- "exDaysToNext" - liczba dni przerwy do nastepnego treningu z planu ćw.
- "exMin" - minimalna liczba powtórzeń dla nr. treningu z planu ćw.
- "exMax" - maksymalna liczba powtórzeń dla nr. treningu z planu ćw.
- "exPause" - minimalna przerwa między seriami w sekundach
- "exIsTest" - czy test siły, czy normalny dzień treningu z planu ćw.
- "exSeries" - tablica powtórzeń do wykonania z planu ćw.

```json
[
  {
    "id":2,
    "exWeek":0,
    "exDay":1,
    "exDaysToNext":1,
    "exMin":0,
    "exMax":5,
    "exPause":60,
    "exIsTest":false,
    "exSeries":[
      90,
      20,
      30
    ]
  }
]
```

### 100PushUpsCal.json

- "id" - unikatowy id
- "userId" - id użytkownika
- "programName" - nazwa programu do ćwiczeń
- "exId" - nr dnia treningu z planu ćwiczeń
- "exTime" - znacznik czasu ostatniego ćwiczenia z programem
- "exNumbrOfPushUps" - całkowita liczba powtórzeń ćwiczenia 
- "exSeries" - tablica powtórzeń wykonanych z planu ćw.
- "exIsTest" - czy test siły, czy normalny dzień treningu z planu ćw.
- "exWeek" - nr tygodnia z planu ćw.
- "exDay" - nr dnia z planu ćw.

```json
[
  {
    "id": 1,
    "userId": 1,
    "programName": "100PushUps",
    "exId": 1,
    "exTime": "2020-04-24T20:46:59.9721842+02:00",
    "exNumbrOfPushUps": 140,
    "exSeries": [ 90, 20, 30 ],
    "exIsTest": true,
    "exWeek": 0,
    "exDay": 0
  },
  {
    "id": 1,
    "userId": 1,
    "programName": "CustomPushUps",
    "exTime": "2020-04-24T20:46:59.9721842+02:00",
    "exNumbrOfPushUps": 140,
    "exSeries": [ 90, 20, 30 ]
  }
]
```

# Technologies 
- C#
- Newtonsoft.Json 12.0.3

# License
- MIT. Free Software, Hell Yeah!
