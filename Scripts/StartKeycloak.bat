docker run ^
--name keycloak ^
--publish 8081:8080 ^
--env KEYCLOAK_ADMIN=admin ^
--env KEYCLOAK_ADMIN_PASSWORD=admin ^
--env KEYCLOAK_IMPORT=./local-dev-realm.json ^
--volume %cd%/keycloak-import/:/opt/keycloak/data/import/ ^
quay.io/keycloak/keycloak:latest ^
start-dev --import-realm

docker start keycloak 
