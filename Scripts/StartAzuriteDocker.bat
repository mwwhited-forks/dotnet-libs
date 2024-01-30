
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
--volume %cd%/azurite-scripts/:/opt/azurite/scripts/ ^
--network=dev-net ^
mcr.microsoft.com/azure-storage/azurite ^
azurite ^
--blobPort 10000 ^
--blobHost 0.0.0.0 ^
--queuePort 10001 ^
--queueHost 0.0.0.0 ^
--tablePort 10002 ^
--tableHost 0.0.0.0 ^
--loose ^
--skipApiVersionCheck ^
--disableProductStyleUrl

REM --volume %cd%/azurite-workspace/:/workspace/ ^

REM --location /workspace ^
REM --debug /workspace/debug.log ^

docker start azurite 

TIMEOUT /T 600 
CALL SetupAzurite.bat