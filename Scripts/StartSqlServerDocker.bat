
@ECHO OFF

IF /I "%1" EQU "--clean" (
    docker stop sql-server 
    docker remove sql-server 
)

docker network create dev-net

docker run ^
--name sql-server  ^
--detach ^
--publish 1433:1433 ^
--env ACCEPT_EULA=Y ^
--env MSSQL_SA_PASSWORD=nucleus ^
--network=dev-net ^
mcr.microsoft.com/mssql/server:2022-latest

docker start sql-server  
