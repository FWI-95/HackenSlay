# Game Loop

Kurze Einleitung: Dieses Dokument beschreibt den Einstiegspunkt des Spiels und die Aufgaben der Klasse `GameHS`.

## Program.cs
- Erstellt eine Instanz von `GameHS` und ruft `Run()` auf.
- Dient als Startpunkt der Anwendung.

## GameHS
`GameHS` erbt von `Microsoft.Xna.Framework.Game` und bildet die zentrale Steuerungsschicht.
Wichtige Felder und Komponenten:
- `GraphicsDeviceManager` und `SpriteBatch` für die Darstellung.
- `VisualEngine` verwaltet alle `TextureObject`-Instanzen.
- `UserInput` liest Tastatur- und Gamepadbefehle.
- `DevConsole` und `DevOverlay` unterstützen die Entwicklung.
- Menüs: `StartMenu`, `PauseMenu` und `InventoryMenu`.
- Weltgenerator `MapGenerator` und die erzeugte `TileMap`.

### Ablauf
1. **Initialize**: erstellt Spieler und Testgegner über `DevSpawner`, initialisiert Eingaben
   und übergibt Objekte an den `VisualEngine`.
2. **LoadContent**: lädt Grafiken, generiert die Karte und initiiert Menüs und Overlays.
3. **Update**: behandelt Menüs, aktualisiert alle Objekte des `VisualEngine`, bewegt die Kamera
   und ruft Debug-Hilfen auf.
4. **Draw**: rendert zuerst die Spielwelt in ein `RenderTarget2D`, zeichnet anschließend Menüs
   sowie die Debug-Anzeigen und das Inventar.

### Hilfsmethode
`AddObject(TextureObject obj)` fügt neue Objekte dem Spiel hinzu und ruft `LoadContent` für sie auf.

Diese Klasse verbindet Eingaben, Welt und Darstellung zu einer einfachen MonoGame-Spielschleife.
