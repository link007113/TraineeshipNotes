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
