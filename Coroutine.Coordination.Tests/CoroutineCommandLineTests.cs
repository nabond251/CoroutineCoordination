using System.Globalization;

namespace Coroutine.Coordination.Tests;

public class CoroutineCommandLineTests
{
    [Fact]
    public void CommandLineShouldGreetUser()
    {
        var program = new HelloCommandLine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new WriteLine("Please enter your name."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var name = enumerator.Current as ReadLine;
        Assert.NotNull(name);
        name.Result = "Nathan";

        Assert.True(enumerator.MoveNext(), "Did not greet");
        Assert.Equal(new WriteLine("Hello, Nathan!"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void ReadQuantityShouldRejectNotInteger()
    {
        var program = new ReadQuantityCoroutine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new WriteLine("Please enter number of diners:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var diner1 = enumerator.Current as ReadLine;
        Assert.NotNull(diner1);
        diner1.Result = "two";

        Assert.True(enumerator.MoveNext(), "Did not reject prompt response");
        Assert.Equal(new WriteLine("Not an integer."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not recurse");
        var readQuantity = enumerator.Current as Call<int>;
        Assert.NotNull(readQuantity);
        readQuantity.Result = 2;

        Assert.True(enumerator.MoveNext(), "Did not return");
        Assert.Equal(new Coroutine<int>.Return(2), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void ReadQuantityShouldAcceptInteger()
    {
        var program = new ReadQuantityCoroutine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new WriteLine("Please enter number of diners:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var diner2 = enumerator.Current as ReadLine;
        Assert.NotNull(diner2);
        diner2.Result = "2";

        Assert.True(enumerator.MoveNext(), "Did not return");
        Assert.Equal(new Coroutine<int>.Return(2), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void ReadDateShouldRejectNotDate()
    {
        var program = new ReadDateCoroutine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new WriteLine("Please enter your desired date:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var date1 = enumerator.Current as ReadLine;
        Assert.NotNull(date1);
        date1.Result = "When we get a babysitter";

        Assert.True(enumerator.MoveNext(), "Did not reject prompt response");
        Assert.Equal(new WriteLine("Not a date."), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not recurse");
        var readDate = enumerator.Current as Call<DateTime>;
        Assert.NotNull(readDate);
        var date = DateTime.Parse("11-28-2023", CultureInfo.InvariantCulture);
        readDate.Result = date;

        Assert.True(enumerator.MoveNext(), "Did not return");
        Assert.Equal(new Coroutine<DateTime>.Return(date), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void ReadDateShouldAcceptDate()
    {
        var program = new ReadDateCoroutine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new WriteLine("Please enter your desired date:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var date2 = enumerator.Current as ReadLine;
        Assert.NotNull(date2);
        date2.Result = "11-28-2023";

        Assert.True(enumerator.MoveNext(), "Did not return");
        Assert.Equal(
            new Coroutine<DateTime>.Return(
                DateTime.Parse("11-28-2023",
                CultureInfo.InvariantCulture)),
            enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void ReadNameShouldAcceptString()
    {
        var program = new ReadNameCoroutine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new WriteLine("Please enter your name:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var name = enumerator.Current as ReadLine;
        Assert.NotNull(name);
        name.Result = "Nathan Bond";

        Assert.True(enumerator.MoveNext(), "Did not return");
        Assert.Equal(new Coroutine<string>.Return("Nathan Bond"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void ReadEmailShouldAcceptString()
    {
        var program = new ReadEmailCoroutine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not display prompt");
        Assert.Equal(new WriteLine("Please enter your email address:"), enumerator.Current);

        Assert.True(enumerator.MoveNext(), "Did not receive prompt response");
        var email = enumerator.Current as ReadLine;
        Assert.NotNull(email);
        email.Result = "nathan@example.com";

        Assert.True(enumerator.MoveNext(), "Did not return");
        Assert.Equal(new Coroutine<string>.Return("nathan@example.com"), enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }

    [Fact]
    public void CommandLineShouldReserveSeats()
    {
        var program = new ReadReservationRequestCoroutine();
        var enumerator = program.GetEnumerator();

        Assert.True(enumerator.MoveNext(), "Did not read quantity");
        var readQuantity = enumerator.Current as Call<int>;
        Assert.NotNull(readQuantity);
        readQuantity.Result = 2;

        Assert.True(enumerator.MoveNext(), "Did not read date");
        var readDate = enumerator.Current as Call<DateTime>;
        Assert.NotNull(readDate);
        readDate.Result = DateTime.Parse("11-28-2023", CultureInfo.InvariantCulture);

        Assert.True(enumerator.MoveNext(), "Did not read name");
        var readName = enumerator.Current as Call<string>;
        Assert.NotNull(readName);
        readName.Result = "Nathan Bond";

        Assert.True(enumerator.MoveNext(), "Did not read email");
        var readEmail = enumerator.Current as Call<string>;
        Assert.NotNull(readEmail);
        readEmail.Result = "nathan@example.com";

        Assert.True(enumerator.MoveNext(), "Did not return");
        Assert.Equal(
            new Coroutine<Reservation>.Return(new Reservation(
                DateTime.Parse("11-28-2023", CultureInfo.InvariantCulture),
                "Nathan Bond",
                "nathan@example.com",
                2)),
            enumerator.Current);

        Assert.False(enumerator.MoveNext());
    }
}
