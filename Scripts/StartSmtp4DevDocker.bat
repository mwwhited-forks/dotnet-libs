
@ECHO OFF

IF /I "%1" EQU "--clean" (
    docker stop smtp4dev
    docker remove smtp4dev
)

docker network create dev-net

docker run ^
--name smtp4dev ^
--detach ^
--publish 7777:80 ^
--publish 25:25 ^
--publish 143:143 ^
--publish 110:110 ^
--network=dev-net ^
rnwood/smtp4dev

docker start smtp4dev 