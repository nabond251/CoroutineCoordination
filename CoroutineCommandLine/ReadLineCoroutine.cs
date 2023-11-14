namespace CoroutineCommandLine;

using System.Collections;

public class ReadLineCoroutine : IEnumerable<ReadLineSink>
{
    public ReadLineSource? NextValue { get; set; }

    public IEnumerator<ReadLineSink> GetEnumerator()
    {
        yield return new ReadLineSink.ReadLine();
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}
