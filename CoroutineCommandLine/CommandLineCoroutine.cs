namespace CoroutineCommandLine;

using System.Collections;

public abstract class CommandLineCoroutine : IEnumerable<string?>
{
    public string? NextValue { protected get; set; }

    public abstract IEnumerator<string?> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}
