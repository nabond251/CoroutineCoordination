namespace CoroutineCoordinationTests;

using CoroutineCoordination;

public class CoroutineCommandLineTests
{
    [Fact]
    public void CommandLineShouldGreetUser()
    {
        var coroutine = new HelloCommandLine();
        Assert.NotNull(coroutine);
    }
}
