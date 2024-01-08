# Game Store API

## Starting SQL Server
$sa_password = "[SA_PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest

## Settiing the connection string to secret manager
$sa_password = "[SA_PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GamesStoreContext" "Server=localhost; Database:GameStore; User Id:sa; Password=$sa_password; TrustCertificate=True"


93f0fe0a-a1e0-4264-ab4c-58bdfe5b28ae