**Eliassen.Documents.Tests**
===============

**Introduction**

The Eliassen.Documents.Tests project is a test project for the Eliassen.Documents library, written in C# and targeting .NET 8.0. This project is used to test the functionality of the library and ensure that it is working as expected.

**Class Diagram**

```plantuml
@startuml
class TestProject {
    - projectReference: Eliassen.Documents.Eliassen.Documents
}

class EliassenDocuments {
    - method1()
    - method2()
}

TestProject ..> EliassenDocuments
@enduml
```

**Properties**

The project has the following properties:

* `TargetFramework`: set to `net8.0`, indicating the target framework for the project.
* `ImplicitUsings`: set to `false`, indicating that implicit usings are disabled for the project.
* `Nullable`: set to `enable`, indicating that nullable references are enabled for the project.
* `IsPackable`: set to `false`, indicating that the project is not packable.
* `IsTestProject`: set to `true`, indicating that the project is a test project.

**Packages**

The project references the following packages:

* `coverlet.collector`: version 6.0.2, used for code coverage analysis.
* `Microsoft.NET.Test.Sdk`: version 17.10.0, used as the test framework.
* `MSTest.TestAdapter`: version 3.4.3, used as the test adapter.
* `MSTest.TestFramework`: version 3.4.3, used as the test framework.

**Project Reference**

The project references the `Eliassen.Documents` project, which is located in the `..\Eliassen.Documents` directory.

**Sequence Diagram**

```plantuml
@startuml
participant TestRunner as tr
participant EliassenDocuments as ed

tr->>ed: Run tests
ed->>tr: Report test results
@enduml
```

In this sequence diagram, the `TestRunner` participant runs the tests against the `EliassenDocuments` participant, which reports the test results back to the `TestRunner`.