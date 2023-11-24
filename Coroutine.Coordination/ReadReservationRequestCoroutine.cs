namespace Coroutine.Coordination;

public class ReadReservationRequestCoroutine : Coroutine<Reservation>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        var readQuantity = new Call<int>(new ReadQuantityCoroutine());
        yield return readQuantity;
        var count = readQuantity.Result;

        var readDate = new Call<DateTime>(new ReadDateCoroutine());
        yield return readDate;
        var date = readDate.Result;

        var readName = new Call<string>(new ReadNameCoroutine());
        yield return readName;
        var name = readName.Result ?? throw new InvalidOperationException();

        var readEmail = new Call<string>(new ReadEmailCoroutine());
        yield return readEmail;
        var email = readEmail.Result ?? throw new InvalidOperationException();

        Result = new Reservation(date, name, email, count);
    }
}
