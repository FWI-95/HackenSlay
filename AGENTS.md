# AGENT Guidelines for HackenSlay

This file collects instructions and project knowledge for Codex. Update it
whenever you discover new conventions or helpful information.

## Project Overview
- **Language/Framework:** C# with MonoGame 3.8, targeting .NET 8.
- **Folders**
  - `src/` contains the game source code. Tests live under `src/Tests/HackenSlay.Tests`.
  - `Content/` holds game assets compiled by the MonoGame content pipeline.
  - `docs/knowledge-base/` stores conversation summaries and design decisions.
  - `Wiki/` hosts additional developer documentation.
  - `scripts/` includes helper scripts like `setup.sh` for installing dependencies and building assets.

## Build and Run
- Install prerequisites (`MonoGame 3.8+`, `.NET 8 SDK`).
- Use the helper script to set up the environment:
  ```bash
  chmod +x scripts/setup.sh
  ./scripts/setup.sh [--build]
  ```
- Build the project:
  ```bash
  dotnet build
  ```
- Run unit tests:
  ```bash
  dotnet test
  ```
- Launch the game with:
  ```bash
  dotnet run
  ```
  Press `~` in game to open the developer console and `F7` to toggle the debug overlay.

## Code Style
Derived from `CONTRIBUTING.md`:
- Use **4 spaces** for indentation and keep lines under **120 characters**.
- Remove trailing whitespace.
- **Naming**
  - Classes, structs, enums, methods and public properties: **PascalCase**.
  - Local variables: **camelCase**.
  - Private fields: start with an underscore (e.g. `_spriteBatch`).

## Commit Messages
Use short imperative headlines (<72 characters) followed by an optional description.
Example:
```
Add enemy spawn tests

Cover MapGenerator enemy spawn locations with new unit tests.
```

## Documentation Notes
- When creating Wiki entries, follow the template in `Wiki/leitfaden/chatgpt-kodex.md`.
- Conversation summaries in `docs/knowledge-base/` should be named `YYYY-MM-DD-topic.md`.
Codex scans this folder for background information when generating code.

---



---

## 🤖 `AGENTS.md`

```markdown
# AGENTS.md – KI-Interaktion mit aktiven DevOps-Aufgaben

Dieses Projekt verwendet automatisierte Agenten wie **Codex** oder **ChatGPT**, um Aufgaben aus dem Projektkontext zu analysieren und umzusetzen. Damit diese Agenten sinnvoll arbeiten können, werden beim Start der Umgebung alle **aktiven Aufgaben (PBIs und Tasks)** über die **Azure DevOps REST API** geladen.

## 🔗 Quelle der Informationen

Folgende REST-Abfrage wird automatisiert durchgeführt:

- Organisation: `FWI95`
- Projekt: `games`
- AreaPath: `HackenSlay`
- Filter: Nur offene Tasks und PBIs
- Format: JSON (`active_workitems.json`)

Die Datei wird von Codex eingelesen und dient als Grundlage für Entscheidungen, Vorschläge und Codegenerierung.

## 📌 Anweisung für Agenten

KI-Agents sollten bei Verarbeitung dieser Daten:

- Aufgaben clustern oder kategorisieren
- passende Umsetzungen vorschlagen
- technische Konzepte beschreiben
- Code in passenden Ordnerstrukturen vorschlagen

## 🧾 Hinweispflicht

Jedes KI-unterstützte Skript in diesem Repository muss am Anfang einen **Hinweis auf KI-Nutzung** enthalten, z. B.:

```powershell
# Erstellt mit Unterstützung von OpenAI Codex
