using ExperimentCases;

namespace MY.NET.BestPractices.UnitTests;

public class MonitorWithAsyncTests
{
    [Fact]
    public void TestMonitor()
    {
        var obj = new MonitorWithAsync();

        Assert.Throws<SynchronizationLockException>(() => obj.AsyncLock().GetAwaiter().GetResult());
    }
}
