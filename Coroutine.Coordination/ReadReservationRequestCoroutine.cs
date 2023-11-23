namespace Coroutine.Coordination;

public class ReadReservationRequestCoroutine : CommandLineCoroutine<Reservation>
{
    public override IEnumerator<CommandLineEffect> GetEnumerator()
    {
        var readQuantity = new CommandLineEffect.Call<int>(new ReadQuantityCoroutine());
        yield return readQuantity;
        var count = readQuantity.Result;

        var readDate = new CommandLineEffect.Call<DateTime>(new ReadDateCoroutine());
        yield return readDate;
        var date = readDate.Result;

        var readName = new CommandLineEffect.Call<string>(new ReadNameCoroutine());
        yield return readName;
        var name = readName.Result ?? throw new InvalidOperationException();

        var readEmail = new CommandLineEffect.Call<string>(new ReadEmailCoroutine());
        yield return readEmail;
        var email = readEmail.Result ?? throw new InvalidOperationException();

        Result = new Reservation(date, name, email, count);
    }
}
