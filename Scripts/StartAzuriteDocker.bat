
@ECHO OFF

IF /I "%1" EQU "--clean" (
    docker stop azurite
    docker remove azurite
)

docker network create dev-net

docker run ^
--name azurite ^
--detach ^
--publish 10000:10000 ^
--publish 10001:10001 ^
--publish 10002:10002 ^
--network=dev-net ^
mcr.microsoft.com/azure-storage/azurite

docker start azurite 
