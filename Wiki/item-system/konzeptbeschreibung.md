# Item- und Waffensystem

Diese Kurzbeschreibung fasst die Idee eines übergeordneten Item-Systems zusammen. Sie orientiert sich am ChatGPT-Kodex und dient als Vorlage für weitere Dokumentation.

## Grundstruktur

- **Basisklasse Item**: Abgeleitet von `TextureObject`. Jedes Item kann in der Welt liegen, vom Spieler aufgenommen und im Inventar verwaltet werden.
- **Unterklassen**: Unterscheidung nach Typ, z. B. `Collectible`, `Consumable` oder `Weapon`.
- **Spezifische Items**: Jede Item-Klasse implementiert eigene Werte und Aktionen (Schaden, Heilung, Punkte).

## Beispielhafte Item-Typen

- **Collectibles** (Münzen, Trophäen, Artefakte)
  - Erhöhen Punktestand oder schalten Erfolge frei.
- **Consumables** (Heiltränke, Nahrungsmittel)
  - Sofortige oder zeitlich gestreckte Lebensregeneration.
- **Weapons**
  - Unterklassen für Nahkampf, Fernkampf und Granaten.
  - Verwalten eigene Magazine, Feuerraten und Nachladevorgänge.

## Waffen und Inventar

- Waffen können als Primary oder Secondary im Inventar gespeichert und schnell gewechselt werden.
- Eine Hotbar ermöglicht das Belegen mit Consumables oder anderen Items.
- Spawning: per Dev-Tool, in der Welt verteilt oder in Kisten (noch zu planen).

## Weiteres Vorgehen

- Klassenstruktur entsprechend erweitern und konkrete Items ausprogrammieren.
- In jedem Item Aktionen für Benutzung, Nachladen oder andere Effekte implementieren.
- Dokumentation schrittweise ergänzen.
