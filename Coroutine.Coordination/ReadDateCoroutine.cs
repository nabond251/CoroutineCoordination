namespace Coroutine.Coordination;

public class ReadDateCoroutine : CommandLineCoroutine<DateTime>
{
    public override IEnumerator<CommandLineEffect> GetEnumerator()
    {
        yield return new CommandLineEffect.WriteLine(
            "Please enter your desired date:");

        var date = new CommandLineEffect.ReadLine();
        yield return date;
        var l = date.Result;

        if (DateTime.TryParse(l, out var dt))
        {
            Result = dt;
        }
        else
        {
            yield return new CommandLineEffect.WriteLine(
                "Not a date.");

            var readDate = new CommandLineEffect.Call<DateTime>(
                new ReadDateCoroutine());
            yield return readDate;
            Result = readDate.Result;
        }
    }
}
