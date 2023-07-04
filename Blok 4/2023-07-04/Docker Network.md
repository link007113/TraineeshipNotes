``` bash
cd Todo
dotnet publish --configuration Release
docker build -t todo .
docker network create todonetwork
docker run -h sql --network todonetwork -e "ACCEPT_EULA=Y" -e 'MSSQL_SA_PASSWORD=MyL1ttlePony123!!' -p 1433:1433 -d --name sql-todo mcr.microsoft.com/mssql/server:2022-latest 
docker run --name todo-app --network todonetwork -p 5001:80 -e 'ConnectionStrings__TodoContext=Server=sql; Database=tododb; User=sa; Password=MyL1ttlePony123!!; TrustServerCertificate=true;' todo
```
