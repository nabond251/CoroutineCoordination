namespace CoroutineCoordination;

using CoroutineCommandLine;

public class HelloCommandLine : CommandLineCoroutine
{
    public override IEnumerator<string?> GetEnumerator()
    {
        yield return "Please enter your name.";
        yield return null;
        var name = this.NextValue;
        yield return $"Hello, {name}!";
    }
}
