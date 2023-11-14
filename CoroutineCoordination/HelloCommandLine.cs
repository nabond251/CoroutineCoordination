namespace CoroutineCoordination;

using CoroutineCommandLine;

public class HelloCommandLine : CommandLineCoroutine
{
    private readonly Func<string?> readLine;

    public HelloCommandLine(Func<string?> readLine)
    {
        this.readLine = readLine;
    }

    public override IEnumerator<CommandLineSink> GetEnumerator()
    {
        yield return new CommandLineSink.WriteLine("Please enter your name.");
        var name = new FuncCoroutine<string?>(this.readLine);
        yield return new CommandLineSink.ReadLine(name);
        yield return new CommandLineSink.WriteLine($"Hello, {name.NextValue}!");
    }
}
