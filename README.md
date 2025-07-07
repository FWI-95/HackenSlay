# HackenSlay

<<<<< codex/update-readme-with-game-details
A Hack n Slay game built with [MonoGame](https://www.monogame.net/).

## Prerequisites

- MonoGame 3.8 or newer
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## Build

```bash
dotnet build
```

## Run

```bash
dotnet run
```

## Documentation

Further information and developer guides can be found in the [wiki/](wiki/) directory.
======
A simple Hack n Slay game written in C# using MonoGame.

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
>>>> main
