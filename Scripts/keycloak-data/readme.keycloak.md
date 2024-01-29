
## Connect

```bash
docker exec -it keycloak /bin/bash
```


## Restore

```bash

export DATA_PATH=/tmp/keycloak-data
export KCADMIN_CONFIG=$DATA_PATH/kcadm.config
cd /bin
./kcadm.sh config credentials --server http://localhost:8080 --realm master --user admin --password admin --config $KCADMIN_CONFIG

./kcadm.sh create realms --file $DATA_PATH/realm-export.json --config $KCADMIN_CONFIG

./kcadm.sh create clients --target-realm local-dev --file $DATA_PATH/client-dotnet-webapi.json --config $KCADMIN_CONFIG
# ./kcadm.sh create clients --target-realm local-dev --file $DATA_PATH/client-node-express.json --config $KCADMIN_CONFIG
# ./kcadm.sh create clients --target-realm local-dev --file $DATA_PATH/client-java-springboot.json --config $KCADMIN_CONFIG

./kcadm.sh create users --target-realm local-dev --set username=adele --set enabled=true --set firstName=Adele --set lastName=Admin --set email=adele@fake.io --config $KCADMIN_CONFIG
./kcadm.sh set-password --target-realm local-dev --username adele --new-password Adele123! --config $KCADMIN_CONFIG

```