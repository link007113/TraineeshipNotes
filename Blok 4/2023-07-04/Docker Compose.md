Docker Compose is een tool die wordt gebruikt om multi-container Docker-applicaties te definiëren en uit te voeren. Met Docker Compose kun je de services van je toepassing configureren in een YAML-bestand. Dit bestand beschrijft de services die de applicatie vormen (zoals een webserver en een database), de Docker-images voor elke service, netwerk- en volumeconfiguraties, enzovoort. 

Als je het Docker Compose-bestand eenmaal hebt gemaakt, kun je alle services met slechts één commando starten: `docker-compose up`.

De voordelen van Docker Compose omvatten:

- **Meerdere geïsoleerde omgevingen op een enkele host**: Je kunt op een enkele machine meerdere kopieën van een ontwikkelomgeving maken, elk geïsoleerd van de anderen.

- **Behoud van volumegegevens**: Docker Compose bewaart alle volumegegevens wanneer je containers opnieuw opstart.

- **Enkel host daemon**: Alles draait op een enkele Docker-daemon, waardoor het gemakkelijker is om omgevingsvariabelen te beheren.

- **Efficiëntie**: De `docker-compose.yml`-bestandsindeling maakt het definiëren en delen van multi-container toepassingen eenvoudig en beheersbaar, wat bijdraagt aan de efficiëntie.

Samengevat, Docker Compose is een krachtig hulpmiddel dat ontwikkelaars helpt om complexe applicaties met meerdere containers eenvoudiger te beheren. Met Docker Compose kunnen ze hun Docker-omgevingen op een eenvoudige en geautomatiseerde manier definiëren en beheren.


```yaml
version: '3'

services:
  app:
    build: 
      context: ./Todo
      dockerfile: Dockerfile
    ports:
      - 3000:80
    image: todo-app:latest
    environment:
      ConnectionStrings__TodoContext: 'Server=db; Database=tododb; User=sa; Password=MyL1ttlePony123!!; TrustServerCertificate=true;'
  db:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      MSSQL_SA_PASSWORD: 'MyL1ttlePony123!!'
      ACCEPT_EULA: Y
```
