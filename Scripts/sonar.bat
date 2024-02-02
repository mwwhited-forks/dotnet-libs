
docker run ^
--detach ^
--name sonarqube ^
--env SONAR_ES_BOOTSTRAP_CHECKS_DISABLE=true ^
--publish 9000:9000 ^
--volume %cd%\..\..\sonarqube\data:/opt/sonarqube/data ^
--volume %cd%\..\..\sonarqube\extensions:/opt/sonarqube/extensions ^
--volume %cd%\..\..\sonarqube\logs:/opt/sonarqube/logs ^
sonarqube:latest
