
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=nucleus" ^
   -p 1433:1433 --name sql-server --hostname  sql-server ^
   -d ^
   mcr.microsoft.com/mssql/server:2022-latest

docker start sql-server    