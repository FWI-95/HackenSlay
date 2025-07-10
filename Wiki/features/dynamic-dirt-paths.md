# Dynamische Trampelpfade

Dieses Konzept beschreibt, wie Gras- oder Erdtiles durch wiederholtes Begehen langsam zu sichtbaren Wegen werden.

## Grundidee

- Feste Straßen bleiben unverändert, doch weiche Untergründe können über die Zeit Pfade bilden.
- Jedes Mal, wenn ein Spieler, NPC oder Gegner über ein Tile läuft, erhöht sich ein Abnutzungswert.
- Ab einem Schwellenwert wechselt die Textur von Gras zu einem abgetretenen Pfad.
- Häufiges Nutzen verbreitert den Pfad weiter, sodass sich stark frequentierte Routen von selbst ausbilden.
- Bleibt ein Gebiet längere Zeit ungenutzt, verringert sich der Abnutzungswert wieder und die Natur holt sich das Terrain zurück.

## Umsetzungshinweise

- Tiles speichern einen numerischen **Wear**-Wert, der bei jedem Schritt erhöht wird.
- In der Weltaktualisierung prüft das Spiel die Position der Entities und passt den Wert an.
- Mehrere Stufen (Gras → Trampelpfad → ausgebauter Weg) können unterschiedliche Grafiken verwenden.
- Der Abnutzungswert sollte langsam sinken, wenn niemand das Tile betritt, damit brachliegende Pfade wieder zuwachsen.

