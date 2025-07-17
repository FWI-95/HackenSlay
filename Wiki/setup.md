# Setup and Build

Kurze Einleitung: Dieser Abschnitt fasst zusammen, wie man HackenSlay einrichtet und kompiliert.

## Voraussetzungen
- MonoGame 3.8 oder neuer
- .NET 8 SDK

## Schritte
1. `chmod +x scripts/setup.sh`
2. `./scripts/setup.sh --build` installiert Abhängigkeiten und erstellt die Inhalte.
3. Alternativ kann das Projekt manuell gebaut werden mit `dotnet build` und gestartet werden mit `dotnet run`.

## Tests ausführen
```bash
 dotnet test
```

Damit lässt sich die Entwicklung schnell aufsetzen.
