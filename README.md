# HackenSlay

A Hack n Slay game built with [MonoGame](https://www.monogame.net/). Source code lives in the `src` folder and additional information can be found in the `Wiki` directory.

Conversation transcripts and other helpful knowledge are stored under `docs/knowledge-base`. Codex will scan this folder when searching the repository's documentation.

## Prerequisites

- MonoGame 3.8 or newer
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Build

```bash
dotnet build
```

## Tests

Run the unit tests with:

```bash
dotnet test
```

## Run

```bash
dotnet run
```

Press `~` to open the developer console while running. Use F7 to toggle the
debug overlay.

## Documentation

Further information and developer guides can be found in the [Wiki/](Wiki/) directory.

## Setup and Compilation

The project provides a helper script to install dependencies and build the game assets.

1. Make sure the script is executable:
   ```bash
   chmod +x scripts/setup.sh
   ```
2. Run the setup script:
   ```bash
   ./scripts/setup.sh
   ```
   Add `--build` to also compile the project immediately:
   ```bash
   ./scripts/setup.sh --build
   ```
3. To build manually afterwards, run:
   ```bash
   dotnet build
   ```

The script installs the .NET 8 SDK via `apt`, installs the SDL and OpenAL packages required by MonoGame, restores dotnet tools and builds the content pipeline.

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for contribution guidelines.
