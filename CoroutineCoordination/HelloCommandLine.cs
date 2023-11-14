namespace CoroutineCoordination;

using CoroutineCommandLine;

public class HelloCommandLine : CommandLineCoroutine
{
    public override IEnumerator<CommandLineSink> GetEnumerator()
    {
        yield return new CommandLineSink.WriteLine("Please enter your name.");
        var readLine = new ReadLineCoroutine();
        yield return new CommandLineSink.ReadLine(readLine);
        var name = readLine.NextValue ??
            throw new InvalidProgramException();
        yield return new CommandLineSink.WriteLine($"Hello, {name.Text}!");
    }
}
