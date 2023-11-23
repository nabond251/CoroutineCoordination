namespace Coroutine.Coordination.Tests;

public class CoroutineCommandLineTests
{
    [Fact]
    public void CommandLineShouldGreetUser()
    {
        var program = new HelloCommandLine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new CommandLineEffect.WriteLine("Please enter your name."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var name = enumerator.Current as CommandLineEffect.ReadLine;
        Assert.NotNull(name);
        name.Result = "Nathan";

        Assert.True(enumerator.MoveNext(), "Did not greet");
        Assert.Equal(new CommandLineEffect.WriteLine("Hello, Nathan!"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void CommandLineShouldReserveSeats()
    {
        var program = new CommandLineWizard();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display first diners prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter number of diners:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive first diners prompt response");
        Assert.Equal(new CommandLineSink.ReadLine(), enumerator.Current);
        program.NextValue = new CommandLineSource.ReadLine("two");

        Assert.True(enumerator.MoveNext(), "Did not reject first diners prompt response");
        Assert.Equal(new CommandLineSink.WriteLine("Not an integer."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not display second diners prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter number of diners:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive second diners prompt response");
        Assert.Equal(new CommandLineSink.ReadLine(), enumerator.Current);
        program.NextValue = new CommandLineSource.ReadLine("2");

        Assert.True(enumerator.MoveNext(), "Did not display first date prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter your desired date:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive first date prompt response");
        Assert.Equal(new CommandLineSink.ReadLine(), enumerator.Current);
        program.NextValue = new CommandLineSource.ReadLine("When we get a babysitter");

        Assert.True(enumerator.MoveNext(), "Did not reject first date prompt response");
        Assert.Equal(new CommandLineSink.WriteLine("Not a date."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not display second date prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter your desired date:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive second date prompt response");
        Assert.Equal(new CommandLineSink.ReadLine(), enumerator.Current);
        program.NextValue = new CommandLineSource.ReadLine("11-28-2023");

        Assert.True(enumerator.MoveNext(), "Did not display name prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter your name:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive name prompt response");
        Assert.Equal(new CommandLineSink.ReadLine(), enumerator.Current);
        program.NextValue = new CommandLineSource.ReadLine("Nathan Bond");

        Assert.True(enumerator.MoveNext(), "Did not display email prompt");
        Assert.Equal(new CommandLineSink.WriteLine("Please enter your email:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive email prompt response");
        Assert.Equal(new CommandLineSink.ReadLine(), enumerator.Current);
        program.NextValue = new CommandLineSource.ReadLine("nathan@example.com");

        Assert.True(enumerator.MoveNext(), "Did not display confirmation");
        Assert.Equal(new CommandLineSink.WriteLine(@"{Date = 11/28/2023 12:00:00 AM,
 Name = ""Nathan Bond"",
 Email = ""nathan@example.com"",
 Quantity = 2;}"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
