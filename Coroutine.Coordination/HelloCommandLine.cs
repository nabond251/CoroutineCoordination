using System.Threading.Channels;

namespace Coroutine.Coordination;

public class HelloCommandLine : CommandLineCoroutine
{
    public HelloCommandLine(ChannelReader<CommandLineSource> nextReader) :
        base(nextReader)
    {
    }

    public override IEnumerator<CommandLineSink> GetEnumerator()
    {
        yield return new CommandLineSink.WriteLine("Please enter your name.");

        yield return new CommandLineSink.ReadLine();
        this.NextReader.TryRead(out var next);
        var name = next as CommandLineSource.ReadLine ??
            throw new InvalidOperationException();

        yield return new CommandLineSink.WriteLine($"Hello, {name.Text}!");
    }
}
