
Git is een gedistribueerd versiebeheersysteem. Het stelt meerdere ontwikkelaars in staat om aan hetzelfde project te werken zonder conflicten te veroorzaken, en biedt een gedetailleerde geschiedenis van wie wat heeft gedaan en wanneer.

## Versiebeheersystemen

Er zijn drie generaties versiebeheersystemen:

1. **Eerste generatie**: Lokaal, bestand-locking systemen.
2. **Tweede generatie**: Gecentraliseerde systemen zoals SVN en TFS. Alle bestanden en geschiedenis worden opgeslagen op een centrale server.
3. **Derde generatie**: Gedecentraliseerde systemen zoals Git en Mercurial. Elke ontwikkelaar heeft een volledige kopie van de repository op hun lokale machine.

## Git Basics

Git identificeert commits en objecten met behulp van een SHA-1 hash. Dit is een "one-way" encryptie die berekend wordt op basis van de inhoud van de bestanden. Het zorgt voor unieke ID's voor objecten en controleert of de inhoud nog steeds overeenkomt met de hash.

### Commando's

- `git init`: Maakt een nieuwe Git repository aan. Met de `--bare` optie wordt een kale repository aangemaakt die bedoeld is voor opslag/server gebruik, niet voor ontwikkeling. Het mist een 'working directory'.
- `git add`: Voegt veranderingen toe aan de staging area.
- `git commit`: Commit de staged veranderingen naar de repository.

## Git Branches

Een branch in Git is een lichte, verplaatsbare aanwijzing naar een van deze commits. Het is een manier om te experimenteren met nieuwe ideeën en functies zonder de hoofdcodebasis te beïnvloeden.

### Merge en Merge Conflicts

- `git merge`: Combineert de veranderingen van één branch naar een andere. Er zijn twee soorten merges:
    - **Fast-forward merge**: De huidige branch wordt gewoon "doorgespoeld" naar de nieuwste commit van de te mergen branch.
    - **Merge commit**: Maakt een nieuwe commit die de samenvoeging van de twee branches representeert.
- Merge conflicts ontstaan wanneer Git niet automatisch de veranderingen tussen twee branches kan combineren. Ze worden opgelost door de conflicterende delen in een teksteditor te bewerken, en dan `git add` en `git commit` uit te voeren om de opgeloste conflicten op te slaan.

## Geavanceerde Git Commando's

- `git switch`: Wisselt tussen branches. `git switch -` gaat terug naar de vorige branch.
- `git fetch`: Haalt objecten op van de remote en updatet de remote branches.
- `git pull`: Een combinatie van `git fetch` en `git merge`. Haalt updates op van de remote en integreert ze in de huidige branch.
- `git clone`: Kopieert een remote Git repository naar je lokale machine.
- `git log`: Toont de commit-geschiedenis. Opties zoals `-10`, `--oneline`, en `--graph` kunnen worden gebruikt om de output te wijzigen.
- `git cat-file`: Laat de inhoud zien van Git objecten. `-p` voor print, `-t` om het type te zien.

## Verschil tussen SVN en Git

SVN is een gecentraliseerd versiebeheersysteem. Alle versiegeschiedenis wordt opgeslagen op een centrale server. In tegenstelling daarmee is Git gedecentraliseerd: elke ontwikkelaar heeft een volledige kopie van de repository en de geschiedenis op hun eigen machine. Dit maakt Git flexibeler en krachtiger, maar kan in sommige gevallen ook complexer zijn om te beheren.
