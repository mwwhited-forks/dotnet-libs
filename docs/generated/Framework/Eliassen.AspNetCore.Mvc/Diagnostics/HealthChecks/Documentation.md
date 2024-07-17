Here is the documentation for the `HealthCheckOptionsFactory` class, including a class diagram in PlantUML:

**HealthCheckOptionsFactory Class Documentation**

**Class Diagram:**
```
@startuml
class HealthCheckOptionsFactory {
  +Create(): HealthCheckOptions
  +Create() {
    new HealthCheckOptions() {
      Predicate: _
      ResponseWriter: async (context, report) => ...
      ResultStatusCodes: [HealthStatus.Healthy] = 200, [HealthStatus.Degraded] = 200, [HealthStatus.Unhealthy] = 503
    }
  }
}

@enduml
```
**Class Documentation:**

The `HealthCheckOptionsFactory` class is a factory class responsible for creating and configuring instances of the `HealthCheckOptions` class. This class provides a single method, `Create`, which returns a configured instance of `HealthCheckOptions`.

**Create Method:**

The `Create` method creates and configures a new instance of `HealthCheckOptions`. It sets the following properties:

* `Predicate`: The predicate that determines whether the health check is executed.
* `ResponseWriter`: The response writer that handles the response to the health check.
* `ResultStatusCodes`: A dictionary that maps health status codes to HTTP status codes.

**ResponseWriter Method:**

The `ResponseWriter` method is an asynchronous method that is called to handle the response to the health check. It writes the health check result to the response stream in JSON format. The method takes two parameters: `context` and `report`. The `context` parameter is an instance of `HttpContext`, while the `report` parameter is an instance of `HealthReport`. The method uses the `Utf8JsonWriter` class to serialize the health check result into JSON format.

**ResultStatusCodes Property:**

The `ResultStatusCodes` property is a dictionary that maps health status codes to HTTP status codes. It provides a way to customize the HTTP status code returned in response to the health check. The dictionary contains the following key-value pairs:

* `HealthStatus.Healthy`: 200 OK
* `HealthStatus.Degraded`: 200 OK
* `HealthStatus.Unhealthy`: 503 Service Unavailable

**Note:**

* The `HealthCheckOptionsFactory` class is part of the `Eliassen.AspNetCore.Mvc.Diagnostics.HealthChecks` namespace.
* The `HealthCheckOptions` class is part of the `Microsoft.AspNetCore.Diagnostics.HealthChecks` namespace.
* The `HealthReport` class is part of the `Microsoft.AspNetCore.Diagnostics.HealthChecks` namespace.