# Eliassen System Tests Documentation
### Project Description

The Eliassen System Tests project is a .NET Core test project that contains unit tests for the Eliassen System and Test Utilities projects. This project uses the Microsoft.NET.Test.Sdk, Moq, and MSTest.TestAdapter and MSTest.TestFramework libraries for testing and coverage analysis.

### Class Diagram
```plantuml
@startuml
class TestProject {
  - testFrameworks: MSTest.TestFramework
  - testAdapters: MSTest.TestAdapter
  - dependencies: Eliassen.System, Eliassen.TestUtilities
}

class Eliassen_System {
  - dependencies: 
}

class Eliassen_TestUtilities {
  - dependencies: 
}

TestProject --|> MSTest.TestFramework
MSTest.TestFramework --|> MSTest.TestAdapter
MSTest.TestAdapter -->| Eliassen_System
Eliassen_System --|> Eliassen_TestUtilities
@enduml
```

### Component Model
```plantuml
@startuml
!include ./TestProject.puml

composite TestProject {
 [*] TestProject
  <-- Dependency >| MSTest.TestFramework
  <-- Dependency >| MSTest.TestAdapter
  <-- Dependency >| Eliassen.System
  <-- Dependency >| Eliassen.TestUtilities
}
@enduml
```

### Sequence Diagram
```plantuml
@startuml
actor User
 participant Tester1 as Tester
 participant Eliassen_System as System
 participant Eliassen_TestUtilities as Utilities

 sequenceDiagram
  User->>Tester: Run Tests
  Tester->>System: Get System Under Test
  System->>Tester: Initialize Tests
  Tester->>Utilities: Get Utilities Under Test
  Utilities->>Tester: Initialize Tests
  Tester->>System: Run System Tests
  System->>Tester: Run Tests Complete
  Tester->>User: Tests Report
  User->>Tester: Receive Tests Report

@enduml
```

### csproj File Documentation
The `Eliassen.System.Tests.csproj` file is the project file for the Eliassen System Tests project.

The file uses the `Microsoft.NET.Sdk` as its SDK, and sets the target framework to .NET 8.0. It disables implicit usings and enables nullable reference types.

The file also references several NuGet packages, including `Microsoft.NET.Test.Sdk`, `Moq`, `MSTest.TestAdapter`, `MSTest.TestFramework`, and `coverlet.collector`.

Finally, the file references two other project files: `Eliassen.System.csproj` and `Eliassen.TestUtilities.csproj`, which are the projects that the tests are written against.