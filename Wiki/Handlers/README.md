# Handlers

Dieses Modul fasst Hilfsklassen zusammen, die verschiedene Aspekte des Spiels verwalten. Sie werden von Hauptobjekten wie `GameHS` oder `Player` genutzt, um Eingaben, Animationen und Items zu koordinieren.

## AnimationHandler
Verantwortlich für die Darstellung von Spieleranimationen. Die Klasse lädt ein SpriteSheet sowie Animationsdaten aus einer JSON-Datei (siehe [data/character/1_anim.json](../../data/character/1_anim.json)). Beim Aufruf von `Update` wird anhand von `PlayerState` und `PlayerDirection` die passende `Animation` gewählt und der aktuelle Frame fortgeschaltet. `Draw` zeichnet anschließend den entsprechenden Ausschnitt des SpriteSheets.

Wichtige Methoden aus [AnimationHandler.cs](../../src/Handlers/AnimationHandler.cs):
- `LoadContent(GameHS game, string animationData)` – lädt JSON und Grafiken.
- `Update(GameTime gameTime)` – aktualisiert die aktive Animation.
- `getSubImage()` – liefert das Rechteck des aktuellen Frames.
- `Draw(GameHS gameHS, SpriteBatch spriteBatch, TextureObject obj)` – rendert das Ergebnis auf dem Bildschirm.

Der Spieler ruft diese Methoden in [`Player.Update`](../../src/Core/Player/Player.cs) auf, um seine Bewegungen zu animieren.

## ItemActionHandler
Kapselt Logik rund um aufnehmbare und verwendbare Gegenstände. Gesammelte Items werden in Listen verwaltet und können über Primär‑ oder Sekundärangriff ausgelöst werden.

Zentrale Funktionen in [ItemActionHandler.cs](../../src/Handlers/ItemActionHandler.cs):
- `Collect(GameHS game, Item item)` fügt ein Item dem Inventar hinzu.
- `Drop(GameHS game, Item item)` legt ein Item wieder ab.
- `PrimaryAttack(GameHS game)` und `SecondaryAttack(GameHS game)` rufen `Handle` auf dem gewählten Item auf.
- `Update(GameHS game, GameTime gameTime)` aktualisiert alle gesammelten Items.
- `Draw(GameHS game, SpriteBatch spriteBatch)` zeichnet sichtbare Items.

Als Beispiel für ein Item siehe [src/Items/Weapons/Weapon.cs](../../src/Items/Weapons/Weapon.cs). Testfälle befinden sich in [ItemActionHandlerTests.cs](../../src/Tests/HackenSlay.Tests/ItemActionHandlerTests.cs).

## MovementHandler
Dieser Handler ist momentan nur als Platzhalter angelegt ([MovementHandler.cs](../../src/Handlers/MovementHandler.cs)). Die eigentliche Bewegungslogik befindet sich in [`Player.UpdateMovement`](../../src/Core/Player/Player.cs). Später kann dieser Code hierhin ausgelagert werden, um Bewegung systematisch zu kapseln.

## JSONHandler
Statische Hilfsklasse für gemeinsame JSON‑Operationen. Derzeit ist die Datei leer ([JSONHandler.cs](../../src/Handlers/JSONHandler.cs)). Sobald mehrere Module serielle Daten einlesen oder speichern müssen, sollte die Implementierung hier erfolgen.
