# Items

Dieses Verzeichnis bündelt alle Klassen rund um aufnehmbare oder benutzbare Gegenstände. Die Basisklasse [`Item`](../../src/Objects/Items/Item.cs) leitet von `TextureObject` ab und definiert `Update`, `Draw` und `Handle`. Darauf aufbauend existieren mehrere Kategorien:

- **Collectibles** – einfache Sammelobjekte wie [`Coin`](../../src/Objects/Items/Collectibles/Coin.cs) oder [`Gem`](../../src/Objects/Items/Collectibles/Gem.cs). Diese Klassen sind aktuell Platzhalter und erweitern `Collectible` ohne eigene Logik.
- **Spells** – sollen später magische Geschosse wie Fireball oder Iceball enthalten. Die Dateien sind zurzeit leer und dienen als Vorlage.
- **Support** – vorgesehen für unterstützende Items wie Stimpacks. Auch hier sind nur leere Klassen angelegt.
- **Weapons** – hier befindet sich das Herzstück des Waffensystems. [`Weapon`](../../src/Objects/Items/Weapons/Weapon.cs) definiert Schaden, Feuerrate, Reichweite und verwaltet eine Liste von Projektilen. [`RangedWeapon`](../../src/Objects/Items/Weapons/RangedWeapon.cs) implementiert Magazine, Nachladen und das Abfeuern von [`Bullet`](../../src/Objects/Items/Projectiles/Bullet.cs). Weitere Spezialisierungen wie [`MeleeWeapon`](../../src/Objects/Items/Weapons/MeleeWeapon.cs) oder [`GrenadeWeapon`](../../src/Objects/Items/Weapons/GrenadeWeapon.cs) demonstrieren unterschiedliche Angriffsarten. Mit [`DummyWeapon`](../../src/Objects/Items/Weapons/DummyWeapon.cs) und [`DummyItem`](../../src/Objects/Items/DummyItem.cs) existieren zudem einfache Platzhalter für Tests.

Eine ausführliche Konzeptbeschreibung des Item- und Waffensystems findet sich in [item-system/konzeptbeschreibung.md](../item-system/konzeptbeschreibung.md).
