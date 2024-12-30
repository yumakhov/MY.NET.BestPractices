using System.Collections.Concurrent;

namespace ExperimentCases;


public class ConcurrentDictionaryWithInterlocked
{
    public object _lock = new object();

    private int _count;
    public readonly ConcurrentDictionary<int, string> _dictionary = new();

    public void Add(string str)
    {
        var i = _count++;
        _dictionary[i] = str;

        //var i = Interlocked.Increment(ref _count);
        //_dictionary[i] = str;

        //lock (_lock)
        //{
        //    var i = Interlocked.Increment(ref _count);
        //    _dictionary[i] = str;
        //}
    }
}
