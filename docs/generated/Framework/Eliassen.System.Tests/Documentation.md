Here is the documentation for the provided source code files, including a class diagram in PlantUML:

**Documentation:**

**Eliassen.System.Tests.csproj**

This is a .NET Core project file for a test project named "Eliassen.System.Tests". The project targets .NET 8.0 and uses the Microsoft.NET.Sdk framework. It includes multiple NuGet package references, including Microsoft.NET.Test.Sdk, Moq, MSTest.TestAdapter, and MSTest.TestFramework.

**NuGet Packages:**

* Microsoft.NET.Test.Sdk (version 17.10.0): A base class library for testing .NET applications.
* Moq (version 4.20.70): A library for creating mock objects for unit testing.
* MSTest.TestAdapter (version 3.4.3): A test adapter for running MSTest tests in Visual Studio.
* MSTest.TestFramework (version 3.4.3): A test framework for creating and running MSTest tests.
* coverlet.collector (version 6.0.2): A package for collecting coverage metrics for .NET applications.

**Project References:**

* Eliassen.System.csproj: A project reference to the main Eliassen.System project.
* Eliassen.TestUtilities.csproj: A project reference to the Eliassen.TestUtilities project.

**Class Diagram:**

Here is a class diagram for the Eliassen.System.Tests project using PlantUML:
```
@startuml
class EliassenSystemTests {
  - tests: List&lt;Test&gt;
  + RunAllTests(): void
  + RunTest(Test test): void
}

interface Test {
  + Run(): void
}

class MyTest : Test {
  - myProperty: string
  + Run(): void
}

EliassenSystemTests --* Test
Test --* MyTest
@enduml
```
The class diagram shows the EliassenSystemTests class, which has a list of tests and methods to run all tests or a single test. The Test interface is implemented by the MyTest class, which has a single method to run the test. The classes are related through associations, showing the relationships between the classes.

Note: As the project does not contain any actual source code files, the class diagram is hypothetical and represents the expected relationships between classes based on the project file.