using System.Threading.Channels;

namespace Coroutine.Coordination.Tests;

public class CoroutineCommandLineTests
{
    [Fact]
    public void CommandLineShouldGreetUser()
    {
        var program = new HelloCommandLine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter your name."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var name = enumerator.Current as CommandLineSink.ReadLine;
        Assert.NotNull(name);
        name.Result = "Nathan";

        Assert.True(enumerator.MoveNext(), "Did not greet");
        Assert.Equal(new CommandLineSink.WriteLine("Hello, Nathan!"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
