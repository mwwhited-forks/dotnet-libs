
@ECHO OFF

CALL StartRabbitMQ.bat
CALL StartAzuriteDocker.bat
CALL StartSmtp4DevDocker.bat
CALL StartMongoDbDocker.bat

START http://localhost:7777/

CALL SetupAzurite.bat