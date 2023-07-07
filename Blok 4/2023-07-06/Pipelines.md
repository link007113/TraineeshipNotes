Azure-pipeline bestand in root van solution

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