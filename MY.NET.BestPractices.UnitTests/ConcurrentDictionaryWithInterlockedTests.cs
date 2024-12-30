using ExperimentCases;
using System.Text;

namespace MY.NET.BestPractices.UnitTests;

public class ConcurrentDictionaryWithInterlockedTests
{
    [Fact]
    public async Task Test1()
    {
        var obj = new ConcurrentDictionaryWithInterlocked();
        var list = new List<Task>();

        for (int i = 0; i < 10; i++)
        {
            var j = i;
            list.Add(Task.Factory.StartNew(() => {
                obj.Add($"Str_{j}_Thread_{Environment.CurrentManagedThreadId}");
            }, TaskCreationOptions.LongRunning));
        }

        await Task.WhenAll(list);

        var sb = new StringBuilder();
        foreach (var item in obj._dictionary)
        {
            sb.AppendLine($"{item.Key} : {item.Value}");
        }

        var result = sb.ToString();
    }
}
