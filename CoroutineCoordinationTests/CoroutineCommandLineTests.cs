namespace CoroutineCoordinationTests;

using CoroutineCommandLine;
using CoroutineCoordination;

public class CoroutineCommandLineTests
{
    [Fact]
    public void CommandLineShouldGreetUser()
    {
        var program = new HelloCommandLine(Console.ReadLine);
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter your name."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var readLine = enumerator.Current as CommandLineSink.ReadLine;
        Assert.NotNull(readLine);
        readLine.Program.NextValue = "Nathan";

        Assert.True(enumerator.MoveNext(), "Did not greet");
        Assert.Equal(new CommandLineSink.WriteLine("Hello, Nathan!"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
