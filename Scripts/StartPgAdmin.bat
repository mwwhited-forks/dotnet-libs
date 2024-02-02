docker run -p 8082:80 ^
--name pgadmin ^
-e PGADMIN_DEFAULT_EMAIL=admin@domain.com ^
-e PGADMIN_DEFAULT_PASSWORD=admin ^
-e PGADMIN_CONFIG_ENHANCED_COOKIE_PROTECTION=True ^
-e PGADMIN_CONFIG_LOGIN_BANNER="Authorised users only!" ^
-e PGADMIN_CONFIG_CONSOLE_LOG_LEVEL=10 ^
-d dpage/pgadmin4

docker start pgadmin