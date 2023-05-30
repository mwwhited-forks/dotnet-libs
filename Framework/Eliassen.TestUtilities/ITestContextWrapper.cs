using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eliassen.TestUtilities
{
    public interface ITestContextWrapper
    {
        TestContext Context { get; }
    }
}
