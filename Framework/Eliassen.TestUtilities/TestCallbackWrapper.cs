namespace Eliassen.TestUtilities
{
    public class TestCallbackWrapper : ITestCallbackWrapper
    {
        public TestCallbackHandler? ServiceRequest { get; set; }
        public TestPublishEvent? PublishEvent { get; set; }
    }
}
