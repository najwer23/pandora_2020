### Ostatnia aktualizacja 25.04.2020

# Pandora 2020 (remaster w C#)
> Aplikacja ma służyć jako wsparcie dla osób uprawiających aktywność fizyczną (kalistenikę)

# TODO
- [x] Konsolowe Menu pozwalające wybierać pomiędzy dostępnymi funkcjami
- [x] Informacje pogodowe z wykorzystaniem api openweathermap.org
    - [x] Pobieranie danych w formacie JSON 
    - [x] Wyświetlane informacje: Temperatura, ciśnienie, prędkość wiatru, szerokość geograficzna, długość geograficzna, wschód i zachód słońca uwzględniający strefę czasową
    - [x] Informacje pogodowe dla miasta Wrocław
    - [ ] Informacje pogodowe dla Legnicy, Barcelony, Paryża, Londynu
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
- [ ] Push-Ups (pompki)
    - [x] Proste menu
        - [ ] Funkcja pozwalająca kontynuować program 100 pompek
        - [ ] Funckja pozwalająca zrobić "test siły" dla program 100 pompek
    - [ ] Wpisanie dowlnej liczby pompek zrobionej w danym dniu
    - [ ] Kalendarz zrobionych pompek w postaci tabeli
    - [ ] Możliwość Eksportu aktualnych postępów do pliku *.txt 
    - [ ] Excel ze statystykami 
    - [ ] Minutnik, 60s, 90s, 120s, dowolna liczba sekund < 5min.
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
- [ ] ???

# JSON

ExerciseProgress.json
----
- "id" - unikatowy id elementu
- "userId" - id użytkownika
- "programName" - nazwa programu do ćwiczeń
- "exId" - numer dnia z programu do ćwiczeń
- "exTest" - test siły dla programu do ćwiczeń
- "exTime" - czas ostatniego ćwiczenia z programem

```json
[
  {
    "id": 1,
    "userId": 1,
    "programName": "100PushUps",
    "exId": 1,
    "exTest": 0,
    "exTime": null
  }
]
```

# Technologies 
- C#
- Newtonsoft.Json 12.0.3

# License
- MIT. Free Software, Hell Yeah!
