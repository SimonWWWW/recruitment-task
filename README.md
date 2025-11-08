Projekt podzielony na dwa foldery - UI i API.

Aby uruchomić testy GUI w trybie headless należy zmienić ustawienie w pliku inputs.json ("headless": "false" => "true") i uruchomić testy w lokalizacji w której znajduje się .csproj za pomocą polecenia dotnet test.

Przykłady testów GUI do napisania w przyszłości:
- działanie przycisków remove w przypadku usuwania produktów z koszyka
- sprawdzanie działania sortowania produktów
- wykorzystanie pozostałych userów dostępnych na stronie, np: locked\_out\_user czy error\_user

Przykłady testów API do napisania w przyszłości:
- usuwanie usera
- update danych user

Dobór narzędzi: C# + Nunit + Selenium, C# + Nunit + HttpClient.
Do raportowania użyłem allure, mimo, że mam jakiś problem z logowaniem tasków asynchronicznych takich jak requesty - stąd mój raport zawiera informacje, że testy api rzucają błędem.
(wykorzystanie await AllureLifecycle.Instance.WrapInStepAsync nie działa i jest przestarzałe na najnowszych paczkach, myślę, że gdybym miał troszkę więcej czasu znalazłbym rozwiązanie). Extent Reports utracił możliwość (od jakiejś wersji) nadpisywania raportu w jeden (zamiast każdego osobnego dla każdego testu) przez co trzeba by było ogarniać klasę pomocniczą we własnym zakresie.

!\[Raport testu](test\_report.png)
===

