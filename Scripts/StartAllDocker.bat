
@ECHO OFF

ECHO "starting"

CALL StartRabbitMQ.bat %1
CALL StartAzuriteDocker.bat %1
CALL StartSmtp4DevDocker.bat %1
CALL StartMongoDbDocker.bat %1
CALL StartKeycloak.bat %1

PAUSE

REM smtp4dev
START http://localhost:7777/
REM keycloak
START http://localhost:8081/

CALL SetupAzurite.bat