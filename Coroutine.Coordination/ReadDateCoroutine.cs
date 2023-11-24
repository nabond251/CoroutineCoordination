﻿namespace Coroutine.Coordination;

public class ReadDateCoroutine : CommandLineCoroutine<DateTime>
{
    public override IEnumerator<IEffect> GetEnumerator()
    {
        yield return new WriteLine(
            "Please enter your desired date:");

        var date = new ReadLine();
        yield return date;
        var l = date.Result;

        if (DateTime.TryParse(l, out var dt))
        {
            Result = dt;
        }
        else
        {
            yield return new WriteLine(
                "Not a date.");

            var readDate = new Call<DateTime>(
                new ReadDateCoroutine());
            yield return readDate;
            Result = readDate.Result;
        }
    }
}
