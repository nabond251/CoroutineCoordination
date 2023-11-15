namespace CoroutineCoordination;

using CoroutineCommandLine;

public class HelloCommandLine : CommandLineCoroutine
{
    private readonly IFuncCoroutine<string?> name;

    public HelloCommandLine(IFuncCoroutine<string?> name)
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
