namespace Coroutine.Coordination;

public class ReadReservationRequestCoroutine : Coroutine<Reservation>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        var readQuantity = new Call<int>(new ReadQuantityCoroutine());
        yield return readQuantity;
        var count = readQuantity.Result.Single();

        var readDate = new Call<DateTime>(new ReadDateCoroutine());
        yield return readDate;
        var date = readDate.Result.Single();

        var readName = new Call<string?>(new ReadNameCoroutine());
        yield return readName;
        var name = readName.Result.Single();

        var readEmail = new Call<string?>(new ReadEmailCoroutine());
        yield return readEmail;
        var email = readEmail.Result.Single();

        yield return new Result(new Reservation(date, name, email, count));
    }
}
