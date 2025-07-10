# Bullet System

Kurze Einleitung: Dieses Dokument beschreibt den Aufbau der Projektilklassen und den Ablauf beim Feuern einer Waffe.

## Klassenstruktur
- **Projectile** erbt von `TextureObject` und verwaltet Position, Richtung, Geschwindigkeit und Reichweite.
- **Bullet** erweitert `Projectile` ohne zusätzliche Logik und repräsentiert einfache Kugeln.
- `RangedWeapon` hält eine Liste aktiver `Projectiles` und kümmert sich um Nachladen, Feuerrate und das Erzeugen neuer Geschosse.
- Spezialisierungen wie `Gun` setzen die konkreten Parameter (Magazingröße, Schaden, Nachladezeit).

## Ablauf
1. `Use` einer Waffe setzt ihre Position und startet gegebenenfalls das Schießen.
2. In `Update` prüft die Waffe das Nachladen und erzeugt nach Ablauf der Feuerrate neue `Bullet`-Instanzen.
3. Jedes Projektil aktualisiert seine Position im eigenen `Update` und deaktiviert sich, wenn die Reichweite erreicht ist oder es den Bildschirm verlässt.
