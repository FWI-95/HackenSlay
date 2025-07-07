# HackenSlay

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
