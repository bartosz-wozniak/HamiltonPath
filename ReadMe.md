Użycie aplikacji konsolowej:
- Uruchamiamy konsolę
- Wpisujemy polecenie: ścieeżka/HamiltonPath.ConsoleApp nazwa_kmendy opcjonalne_parametry
- Dostępne komendy:
  - find-hamilton-path input_path output_path, gdzie input_path - ścieżka do pliku zawierającego graf w odpowiendim formacie, otput_path - ścieżka do pliku, w którym ma zostać zapisany wynik
  - generate-graph n outpu_file, gdzie n - liczba wierzchołków w grafie, outpu_file jak wyżej
  - help
  - generate-and-compute - pomocnicza komenda licząca czasy wykonania

  Aplikacja desktopowa:
  Przycisk generate generuje plik testowy z grafem. Graf ma tyle wierzchołków, ile wynosi pole Verticles.
  Przysik load ładuje plik z grafem do programu.
  Przycisk Compute uruchamia algorytm dla wczytanego grafu.
  Przysik Save zapisuje wynik do pliku, jeśli został wcześniej policzony

  W oknie prezentowane są bieżące statusy, czy graf został wczytany oraz czy ścieżka została już policzona oraz jaka ona jest.