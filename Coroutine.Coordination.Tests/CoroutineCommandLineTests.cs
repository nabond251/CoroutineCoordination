using System.Threading.Channels;

namespace Coroutine.Coordination.Tests;

public class CoroutineCommandLineTests
{
    [Fact]
    public void CommandLineShouldGreetUser()
    {
        var next = Channel.CreateUnbounded<CommandLineSource>();
        var program = new HelloCommandLine(next);
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter your name."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        Assert.Equal(new CommandLineSink.ReadLine(), enumerator.Current);
        next.Writer.TryWrite(new CommandLineSource.ReadLine("Nathan"));

        Assert.True(enumerator.MoveNext(), "Did not greet");
        Assert.Equal(new CommandLineSink.WriteLine("Hello, Nathan!"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
