using System.Collections;

namespace CoroutineCoordination;

public class HelloCommandLine : IEnumerable<string?>
{
    public IEnumerator<string?> GetEnumerator()
    {
        yield break;
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}