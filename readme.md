# JakieImieDlaDziecka

:family: Aplikacja do analizy popularnoœci imion dzieci w Polsce na podstawie danych z GUS. Umo¿liwia przetwarzanie statystyk i wybór imienia wed³ug okreœlonych kryteriów.

## :sparkles: Funkcje

- :open_file_folder: Wczytywanie danych z plików CSV z danymi imion
- :bar_chart: Analiza popularnoœci imion wed³ug p³ci i lat
- :mag: Mo¿liwoœæ filtrowania i sortowania wyników
- :gear: Modu³owa architektura u³atwiaj¹ca rozbudowê projektu

## :hammer_and_wrench: Wymagania

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Visual Studio 2022 lub nowszy

## :rocket: Uruchomienie

1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/Sorky96/JakieImieDlaDziecka.git
2. Otwórz plik JakieImieDlaDziecka.sln w Visual Studio.

3. Uruchom projekt (F5) lub skompiluj i uruchom z poziomu terminala:

    dotnet run

:file_folder: Struktura katalogów

    DataAccess/ – logika wczytywania danych

    Models/ – klasy reprezentuj¹ce dane

    StatisticsProcessor/ – analiza i przetwarzanie danych

:clipboard: Dane

Projekt korzysta z publicznych danych udostêpnianych przez GUS (G³ówny Urz¹d Statystyczny).