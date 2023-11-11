namespace CoroutineCoordination;

using System.Collections;

public class HelloCommandLine : IEnumerable<string?>
{
    public string? NextValue { private get; set; }

    public IEnumerator<string?> GetEnumerator()
    {
        yield return "Please enter your name.";
        yield return null;
        var name = this.NextValue;
        yield return $"Hello, {name}!";
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}
