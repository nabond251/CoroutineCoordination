namespace CoroutineCoordination;

using CoroutineCommandLine;

public class HelloCommandLine : CommandLineCoroutine
{
    private readonly FuncCoroutine<string?> name;

    public HelloCommandLine(FuncCoroutine<string?> name)
    {
        this.name = name;
    }

    public override IEnumerator<CommandLineSink> GetEnumerator()
    {
        yield return new CommandLineSink.WriteLine("Please enter your name.");
        yield return new CommandLineSink.ReadLine(name);
        yield return new CommandLineSink.WriteLine($"Hello, {name.NextValue}!");
    }
}
