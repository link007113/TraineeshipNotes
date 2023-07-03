
Git is een gedistribueerd versiebeheersysteem. Het wordt gebruikt om de broncode van software bij te houden, waarbij het wijzigingen in bestanden bijhoudt en deze kan terugdraaien naar eerdere versies.

## Basisbeginselen van Git

1. **Repository**: Een Git repository (ook wel een "repo" genoemd) is een digitale map waarin Git de bestanden en de geschiedenis van de wijzigingen aan die bestanden bewaart.

2. **Commit**: Een commit in Git is een 'snapshot' van je werk op een bepaald moment. Met elke commit maak je een nieuwe versie van je project met de wijzigingen die sinds de laatste commit zijn aangebracht.

3. **Branch**: Een branch in Git is een onafhankelijke lijn van ontwikkeling. Je kunt verschillende branches hebben voor verschillende functies of bugfixes. De standaard branch is de 'master' of 'main' branch.

4. **Merge**: Wanneer je klaar bent met werken in een branch, kun je die wijzigingen samenvoegen met een andere branch met behulp van het 'merge' commando.

## Geavanceerdere Concepten

1. **Pull**: Het 'pull' commando haalt wijzigingen op uit een externe repository en voegt ze samen met je huidige branch.

2. **Push**: Het 'push' commando stuurt je commits naar een externe repository.

3. **Fetch**: Het 'fetch' commando haalt wijzigingen op uit een externe repository, maar voegt ze niet samen met je huidige branch.

## Merge Conflicten Oplossen

Een merge conflict ontstaat wanneer Git niet automatisch kan bepalen hoe twee wijzigingen moeten worden samengevoegd. Dit gebeurt meestal wanneer twee branches wijzigingen aanbrengen in dezelfde regel van hetzelfde bestand.

Om een merge conflict op te lossen:

1. Open het bestand met het conflict in een teksteditor.
2. Zoek naar de conflictmarkeringen. Git zal het conflict aangeven met `<<<<<<<`, `=======`, en `>>>>>>>`.
3. Bepaal welke wijzigingen je wilt behouden. Verwijder de conflictmarkeringen en maak het bestand zoals je wilt dat het eruit ziet.
4. Voeg het bestand toe met `git add`.
5. Maak een nieuwe commit met `git commit`.

Gebruik `git help <command>` om meer te leren over specifieke commando's!
