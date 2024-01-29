
@ECHO OFF

CALL StopAllDocker.bat

ECHO "removing"

docker remove mongodb
docker remove smtp4dev
docker remove azurite
docker remove rabbitmq
docker remove sql-server  
docker remove keycloak