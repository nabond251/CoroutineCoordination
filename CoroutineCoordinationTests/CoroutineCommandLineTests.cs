namespace CoroutineCoordinationTests;

using CoroutineCoordination;

public class CoroutineCommandLineTests
{
    [Fact]
    public void CommandLineShouldGreetUser()
    {
        var program = new HelloCommandLine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal("Please enter your name.", enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        Assert.Null(enumerator.Current);
        program.NextValue = "Nathan";

        Assert.True(enumerator.MoveNext(), "Did not greet");
        Assert.Equal("Hello, Nathan!", enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
