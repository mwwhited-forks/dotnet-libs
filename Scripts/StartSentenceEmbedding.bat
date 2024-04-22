
@ECHO OFF

docker build --tag sbert .\sentence-embedding

docker run --rm --interactive --tty --name sbert --detach --publish 5080:5000 sbert
