namespace CoroutineCoordination;

using CoroutineCommandLine;

public class HelloCommandLine : CommandLineCoroutine
{
    public override IEnumerator<CommandLineSink> GetEnumerator()
    {
        yield return new CommandLineSink.WriteLine("Please enter your name.");
        var name = new ReadLineCoroutine();
        yield return new CommandLineSink.ReadLine(name);
        yield return new CommandLineSink.WriteLine($"Hello, {name.NextValue}!");
    }
}
