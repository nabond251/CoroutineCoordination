namespace CoroutineCoordinationTests;

using CoroutineCommandLine;
using CoroutineCoordination;

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
        var expectedSubProgram = new ReadLineCoroutine();
        var expectedSubEnumerator = expectedSubProgram.GetEnumerator();
        Assert.True(expectedSubEnumerator.MoveNext());
        var actualReadLine = enumerator.Current as CommandLineSink.ReadLine;
        Assert.NotNull(actualReadLine);
        var actualSubProgram = actualReadLine.Program;
        var actualSubEnumerator = actualSubProgram.GetEnumerator();
        Assert.True(actualSubEnumerator.MoveNext(), "Did not call ReadLine");
        Assert.Equal(expectedSubEnumerator.Current, actualSubEnumerator.Current);
        actualSubProgram.NextValue = new ReadLineSource("Nathan");

        Assert.True(enumerator.MoveNext(), "Did not greet");
        Assert.Equal(new CommandLineSink.WriteLine("Hello, Nathan!"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
