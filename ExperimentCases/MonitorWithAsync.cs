namespace ExperimentCases;

public class MonitorWithAsync
{
    private readonly object _locker = new();

    public async Task AsyncLock()
    {

        Monitor.Enter(_locker);

        await Task.Delay(100);

        Monitor.Exit(_locker);
    }
}
