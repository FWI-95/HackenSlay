# Dev Console Discussion

A request introduced a developer console similar to those in Valve games.
It should open with the `~` key and allow spawning enemies or modifying
player stats while running.

Implemented a `DevConsole` overlay at `src/UI/Menus/DevConsole.cs`.
It listens for `dev_console` input and processes simple commands:
`spawn enemy <name>`, `spawn weapon <name>`, `spawn item <name>`, and
`set player <attr> <value>` or `set enemy <attr> <value>`.
The console draws its history and current input on screen.
