# Example Endpoints and Port Numbers

## Web Links

* [Open-WebUI (Ollama)](http://localhost:3000/)
* [Qdrant](http://localhost:6333/dashboard)
* [SMTP4DEV](http://localhost:7777/)
* [Keycloak](http://localhost:8081/)
* [Apache - Tika](http://localhost:9998/)
* [PG Admin](http://localhost:8082/)

## Passwords

| Service    | Username | Password       | 
|------------|----------|----------------|
| OpenSearch | admin    | El14ss3nGr0up! |
| SQL Server | sa       | El1@ssen       |
| ParadeDB   | admin    | admin          |

## Port List

| Service        | Protocol | Port       | 
|----------------|----------|------------|
| smtp4dev       | smtp     |         25 |
| smtp4dev       | imap     |        143 |
| smtp4dev       | pop3     |        110 |
| sql-server     | tcp      |       1433 |
| open-webui     | http     |       3000 |
| localstack     | tcp      |       4566 |
| localstack     | tcp      |  4510-4559 |
| sbert          | tcp      |       5080 |
| paradedb       | tcp      |       5432 | eliassen-libs-dev-paradedb-1:5432
| RabbitMQ       | tcp      |       5672 |
| qdrant         | http     |       6333 |
| qdrant         | grpc     |       6334 |
| smtp4dev       | http     |       7777 |
| Keycloak       | http     |       8081 |
| PG Admin       | http     |       8082 |
| Kafka          | tcp      |       9092 |
| Kafka          | tcp      |       9094 |
| OpenSearch     | tcp      |       9200 |
| OpenSearch     | tcp      |       9600 |
| Apache Tika    | tcp      |       9998 |
| Azurite        | tcp      |      10000 |
| Azurite        | tcp      |      10001 |
| Azurite        | tcp      |      10002 |
| ollama         | tcp      |      11434 | eliassen-libs-dev-ollama-1:11434
| RabbitMQ       | tcp      |      15672 |
| MongoDB        | tcp      |      27017 |

## Supported Systems

- Databases
  - Relational
    - Postgresql / ParadeDB
  - Vector Store
    - Qdrant
  - Document Database
    - Azure CosmosDB
    - MongoDB
- Blob Storage
  - 
- Telemetry
  - [OpenTelemetry](https://opentelemetry.io/)
  - Metric Collection
    - [Prometheus](https://prometheus.io/docs/introduction/overview/)
  - Tracing
    - [Jaeger](https://www.jaegertracing.io/)
  - Dashboard
    - [Grafana](https://grafana.com/)
