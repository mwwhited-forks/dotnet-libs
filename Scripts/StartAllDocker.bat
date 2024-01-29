
@ECHO OFF

ECHO "starting"

CALL StartRabbitMQ.bat
CALL StartAzuriteDocker.bat
CALL StartSmtp4DevDocker.bat
CALL StartMongoDbDocker.bat
CALL StartKeycloak.bat

PAUSE

REM smtp4dev
START http://localhost:7777/
REM keycloak
START http://localhost:8081/

CALL SetupAzurite.bat