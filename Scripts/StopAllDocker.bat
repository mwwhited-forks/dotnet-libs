
@ECHO OFF

ECHO "stopping"

docker stop mongodb
docker stop smtp4dev
docker stop azurite
docker stop rabbitmq
docker stop sql-server  
docker stop keycloak