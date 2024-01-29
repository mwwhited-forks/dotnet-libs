docker run ^
--name keycloak ^
--publish 8081:8080 ^
--env KEYCLOAK_ADMIN=admin ^
--env KEYCLOAK_ADMIN_PASSWORD=admin ^
--volume %cd%/keycloak-data/:/tmp/keycloak-data/ ^
quay.io/keycloak/keycloak:latest ^
start-dev

docker start keycloak 
