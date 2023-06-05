using System;

namespace Eliassen.TestUtilities
{

    public delegate void TestPublishEvent(Type type, string eventName, object? details);
    public delegate object? TestCallbackHandler(Type type, object? service, string operation, object? request);
    public interface ITestCallbackWrapper
    {
        TestCallbackHandler? ServiceRequest { get; set; }
        TestPublishEvent? PublishEvent { get; set; }
    }
}
