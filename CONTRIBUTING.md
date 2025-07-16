# Contributing to HackenSlay

Thank you for considering a contribution! This project welcomes pull requests and feedback. To keep the code base maintainable and the history clean, please follow the guidelines below.

## Code Style

- **Formatting**
  - Use 4 spaces for indentation.
  - Limit lines to 120 characters where possible.
  - Remove trailing whitespace.

- **Naming Conventions**
  - Classes, structs and enums use **PascalCase**.
  - Methods and public properties use **PascalCase**.
  - Local variables use **camelCase**.
  - Private fields start with an underscore, e.g. `_spriteBatch`.

## Commit Messages

Commit messages should use the following structure:

```
<short summary in present tense>

<optional detailed description>
```

The summary line should be concise (under 72 characters) and written in the imperative mood (e.g. `Add new menu` or `Fix collision bug`).

## Wiki Entries

When adding or updating wiki pages, follow the guidance in the [ChatGPT-Kodex](wiki/leitfaden/chatgpt-kodex.md) to keep entries short and consistent.

## Pull Requests

- Create topic branches from `main`.
- Include any relevant issue references in the description.
- Ensure the project builds before submitting a pull request:
  ```bash
  dotnet build
  ```

Thank you for helping improve HackenSlay!



---

## 👥 `CONTRIBUTING.md`

```markdown
# CONTRIBUTING.md – Mitwirken am Projekt HackenSlay

Danke, dass du zu HackenSlay beitragen willst!  
Damit wir sauber und effizient zusammenarbeiten können, beachte bitte folgende Punkte.

## ✅ Aufgabenverfolgung

Die aktiven Aufgaben werden automatisch beim Start der Entwicklungsumgebung über die Azure DevOps API geladen.

Du findest die Infos in:

- `active_workitems.json` → alle offenen PBIs und Tasks
- `README.md` → Übersicht in Markdown-Form
- Azure DevOps → vollständiger Kontext, Kommentare & Verlinkungen

## 🧠 Umgang mit Codex / GPT

Wir verwenden KI zur Analyse und Umsetzung von Aufgaben.

Wenn du Codex oder GPT nutzt, beachte:

- **Kennzeichne KI-generierte Skripte** am Anfang mit einem Kommentarblock
- **Korrigiere oder ergänze** generierten Code manuell, wenn nötig
- **Verweise auf DevOps-WorkItems** mit `Fixes #123` oder `Implements #456` im Commit

## 🛠️ Technische Hinweise

- Scripts liegen im `scripts/`-Ordner
- DevOps-Zugriff erfordert ein gültiges PAT (siehe interne Doku)
- Nutze PowerShell ≥5.1 oder Core für Cross-Plattform-Kompatibilität
