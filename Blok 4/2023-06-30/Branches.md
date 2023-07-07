Een branch in Git is in feite een unieke reeks code-veranderingen met een unieke naam. Elke repository kan meerdere branches hebben, waardoor meerdere mensen gelijktijdig kunnen werken.

## Waarom branches gebruiken?

1. **Feature-ontwikkeling**: Gebruik branches om aan specifieke features of projecttaken te werken zonder de hoofdcodebasis (doorgaans de 'main' of 'master' branch) te beïnvloeden. 

2. **Isolatie van wijzigingen**: Branches zorgen voor isolatie, zodat u kunt experimenteren en testen zonder uw main codebase te beïnvloeden.

3. **Versiebeheer**: U kunt branches ook gebruiken om verschillende versies van uw project bij te houden.

4. **Pull Requests**: Branches worden gebruikt bij het werken met pull requests. Een aparte branch wordt aangemaakt voor elke pull request. Na voltooiing van de wijzigingen kan de branch worden samengevoegd met de hoofdbranch.

## Basale Branch Commands

1. `git branch`: Hiermee worden alle lokale branches in de huidige repository weergegeven.

2. `git branch [branch-naam]`: Creëert een nieuwe branch.

3. `git checkout [branch-naam]`: Hiermee kunt u overschakelen naar de gespecificeerde branch en deze bijwerken om de meest recente inhoud ervan weer te geven.

4. `git merge [branch-naam]`: Hiermee worden de wijzigingen van de gespecificeerde branch samengevoegd met de huidige branch. Conflicten kunnen optreden tijdens het samenvoegen, die handmatig moeten worden opgelost.

5. `git branch -d [branch-naam]`: Verwijder een branch. Het is veiliger dan `git branch -D [branch-naam]`, omdat het weigert de branch te verwijderen als deze nog niet is samengevoegd.
