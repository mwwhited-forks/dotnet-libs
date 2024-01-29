
@ECHO OFF

IF /I "%1" EQU "--clean" (
    docker stop rabbitmq
    docker remove rabbitmq
)

docker network create dev-net

docker run ^
--name rabbitmq ^
--detach ^
--publish 5672:5672 ^
--publish 15672:15672 ^
--network=dev-net ^
rabbitmq:latest

docker start rabbitmq 
