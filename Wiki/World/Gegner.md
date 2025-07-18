# Gegner

In diesem Dokument werden verschiedene Gegnertypen und Mechaniken beschrieben.

## Gegnertypen

- **Zombie** – klassischer Untoter mit durchschnittlichen Werten.
- **Roboter** – besitzt viel Leben und verursacht hohen Schaden, taucht eher einzeln auf und wirkt dadurch bossartig. Verschiedene Varianten könnten als Helfer eines Bosses fungieren.
- **Mumie** – bewegt sich langsam, hat jedoch viel Lebenspunkte.
- **Zerg-ähnliches Wesen** – Name steht noch aus; zeichnet sich durch schnelle Bewegung und hohe Anzahl aus, hat aber wenig Leben und verursacht nur geringen Schaden.

### Subtypen

- **Zombie**
  - `Zombie_Fast` – schneller, aber schwächer als der Standardzombie.
  - `Zombie_Slow` – bewegt sich träge, hält dafür mehr Schaden aus.
  - `Zombie_Armed` – führt eine Nahkampfwaffe.
  - `Zombie_Juggernaut` – extrem widerstandsfähig und langsam.
- **Roboter**
  - `Robot_Assault` – ausgewogener Frontkämpfer.
  - `Robot_Tank` – sehr robust, dafür langsam.
  - `Robot_Sniper` – langsam, greift aus großer Entfernung an.
- **Mumie**
  - `Mummy_Swift` – überraschend schnell für eine Mumie.
  - `Mummy_Cursed` – verfügt über einen Fluchangriff.
  - `Mummy_Ancient` – besonders widerstandsfähig.
- **Zerg-ähnliches Wesen** *(Arbeitstitel Insekt)*
  - `Insect_Flying` – kann Hindernisse überfliegen.
  - `Insect_Swarm` – tritt immer in Gruppen auf.
  - `Insect_Behemoth` – langsam, dafür sehr stark.
- **Ritter**
  - `Knight_Elite` – verfügt über verbesserte Werte.
  - `Knight_Berserker` – teilt hohen Schaden aus, verteidigt sich aber wenig.
  - `Knight_Shielded` – trägt einen Schild und hält viel aus.
- **Bogenschütze**
  - `Archer_Longbow` – nutzt einen Langbogen für weite Distanzen.
  - `Archer_Crossbow` – feuert Bolzen langsamer, aber mit hoher Durchschlagskraft.
  - `Archer_Scout` – schneller und schwächer, erkundet das Gebiet.
- **Soldat**
  - `Soldier_Infantry` – Standardgegner mit Gewehr.
  - `Soldier_Heavy` – trägt schwere Rüstung und bewegt sich langsam.
  - `Soldier_Commander` – stärkt umliegende Soldaten.

## Einfluss des Bioms

Je nach aktuellem Biom erscheinen unterschiedliche Gegnertypen oder es variieren deren Häufigkeit und Angriffsmuster.

## Spawn- und Angriffsmuster

- Unterschiedliche Spawnraten je Gegnertyp.
- Zerg-ähnliche Gegner treten in großer Zahl auf, sind schnell, jedoch schwach.
- Mumien sind langsam, verfügen aber über viele Lebenspunkte.
- Roboter besitzen viel Leben und hohen Angriffswert, erscheinen meist einzeln oder als Boss mit unterstützenden Einheiten.

## Spawnpunkte und Gebiete

Auf der Karte können Gebiete mit mehreren Spawnpunkten existieren. Diese Punkte sind unsichtbar und inaktiv, solange der Spieler zu nah ist, damit Gegner nicht direkt neben dem Spieler auftauchen. Spawner sollen deaktivierbar sein, um ein Gebiet zu säubern oder zu sichern (konkretes Konzept folgt).

## Alarmmechanik

Wird der Spieler von einem Gegner entdeckt, kann dieser in einem Radius andere Gegner alarmieren. Alarmierte Gegner alarmieren ihrerseits weitere Gegner in ihrem Radius. So entsteht eine Kettenreaktion, die vorsichtiges Vorgehen erfordert.
