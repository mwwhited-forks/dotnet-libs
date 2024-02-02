
@ECHO OFF

IF /I "%1" EQU "--clean" (
    docker stop mongodb
    docker remove mongodb
)

docker network create dev-net

docker run ^
--name mongodb ^
--detach ^
--publish 27017:27017 ^
--network=dev-net ^
mongo:latest

docker start mongodb 
