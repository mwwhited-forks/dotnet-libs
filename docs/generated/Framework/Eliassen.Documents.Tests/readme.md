Here is a README file that summarizes the functionality and technical details of the provided source files:

**README**

This repository contains a C# project for testing Eliassen.Documents, a .NET library for document manipulation. The project is designed to test the functionality of Eliassen.Documents using the Microsoft Test Framework and Coverlet for code coverage analysis.

**Summary**

The project consists of a test project, Eliassen.Documents.Tests, which references the Eliassen.Documents library. The tests are written using the Microsoft Test Framework and cover various aspects of the library's functionality. The project uses Coverlet to collect code coverage data and report on the test results.

**Technical Summary**

The project uses the following design patterns and architectural patterns:

* **MVC (Model-View-Controller)**: The Eliassen.Documents library is designed as a .NET library, which can be used as a Model component in an MVC application. The tests can be seen as a View component, exercising the functionality of the library and verifying the expected results.
* **Dependency Injection**: The project references the Eliassen.Documents library, which can be seen as a dependency that needs to be injected into the test project.

**Component Diagram**

```plantuml
@startuml
component "Eliassen.Documents" as lib
component "Eliassen.Documents.Tests" as tests
component "Microsoft Test Framework" as test_framework
component "Coverlet" as coverlet

tests -> lib: Reference
test_framework -> tests: Test Framework
coverlet -> tests: Code Coverage Analysis

lib -.> tests: Depend on
test_framework -.> tests: Depend on
coverlet -.> tests: Depend on

@enduml
```

In this diagram, the Eliassen.Documents library is the central component, which is referenced by the Eliassen.Documents.Tests project. The tests project uses the Microsoft Test Framework and Coverlet to exercise the functionality of the library and collect code coverage data.