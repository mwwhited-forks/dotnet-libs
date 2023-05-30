namespace Eliassen.TestUtilities
{
    public static class TestCategories
    {
        public const string Unit = "Unit";
        public const string Simulation = "Simulate";
        public const string Integration = "Integration";
        public const string DevLocal = "DevLocal";

        public static class Feature
        {
            public const string StartupRegistration = "StartupRegistration";
            public const string Billing = "Billing";
            public const string BlobStorage = "BlobStorage";
            public const string MessageQueueing = "MessageQueueing";
            public const string CommunicationCenter = "CommunicationCenter";
            public const string TextGeneration = "TextGeneration";
            public const string DocumentConversion = "DocumentConversion";
        }
    }
}
