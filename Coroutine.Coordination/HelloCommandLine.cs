namespace Coroutine.Coordination;

public class HelloCommandLine : CommandLineCoroutine
{
    public override IEnumerator<CommandLineSink> GetEnumerator()
    {
        yield return new CommandLineSink.WriteLine("Please enter your name.");

        yield return new CommandLineSink.ReadLine();
        var name = this.NextValue as CommandLineSource.ReadLine ??
            throw new InvalidOperationException();

        yield return new CommandLineSink.WriteLine($"Hello, {name.Text}!");
    }
}
