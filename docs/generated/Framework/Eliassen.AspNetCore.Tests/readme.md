**README**

This repository contains the tests for the Eliassen.AspNetCore.JwtAuthentication, Eliassen.AspNetCore.Mvc, and Eliassen.TestUtilities projects. The tests are written using Microsoft's MSTest framework and are designed to verify the functionality of each project.

**Technical Summary**

The test project is built using the .NET 8.0 framework and utilizes the following design patterns and architectural patterns:

* **MVC Pattern**: The Eliassen.AspNetCore.Mvc project follows the Model-View-Controller pattern, where the controller handles incoming requests, interacts with the model, and returns a response to the view.
* **Repository Pattern**: The Eliassen.AspNetCore.JwtAuthentication project uses the Repository pattern to abstract the data access layer and provide a layer of abstraction between the business logic and the data storage.

**Component Diagram**

Here is a high-level component diagram of the system using PlantUML:
```plantuml
@startuml
class Eliassen.AspNetCore.Mvc(MVC)
class Eliassen.AspNetCore.JwtAuthentication(Authentication)
class Eliassen.TestUtilities(TestUtilities)

Eliassen.AspNetCore.Mvc --* Eliassen.AspNetCore.JwtAuthentication
Eliassen.AspNetCore.Mvc --* Eliassen.TestUtilities

note "Test Driven Development"
@enduml
```