# Lightwell Shared Framework - Test Utilities

# Summary 

This library is intended to simplify and improve test coverage.

# Extensions

## TestContextExtensions

Various extension methods for use with TestContext.

### .AddResult(...)


#### Example

Test Class

```csharp
[TestClass]
public class TextContextExtensionsTests
{
	public class TestData
	{
		public string Property1 { get; set; } = "Hello World!";
	}
		
    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void AddResultTest_Object()
    {
        var value = new TestData();

        var context = TestContext.AddResult(value);

        Assert.AreEqual(TestContext, context)
        Assert.IsTrue(Directory.EnumerateFiles(context.TestRunResultsDirectory, "*.json").Any());
    }
}
```

Test results file attachment `TestData_{timestamp in ticks}.json`

```json
{
  "Property1": "Hello World!"
}
```

Serialize input objects and attach their contents to the test results output as an attached file.

### .AddResultFile(…)

Write named binary content to the test results output as an attached file.

### .GetTestDataAsync<>(…)

Read and deserialize an embedded resource as a .Net Object for use in your test class.

While you can pass in a "target" name.  If you do not include a target the system will 
try to use the test namespace, class name and test name to resolve the resource.

#### Example

Test Class

```csharp
[TestClass]
public class TextContextExtensionsTests
{
	public class TestData
	{
		public string Property1 { get; set; } = "Hello World!";
	}

	[TestMethod]
	[TestCategory(TestCategories.Unit)]
	public async Task GetTestDataAsyncTest()
	{
		var result = await TestContext.GetTestDataAsync<TestData>();

		Assert.IsNotNull(result);
		Assert.AreEqual("Hello World!", result.Property1);
	}
)
```

Embedded Resource named `TextContextExtensionsTests_GetTestDataAsyncTest.json`

```json
{
  "Property1": "Hello World!"
}
```

## Configuration.TupleConfiguration

This class allows for a quick way of declaring a complex set of configurations for testing.

### Example

```csharp
[TestClass]
public class TupleConfigurationTests
{
    public TestContext? TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void ConfigIndexerTest()
    {
        IConfiguration config = new TupleConfiguration(
            ("Key1", "Value"),
            ("Key3", "Value2")
            );

        Assert.IsNotNull(config["Key1"]);
        Assert.IsNull(config["Key2"]);
        Assert.AreEqual("Value", config["Key1"]);
    }
}
```

## EntityFrameworkCore.EnumerableExtensions

Extensions methods for IEnumerable<> types to convert to mocked IQueryable<> and DbSet<>

### AsTestableQueryable()

Convert IEnumerable<> into assertable IQueryable<>

#### Examples

```csharp
[TestClass]
public class EnumerableExtensionsTests
{
    public TestContext? TestContext { get; set; }

    public class TestData
    {
        public string Property1 { get; set; }
    }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void AsTestableQueryableTest()
    {
        var items = new[]
        {
            new TestData{ Property1="Value 1"},
            new TestData{ Property1="Value 2"},
        };

        var result = items.AsTestableQueryable();

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
    }
}
```

### AsTestableDbSet()

Convert IEnumerable<> into assertable DBSet<>

#### Examples

```csharp
[TestClass]
public class EnumerableExtensionsTests
{
    public TestContext? TestContext { get; set; }

    public class TestData
    {
        public string Property1 { get; set; }
    }
        
    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void AsTestableDbSetTest()
    {
        var items = new[]
        {
            new TestData{ Property1="Value 1"},
            new TestData{ Property1="Value 2"},
        };

        var result = items.AsTestableDbSet();

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
    }
}
```

### AsMockedDbSet()

Convert IEnumerable<> into mocked DBSet<>

#### Examples

```csharp
[TestClass]
public class EnumerableExtensionsTests
{
    public TestContext? TestContext { get; set; }

    public class TestData
    {
        public string Property1 { get; set; }
    }
        
    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void AsMockedDbSetTest()
    {
        var items = new[]
        {
            new TestData{ Property1="Value 1"},
            new TestData{ Property1="Value 2"},
        };

        var mockRepository = new MockRepository(MockBehavior.Strict);

        var result = items.AsMockedDbSet(mockRepository);

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Object.Count());

        mockRepository.Verify();
    }
}
```

## Logging.TestLoggerExtensions

This is a helper to create ILogger<> instances that will redirect logs to the TestContext results.

### .AddTestLoggingServicesTest()

This will setup the ILoggerFactory to test dependency injection features

#### Example

```csharp
[TestClass]
public class TestLoggerExtensionsTests
{
    public TestContext? TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void AddTestLoggingServicesTest()
    {
        var services = new ServiceCollection()
            .AddTestLoggingServices(TestContext)
            .BuildServiceProvider()
            ;

        var logger = services.GetRequiredService<ILogger<TestLoggerExtensionsTests>>();
        logger.LogInformation("Test Message");
    }
}
```

```test output
TestContext Messages:
Eliassen.TestUtilities.Tests.Logging.TestLoggerExtensionsTests-LOG>Information(0): Test Message
```

### .GetTestLoggingServices<T>()

This creates an instance of ILogger<T> with the results redirected to the test context results.  
When used in combination with mocked operations the expected test results may be observed in the 
test output results.  It is suggested to replace generated Mock<ILogger<T>> with this extension.

#### Example

```csharp
[TestClass]
public class TestLoggerExtensionsTests
{
    public TestContext? TestContext { get; set; }

    [TestMethod]
    [TestCategory(TestCategories.Unit)]
    public void GetTestLoggingServicesTest()
    {
        var logger = TestContext.GetTestLoggingServices<TestLoggerExtensionsTests>();
        Assert.IsNotNull(logger);
        logger.LogInformation("Test Message");
    }
}
```

```test output
TestContext Messages:
Eliassen.TestUtilities.Tests.Logging.TestLoggerExtensionsTests-LOG>Information(0): Test Message
```
