namespace CoroutineCoordinationTests;

using CoroutineCommandLine;
using CoroutineCoordination;

public class CoroutineCommandLineTests
{
    [Fact]
    public void CommandLineShouldGreetUser()
    {
        var name = new MockReadLineCoroutine();
        var program = new HelloCommandLine(name);
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter your name."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        Assert.Equal(new CommandLineSink.ReadLine(name), enumerator.Current);
        name.NextValue = "Nathan";

        Assert.True(enumerator.MoveNext(), "Did not greet");
        Assert.Equal(new CommandLineSink.WriteLine("Hello, Nathan!"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
