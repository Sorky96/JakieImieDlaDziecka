# JakieImieDlaDziecka

:family: Aplikacja do analizy popularno�ci imion dzieci w Polsce na podstawie danych z GUS. Umo�liwia przetwarzanie statystyk i wyb�r imienia wed�ug okre�lonych kryteri�w.

## :sparkles: Funkcje

- :open_file_folder: Wczytywanie danych z plik�w CSV z danymi imion
- :bar_chart: Analiza popularno�ci imion wed�ug p�ci i lat
- :mag: Mo�liwo�� filtrowania i sortowania wynik�w
- :gear: Modu�owa architektura u�atwiaj�ca rozbudow� projektu

## :hammer_and_wrench: Wymagania

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Visual Studio 2022 lub nowszy

## :rocket: Uruchomienie

1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/Sorky96/JakieImieDlaDziecka.git
2. Otw�rz plik JakieImieDlaDziecka.sln w Visual Studio.

3. Uruchom projekt (F5) lub skompiluj i uruchom z poziomu terminala:

    dotnet run

:file_folder: Struktura katalog�w

    DataAccess/ � logika wczytywania danych

    Models/ � klasy reprezentuj�ce dane

    StatisticsProcessor/ � analiza i przetwarzanie danych

:clipboard: Dane

Projekt korzysta z publicznych danych udost�pnianych przez GUS (G��wny Urz�d Statystyczny).