

@ECHO OFF

docker run -d -p 27017:27017 --name mongodb mongo:latest
docker start mongodb 