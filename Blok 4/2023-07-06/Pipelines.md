Azure DevOps Pipelines maken gebruik van een specifieke taal genaamd YAML (Yet Another Markup Language) om de stappen van de pipeline te definiëren. Deze taal is gemakkelijk leesbaar voor mensen en wordt vaak gebruikt voor configuratiebestanden.

Hier is een kort overzicht van de belangrijkste concepten die je moet kennen:

- **Stages**: Een pipeline kan meerdere stadia hebben, zoals `Build`, `Test`, en `Deploy`. Elk stadium bevat één of meerdere jobs.

- **Jobs**: Jobs zijn de bouwstenen van een pipeline en bevatten een reeks stappen die worden uitgevoerd.

- **Steps**: Een stap kan een script zijn dat je wilt uitvoeren of een taak die is gedefinieerd door Azure Pipelines.

- **Variables**: Je kunt variabelen in je YAML-bestand definiëren die je kunt gebruiken in je stappen.

- **Triggers**: Je kunt aangeven wanneer een pipeline moet worden uitgevoerd. Bijvoorbeeld bij elke commit naar een specifieke branch.

- **Conditions**: Met conditions kun je bepaalde taken alleen onder bepaalde omstandigheden uitvoeren.

Let op, dit is slechts een inleiding. YAML voor Azure DevOps Pipelines heeft veel meer mogelijkheden, zoals templates, environments, deployments, en nog veel meer.

```yaml
trigger:
  - "*"
variables:
  - name: "WorkingDir"
    value: "Blok\ 3/CASE-AE"
pool:
  vmImage: ubuntu-latest
steps:
  - script: dotnet restore
    workingDirectory: $(WorkingDir)
    displayName: "⤵ Restore"
  - script: dotnet build
    workingDirectory: $(WorkingDir)
    displayName: "🏗 Build"
  - script: dotnet test
    workingDirectory: $(WorkingDir)
    displayName: "🧪 Test"
  - script: dotnet publish --configuration Release
    displayName: "🎁 Publish"
    workingDirectory: $(WorkingDir)
  - script: docker compose build
    displayName: "📦 Docker build"
    workingDirectory: $(workingDir)
  - script: echo $(DOCKER_PASSWORD) | docker login kcbdregistry.azurecr.io --username $(DOCKER_USERNAME) --password-stdin
    displayName: "🔑 Docker login"
    workingDirectory: $(workingDir)
    condition: in(variables['Build.SourceBranch'], 'refs/heads/main', 'refs/heads/master')
  - script: docker compose push
    displayName: "🚀 Docker push"
    workingDirectory: $(workingDir)
    condition: in(variables['Build.SourceBranch'], 'refs/heads/main', 'refs/heads/master')

```

 Hieronder zal ik een uitleg geven van de verschillende delen van deze pipeline:

```yaml
trigger:
  - "*"
```
Het `trigger` gedeelte bepaalt wanneer de pipeline moet starten. De `*` betekent dat de pipeline start voor elke commit op elke branch.

```yaml
variables:
  - name: "WorkingDir"
    value: "Blok\ 3/CASE-AE"
```
Hier definiëren we een variabele genaamd `WorkingDir` die we later in de pipeline zullen gebruiken. De waarde is het pad naar de map waar we gaan werken.

```yaml
pool:
  vmImage: ubuntu-latest
```
Het `pool` gedeelte definieert de virtuele machine (VM) waarop de pipeline zal draaien. In dit geval is dat de meest recente versie van Ubuntu.

```yaml
steps:
  - script: dotnet restore
    workingDirectory: $(WorkingDir)
    displayName: "⤵ Restore"
```
Het `steps` gedeelte bevat de verschillende taken die in de pipeline worden uitgevoerd. Elk script is een aparte taak die wordt uitgevoerd. In dit geval hebben we taken om afhankelijkheden te herstellen (`dotnet restore`), de code te compileren (`dotnet build`), tests uit te voeren (`dotnet test`), de applicatie te publiceren (`dotnet publish`), een Docker-image te bouwen (`docker compose build`), in te loggen bij Docker (`docker login`), en de Docker-image naar een repository te pushen (`docker compose push`). 

De `workingDirectory` optie bepaalt de map waarin de taak wordt uitgevoerd, en `displayName` is een leesbare naam voor de taak die in de Azure DevOps-gebruikersinterface wordt weergegeven.

```yaml
condition: in(variables['Build.SourceBranch'], 'refs/heads/main', 'refs/heads/master')
```
De `condition` optie wordt gebruikt om te bepalen of een bepaalde taak wordt uitgevoerd of niet. In dit geval worden de Docker login en push taken alleen uitgevoerd als de bronbranch van de build `main` of `master` is.

Over het algemeen zorgt deze YAML-definitie voor een pipeline die de code bouwt, test, publiceert en implementeert bij elke commit, met specifieke stappen die alleen worden uitgevoerd op de `main` of `master` branch.