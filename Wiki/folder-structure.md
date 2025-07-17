# Folder Structure

This document describes the layout of the repository after the recent reorganization.

## Top level

- `src/` – C# source code of the game.
- `Content/` – assets compiled by the MonoGame content pipeline.
- `data/` – JSON configuration files for characters, input and other systems.
- `docs/` – conversation summaries and design notes.
- `Wiki/` – developer documentation (this folder).
- `scripts/` – setup and automation scripts. This folder also contains `active_workitems.json` with the current DevOps tasks.

## Source folders

Inside `src/` the code is split into several subfolders:

- `Core/` – engine components such as animation, input, networking and shared helpers.
- `Objects/` – gameplay objects like the player, items, enemies and world generation.
- `Tests/` – unit test project `HackenSlay.Tests`.


