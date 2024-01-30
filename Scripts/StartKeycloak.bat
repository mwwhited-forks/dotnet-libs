

@ECHO OFF

IF /I "%1" EQU "--clean" (
    docker stop keycloak
    docker remove keycloak
)

docker network create dev-net

docker run ^
--name keycloak ^
--detach ^
--publish 8081:8080 ^
--env KEYCLOAK_ADMIN=admin ^
--env KEYCLOAK_ADMIN_PASSWORD=admin ^
--env KEYCLOAK_IMPORT=./local-dev-realm.json ^
--volume %cd%/keycloak-import/:/opt/keycloak/data/import/ ^
--network=dev-net ^
quay.io/keycloak/keycloak:latest ^
start-dev --import-realm

docker start keycloak 
