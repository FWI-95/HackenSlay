# Items

Dieses Verzeichnis bündelt alle Klassen rund um aufnehmbare oder benutzbare Gegenstände. Die Basisklasse [`Item`](../../src/Items/Item.cs) leitet von `TextureObject` ab und definiert `Update`, `Draw` und `Handle`. Darauf aufbauend existieren mehrere Kategorien:

- **Collectibles** – einfache Sammelobjekte wie [`Coin`](../../src/Items/Collectibles/Coin.cs) oder [`Gem`](../../src/Items/Collectibles/Gem.cs). Diese Klassen sind aktuell Platzhalter und erweitern `Collectible` ohne eigene Logik.
- **Spells** – sollen später magische Geschosse wie Fireball oder Iceball enthalten. Die Dateien sind zurzeit leer und dienen als Vorlage.
- **Support** – vorgesehen für unterstützende Items wie Stimpacks. Auch hier sind nur leere Klassen angelegt.
- **Weapons** – hier befindet sich das Herzstück des Waffensystems. [`Weapon`](../../src/Items/Weapons/Weapon.cs) definiert Schaden, Feuerrate, Reichweite und verwaltet eine Liste von Projektilen. [`RangedWeapon`](../../src/Items/Weapons/RangedWeapon.cs) implementiert Magazine, Nachladen und das Abfeuern von [`Bullet`](../../src/Items/Weapons/Bullet.cs). Weitere Spezialisierungen wie [`MeleeWeapon`](../../src/Items/Weapons/MeleeWeapon.cs) oder [`GrenadeWeapon`](../../src/Items/Weapons/GrenadeWeapon.cs) demonstrieren unterschiedliche Angriffsarten. Mit [`DummyWeapon`](../../src/Items/Weapons/DummyWeapon.cs) und [`DummyItem`](../../src/Items/DummyItem.cs) existieren zudem einfache Platzhalter für Tests.

Eine ausführliche Konzeptbeschreibung des Item- und Waffensystems findet sich in [item-system/konzeptbeschreibung.md](../item-system/konzeptbeschreibung.md).
