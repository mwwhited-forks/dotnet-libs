

@ECHO OFF

docker run -d --name smtp4dev -p 7777:80 -p 25:25 -p 143:143 -p 110:110 rnwood/smtp4dev
docker start smtp4dev 