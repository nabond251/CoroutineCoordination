namespace CoroutineCommandLine;

using System.Collections;

public class ReadLineCoroutine : IEnumerable<Unit>
{
    public string? NextValue { get; set; }

    public IEnumerator<Unit> GetEnumerator()
    {
        yield return new Unit();
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}
